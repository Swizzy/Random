using System;
using System.Windows.Forms;

namespace XeLLReplacer
{
    using System.IO;
    using System.Reflection;

    internal sealed partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            Text = string.Format(Text, ver.Major, ver.Minor);
        }

        private static byte[] Calcecc(ref byte[] data, int offset)
        {
            UInt32 i, val = 0, v = 0;
            var count = 0;
            var edc = new byte[4];
            for (i = 0; i < 0x1066; i++)
            {
                if ((i & 31) == 0)
                {
                    v = ~BitConverter.ToUInt32(data, (count + offset));
                    count += 4;
                }
                val ^= v & 1;
                v >>= 1;
                if ((val & 1) != 0)
                    val ^= 0x6954559;
                val >>= 1;
            }
            val = ~val;
            edc[0] = (byte)(val << 6);
            edc[1] = (byte)((val >> 2) & 0xFF);
            edc[2] = (byte)((val >> 10) & 0xFF);
            edc[3] = (byte)((val >> 18) & 0xFF);
            return edc;
        }

        private static void PatchSpare(ref byte[] data, ref byte[] src, int targetindex)
        {
            for (var srcindex = 0; srcindex < data.Length; srcindex += 0x200, targetindex += 0x210)
                Buffer.BlockCopy(data, srcindex, src, targetindex, 0x200);
            for (var i = 0; i < src.Length; i += 0x210)
            {
                var edc = Calcecc(ref src, i);
                Buffer.BlockCopy(edc, 0, src, i + 0x20c, edc.Length);
            }
        }

        private void Button1Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog {
                                         Title = "Select source image", FileName = "image.ecc"
                                         };
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            var fi = new FileInfo(ofd.FileName);
            if (fi.Length != 0x140000 && fi.Length != 0x14a000)
            {
                MessageBox.Show("Corrupt ECC image?");
                return;
            }
            var src = File.ReadAllBytes(ofd.FileName);
            if (!IsValidNAND(src)) {
                MessageBox.Show("Corrupt ECC image?");
                return;
            }
            ofd.FileName = "xell.bin";
            ofd.Title = "Select XeLL to store in the new image";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            var xell = File.ReadAllBytes(ofd.FileName);
            if (xell.Length != 0x40000) {
                MessageBox.Show("Corrupt XeLL?");
                return;
            }
            if (src.Length == 0x140000) {
                Buffer.BlockCopy(xell, 0, src, src.Length - (xell.Length * 2), xell.Length);
                Buffer.BlockCopy(xell, 0, src, src.Length - xell.Length, xell.Length);
            }
            else {
                var tmp = new byte[xell.Length * 2];
                Buffer.BlockCopy(xell, 0, tmp, 0, xell.Length);
                Buffer.BlockCopy(xell, 0, tmp, xell.Length, xell.Length);
                PatchSpare(ref tmp, ref src, src.Length - ((tmp.Length / 0x200) * 0x210));
            }
            var sfd = new SaveFileDialog {
                                         FileName = "Modified.ecc", Title = "Select where to save the new image...", DefaultExt = "ecc"
                                         };
            if (sfd.ShowDialog() == DialogResult.OK)
                File.WriteAllBytes(sfd.FileName, src);
        }

        private static bool IsValidNAND(byte[] src) {
            return src[0] == 0xFF && src[1] == 0x4F;
        }
    }
}
