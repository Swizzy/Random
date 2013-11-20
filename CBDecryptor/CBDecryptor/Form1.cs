namespace CBDecryptor
{
    using System;
    using System.Security.Cryptography;
    using System.Windows.Forms;
    using System.Globalization;
    using System.IO;
    using System.Text.RegularExpressions;

    internal sealed partial class Form1 : Form
    {
        internal Form1()
        {
            InitializeComponent();
        }

        internal static UInt16 Swap16(UInt16 input)
        {
            return (UInt16)((input & 0xFF00) >> 8 | (input & 0x00FF) << 8);
        }

        private static void Rc4(ref Byte[] bytes, Byte[] key)
        {
            if (bytes == null || key == null || bytes.Length == 0 || key.Length == 0)
                return;
            var s = new Byte[256];
            var k = new Byte[256];
            Byte temp;
            int i;
            for (i = 0; i < 256; i++)
            {
                s[i] = (Byte)i;
                k[i] = key[i % key.GetLength(0)];
            }
            var j = 0;
            for (i = 0; i < 256; i++)
            {
                j = (j + s[i] + k[i]) % 256;
                temp = s[i];
                s[i] = s[j];
                s[j] = temp;
            }
            i = j = 0;
            for (var x = 0; x < bytes.GetLength(0); x++)
            {
                i = (i + 1) % 256;
                j = (j + s[i]) % 256;
                temp = s[i];
                s[i] = s[j];
                s[j] = temp;
                var t = (s[i] + s[j]) % 256;
                bytes[x] ^= s[t];
            }
        }

        public static byte[] HexStringToArray(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            var ret = new byte[input.Length / 2];
            for (var i = 0; i < input.Length; i += 2)
                ret[i / 2] = byte.Parse(input.Substring(i, 2), NumberStyles.HexNumber);
            return ret;
        }


        public static bool Keycheck(string key, bool warn)
        {
            if (key == null)
                return false;
            key = key.Trim();
            if (key.Length < 32)
            {
                if (warn)
                    MessageBox.Show(@"ERROR: Invalid input, to short!", @"ERROR", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return false;
            }
            if (key.Length == 32)
            {
                var strHex = String.Concat("[0-9A-Fa-f]{", key.Length, "}");
                var isgood = Regex.IsMatch(key, strHex);
                if (!isgood)
                {
                    if (warn)
                        MessageBox.Show(@"ERROR: Invalid input, invalid characters!", @"ERROR", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            if (warn)
                MessageBox.Show(@"ERROR: Invalid input, to long!", @"ERROR", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            return false;
        }

        private void BlkeybtnClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            cbakey.Text = File.ReadAllText(ofd.FileName);
            ofd.FileName = Path.GetFileName(ofd.FileName);
        }

        public static string Readfusefile(string file)
        {
            var val = "";
            Int64 key1 = 0, key2 = 0, key3 = 0, key4 = 0;
            using (var sr = new StreamReader(file))
            {
                while (val != null)
                {
                    val = sr.ReadLine();
                    if (val == null)
                        continue;
                    if (val.StartsWith("fuseset 03:", StringComparison.Ordinal))
                        Int64.TryParse(val.Remove(0, 11), NumberStyles.HexNumber, null, out key1);
                    else if (val.StartsWith("fuseset 04:", StringComparison.Ordinal))
                        Int64.TryParse(val.Remove(0, 11), NumberStyles.HexNumber, null, out key2);
                    else if (val.StartsWith("fuseset 05:", StringComparison.Ordinal))
                        Int64.TryParse(val.Remove(0, 11), NumberStyles.HexNumber, null, out key3);
                    else if (val.StartsWith("fuseset 06:", StringComparison.Ordinal))
                        Int64.TryParse(val.Remove(0, 11), NumberStyles.HexNumber, null, out key4);
                }
                sr.Close();
            }
            if ((key1 == 0) || (key2 == 0) || (key3 == 0) || (key4 == 0))
                return "";
            return (key1 | key2).ToString("X16") + (key3 | key4).ToString("X16");
        }

        public static string Readkeyfile(string file)
        {
            using (var sr = new StreamReader(file))
            {
                var key = sr.ReadLine();
                if (key != null &&
                    ((key.Trim().IndexOf("cpukey", StringComparison.CurrentCultureIgnoreCase) >= 0) && (key.Length > 38)))
                    key = key.Substring(key.Length - 32, 32);
                sr.Close();
                if ((key == null) || (!Keycheck(key, false)))
                    return "";
                return key;
            }
        }
        
        private void CbbkeybtnClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            var key = Readkeyfile(ofd.FileName);
            if (string.IsNullOrEmpty(key) || !Keycheck(key, false))
                key = Readfusefile(ofd.FileName);
            if (!string.IsNullOrEmpty(key) || Keycheck(key, false))
                cbbkey.Text = key;
            else
                MessageBox.Show(@"ERROR: Bad Key file!");
            ofd.FileName = Path.GetFileName(ofd.FileName);
        }

        private void LoadcbabtnClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            cbapath.Text = ofd.FileName;
            ofd.FileName = Path.GetFileName(ofd.FileName);
        }

        private void LoadcbbbtnClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            cbbpath.Text = ofd.FileName;
            ofd.FileName = Path.GetFileName(ofd.FileName);
        }

        private void Button1Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbapath.Text) || string.IsNullOrEmpty(cbakey.Text) || !Keycheck(cbakey.Text, true) || !File.Exists(cbapath.Text))
                return;
            var cbadata = File.ReadAllBytes(cbapath.Text);
            if (!Blcheck(ref cbadata, 0x270, 0x120))
                DecryptCb(ref cbadata, HexStringToArray(cbakey.Text));
            if (!Blcheck(ref cbadata, 0x270, 0x120)) {
                MessageBox.Show(@"ERROR: Failed to decrypt CB_A!");
                return;
            }
            File.WriteAllBytes(Path.GetDirectoryName(cbapath.Text) + "\\dec_" + Path.GetFileName(cbapath.Text), cbadata);
            if (string.IsNullOrEmpty(cbbpath.Text) || string.IsNullOrEmpty(cbbkey.Text) || !Keycheck(cbbkey.Text, true) || !File.Exists(cbbpath.Text))
                return;
            var cbbdata = File.ReadAllBytes(cbbpath.Text);
            if (!Blcheck(ref cbbdata, 0x270, 0x120))
                DecryptCb(ref cbbdata, HexStringToArray(cbbkey.Text), cbadata);
            if (!Blcheck(ref cbbdata, 0x270, 0x120))
            {
                MessageBox.Show(@"ERROR: Failed to decrypt CB_B!");
                return;
            }
            File.WriteAllBytes(Path.GetDirectoryName(cbbpath.Text) + "\\dec_" + Path.GetFileName(cbbpath.Text), cbbdata);
        }

        public static bool Blcheck(ref byte[] data, int offset, int length)
        {
            for (var i = 0; i < length; i++)
                if (data[offset + i] != 0x00)
                    return false;
            return true;
        }

        public static void DecryptCb(ref byte[] data, byte[] inkey, byte[] cba = null)
        {
            if (data.Length == 0)
                return;
            var error = false;
            UInt16 type;
            if (cba != null)
                type = Swap16(BitConverter.ToUInt16(cba, 6));
            else
            {
                type = Swap16(BitConverter.ToUInt16(data, 6));
                if ((type == 0x800) || (type == 0x801) || (type == 0x1800))
                    type = 0;
            }
            var header = new byte[0x10];
            Array.Copy(data, 0x10, header, 0x0, 0x10);
            var key = new byte[0];
            if (type == 0)
                key = new HMACSHA1(inkey).ComputeHash(header);
            else if ((type == 0x800) && (cba != null))
            {
                Array.Resize(ref header, 0x20);
                Array.Copy(inkey, 0x0, header, 0x10, 0x10);
                var cbakey = new byte[0x10];
                Array.Copy(cba, 0x10, cbakey, 0x0, 0x10);
                key = new HMACSHA1(cbakey).ComputeHash(header);
            }
            else if ((type == 0x1800) && (cba != null))
            {
                header = new byte[0x30];
                Array.Copy(data, 0x10, header, 0x0, 0x10);
                Array.Copy(inkey, 0x0, header, 0x10, 0x10);
                Array.Copy(cba, 0x0, header, 0x20, 0x6);
                Array.Copy(cba, 0x8, header, 0x20 + 0x8, 0x8);
                var cbakey = new byte[0x10];
                Array.Copy(cba, 0x10, cbakey, 0x0, 0x10);
                key = new HMACSHA1(cbakey).ComputeHash(header);
            }
            else
            {
                error = true;
                MessageBox.Show(
                    string.Format("ERROR: Unkown crypto type! (0x{0}) or cba data is missing (major bug)",
                                  type.ToString("X4")), @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error)
                return;
            Array.Resize(ref key, 0x10);
            Array.Copy(key, 0x0, data, 0x10, 0x10);
            var decrypted = new byte[data.Length - 0x20];
            Buffer.BlockCopy(data, 0x20, decrypted, 0x0, decrypted.Length);
            Rc4(ref decrypted, key);
            Buffer.BlockCopy(decrypted, 0x0, data, 0x20, decrypted.Length);
        }

        private void CbapathDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop)
                           ? DragDropEffects.Copy
                           : DragDropEffects.None;
        }

        private void CbbpathDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop)
                           ? DragDropEffects.Copy
                           : DragDropEffects.None;
        }

        private void CbapathDragDrop(object sender, DragEventArgs e)
        {
            cbapath.Text = ((string[]) e.Data.GetData(DataFormats.FileDrop, false))[0];
        }

        private void CbbpathDragDrop(object sender, DragEventArgs e) {
            cbbpath.Text = ((string[]) e.Data.GetData(DataFormats.FileDrop, false))[0];
        }
    }
}
