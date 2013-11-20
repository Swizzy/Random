namespace GetMediaID {
    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    internal sealed partial class Form1 : Form {
        internal Form1() {
            InitializeComponent();
        }

        private static UInt32 Swap(UInt32 value) {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 | (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }

        private void Button1Click(object sender, EventArgs e) {
            if(openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            byte[] check = new byte[12], xexdata = new byte[4];
            var xexfile = openFileDialog1.FileName;
            using(var br = new BinaryReader(File.Open(xexfile, FileMode.Open, FileAccess.Read, FileShare.None))) {
                for(var i = 0; i < 12; i++)
                    check[i] = br.ReadByte();
                Array.Copy(check, xexdata, 4);
                if(Encoding.ASCII.GetString(xexdata) == "XEX2") {
                    uint midval = 0, headersize = Swap(BitConverter.ToUInt32(check, 8));
                    var header = new byte[headersize];
                    for(var i = 0; i < headersize; i++)
                        header[i] = br.ReadByte();
                    for(var i = 0; i < headersize; i++) {
                        if((header[i] != 0x00) || (header[i + 1] != 0x04) || (header[i + 2] != 0x00) || (header[i + 3] != 0x06))
                            continue;
                        var offset = Convert.ToInt32((Int32) Swap(BitConverter.ToUInt32(header, i + 4)));
                        midval = Swap(BitConverter.ToUInt32(header, offset - 0xC));
                        mid.Text = midval.ToString("X8");
                        i = Convert.ToInt32(headersize);
                    }
                    if(midval != 0)
                        return;
                    MessageBox.Show(@"ERROR: Unable to get Media ID!", @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mid.Text = "";
                }
                else
                    MessageBox.Show(@"ERROR: File is not a real XEX!", @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}