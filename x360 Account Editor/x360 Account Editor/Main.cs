namespace x360_Account_Editor {
    using System;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using x360_Account_Editor.Properties;

    internal sealed partial class Main : Form {

        private static readonly char[] HexCharTable = new[]
                                                          {
                                                              '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B',
                                                              'C', 'D', 'E', 'F'
                                                          };

        private static string ArrayToHex(ref byte[] value, int i = 0, int count = -1)
        {
            var c = new char[value.Length * 2];
            if (count == -1)
                count = value.Length - i;
            else
                count = count + i;
            for (var p = 0; i < count; )
            {
                var d = value[i++];
                c[p++] = HexCharTable[d / 0x10];
                c[p++] = HexCharTable[d % 0x10];
            }
            return new string(c);
        }

        private static byte[] HexToArray(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input can't be nothing!");
            input = StripNonHex(input);
            if (input.Length % 2 > 0)
                throw new ArgumentException("Input must be dividable by 2!");
            var ret = new byte[input.Length / 2];
            for (var i = 0; i < input.Length; i += 2)
                ret[i / 2] = byte.Parse(input.Substring(i, 2), NumberStyles.HexNumber);
            return ret;
        }

        private static bool StringIsHex(string input)
        {
            return Regex.IsMatch(input, "^[0-9A-Fa-f]+$");
        }

        private static string StripNonHex(string input)
        {
            var builder = new StringBuilder();
            foreach (var c in input)
                if (StringIsHex(c.ToString(CultureInfo.InvariantCulture)))
                    builder.Append(c);
            return builder.ToString();
        }

        private static void SetBytes(ref byte[] array, byte data, int index = 0, int count = -1) {
            var limit = index + 1;
            limit += count <= 0 ? (array.Length - index): count;
            for(; index < limit; index++)
                array[index] = data;
        }

        private static byte[] _data;
        internal static readonly Random Random = new Random();
        private bool _open;

        #region Patches

        #region Account Signature

        private readonly byte[] _familygold = { 0xFF, 0x60, 0xFF, 0x6C };
        private readonly byte[] _gold = { 0xFF, 0x60, 0xFF, 0x6C };
        private readonly byte[] _silver = { 0xFF, 0x30, 0xFF, 0x6C };

        #endregion

        #region Account Type

        private readonly byte[] _devkitacc = Encoding.ASCII.GetBytes("PNET");
        private readonly byte[] _retailacc = Encoding.ASCII.GetBytes("PROD");

        #endregion

        #region Static Online info

        private readonly byte[] _domain = Encoding.ASCII.GetBytes("xbox.com");
        private readonly byte[] _kerberosrealm = Encoding.ASCII.GetBytes("PASSPORT.NET");

        #endregion

        #endregion

        internal Main() {
            InitializeComponent();
        }

        private void Hexinput(object sender, KeyPressEventArgs e) {
            if(e.KeyChar != '\b')
                e.Handled = !Uri.IsHexDigit(e.KeyChar);
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e) {
            Close();
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e) {
            if(openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            status.Text = Resources.LoadingAccFileToMemory;
            _data = File.ReadAllBytes(openFileDialog1.FileName);
            getcurrent.Enabled = true;
            copycurrent.Enabled = false;
            GetcurrentClick(null, null);
            status.Text = Resources.FileLoaded;
            if(Isdecrypted(_data)) {
                decryptProfileToolStripMenuItem.Enabled = false;
                encryptProfileToolStripMenuItem.Enabled = true;
            }
            else {
                decryptProfileToolStripMenuItem.Enabled = true;
                encryptProfileToolStripMenuItem.Enabled = false;
            }
        }

        private void SaveToolStripMenuItemClick(object sender, EventArgs e) {
            status.Text = Resources.SavingAccountFile;
            try {
                if(File.Exists(openFileDialog1.FileName + ".bak"))
                    File.Delete(openFileDialog1.FileName + ".bak");
                File.Copy(openFileDialog1.FileName, openFileDialog1.FileName + ".bak");
            }
            catch {
            }
            File.WriteAllBytes(openFileDialog1.FileName, _data);
            status.Text = Resources.AccountFileSaved + openFileDialog1.FileName;
            _open = false;
        }

        private void GetcurrentClick(object sender, EventArgs e) {
            status.Text = Resources.GettingCurrentInfo;
            currtype.Text = "";
            currtype2.Text = "";
            currname.Text = "";
            currxuid.Text = "";
            currsig.Text = "";
            copycurrent.Enabled = false;
            if(!Isdecrypted(_data)) {
                functions.Enabled = false;
                if(sender != null)
                    MessageBox.Show(Resources.ErrorCorruptOrEncrypted, Resources.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                switch(_data[0]) {
                    case 0x00:
                        currtype2.Text = Resources.Offline;
                        makeonline.Enabled = true;
                        break;
                    case 0x20:
                        currtype2.Text = Resources.Online;
                        break;
                    case 0x30:
                        currtype2.Text = Resources.PassProtected;
                        getPasscodeToolStripMenuItem.Enabled = true;
                        clearPasscodeToolStripMenuItem.Enabled = true;
                        break;
                }
                
                makeoffline.Enabled = _data[0] == 0x30 || _data[0] == 0x20;
                patchsig.Enabled = makeoffline.Enabled;
                patchtype.Enabled = patchsig.Enabled;
                currname.Text = Encoding.Unicode.GetString(_data, 0x9, 0x1E);
                currxuid.Text = ArrayToHex(ref _data, 0x28, 0x8);
                switch(_data[0x31]) {
                    case 0x30:
                        currsig.Text = Resources.Silver;
                        break;
                    case 0x90:
                        currsig.Text = Resources.FamilyGold;
                        break;
                    case 0x60:
                        currsig.Text = Resources.Gold;
                        break;
                    default:
                        currsig.Text = Resources.Unknown;
                        break;
                }
                var test = Encoding.ASCII.GetString(_data, 0x34, 0x4);
                switch(test) {
                    case "PROD":
                        currtype.Text = Resources.Retail;
                        break;
                    case "PNET":
                        currtype.Text = Resources.Devkit;
                        break;
                    default:
                        currtype.Text = Resources.Unknown;
                        break;
                }
                functions.Enabled = true;
                copycurrent.Enabled = true;
            }
            status.Text = Resources.CurrentInfoDone;
        }

        private void NewxuidTextChanged(object sender, EventArgs e) {
            if(!VerifyGoodXUID(newxuid.Text)) {
                MessageBox.Show(Resources.BadXUID, Resources.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                modxuid.Enabled = false;
            }
            else
                modxuid.Enabled = true;
        }

        private void CopycurrentClick(object sender, EventArgs e) {
            newname.Text = currname.Text;
            if (VerifyGoodXUID(currxuid.Text))
                newxuid.Text = currxuid.Text;
            newtype.Text = currtype.Text;
            newsig.Text = currsig.Text;
        }

        private void MakeonlineClick(object sender, EventArgs e) {
            status.Text = Resources.MakingOnline;
            _data[0] = 0x20;
            SetBytes(ref _data, 0x00, 0x28, 0x50);
            PatchsigClick(null, null);
            PatchtypeClick(null, null);
            ClearPasscodeToolStripMenuItemClick(null, null);
            Array.Copy(_domain, 0, _data, 0x3C, _domain.Length);
            Array.Copy(_kerberosrealm, 0, _data, 0x50, _kerberosrealm.Length);
            SetBytes(ref _data, 0xFF, 0x68, 0x10);
            if (_data[0x29] != 0x09 && !VerifyGoodXUID(newxuid.Text)) {
                var tmp = new byte[8];
                tmp[1] = 0x09;
                var tmp2 = new byte[3];
                Random.NextBytes(tmp2);
                Array.Copy(tmp2, 0, tmp, 0x5, tmp2.Length);
                Array.Copy(tmp, 0, _data, 0x28, tmp.Length);
                var newid = ArrayToHex(ref _data, 0x28, 0x8);
                newxuid.Text = newid;
                MessageBox.Show(string.Format("Auto-Generated a new XUID for you, the new ID is: {0}", newid), Resources.NewIDGeneratedTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(_data[0x29] != 0x09)
                ModxuidClick(null, null);
            saveToolStripMenuItem.Enabled = true;
            makeoffline.Enabled = true;
            makeonline.Enabled = false;
            patchsig.Enabled = _data[0] == 0x30 || _data[0] == 0x20;
            patchtype.Enabled = patchsig.Enabled;
            status.Text = Resources.MakeOnlineDone;
            _open = true;
        }

        private void MakeofflineClick(object sender, EventArgs e) {
            status.Text = Resources.MakingOffline;
            _data[0] = 0x00;
            SetBytes(ref _data, 0x00, 0x28, 0x50);
            saveToolStripMenuItem.Enabled = true;
            makeoffline.Enabled = false;
            makeonline.Enabled = true;
            patchsig.Enabled = _data[0] == 0x30 || _data[0] == 0x20;
            patchtype.Enabled = patchsig.Enabled;
            status.Text = Resources.DoneMakingOffline;
            _open = true;
        }

        private void NewnameTextChanged(object sender, EventArgs e) {
            modname.Enabled = newname.Text.Length > 0;
        }

        private void ModxuidClick(object sender, EventArgs e) {
            if (VerifyGoodXUID(newxuid.Text)) {
                status.Text = Resources.PatchingXUID;
                var tmp = HexToArray(newxuid.Text);
                Array.Copy(tmp, 0, _data, 0x28, tmp.Length);
                saveToolStripMenuItem.Enabled = true;
                status.Text = Resources.XUIDPatchDone;
            }
            _open = true;
        }

        private static bool VerifyGoodXUID(string id) {
            return !string.IsNullOrEmpty(id) && (id.Length == 0x10 && id.StartsWith("0009", StringComparison.Ordinal));
        }

        private void GenxuidClick(object sender, EventArgs e) {
            status.Text = Resources.GeneratingXUID;
            var tmp = new byte[3];
            Random.NextBytes(tmp);
            newxuid.Text = Resources.DefaultXUIDStart;
            newxuid.Text = ArrayToHex(ref tmp);
            status.Text = Resources.XUIDGenDone;
        }

        private void ModnameClick(object sender, EventArgs e) {
            status.Text = Resources.PatchingAccName;
            var tmp = Encoding.Unicode.GetBytes(newname.Text);
            Array.Resize(ref tmp, 0x1D);
            Array.Copy(tmp, 0x0, _data, 0x9, 0x1D);
            saveToolStripMenuItem.Enabled = true;
            status.Text = Resources.PatchingAccNameDone;
            _open = true;
        }

        private static bool Isdecrypted(byte[] testdata) {
            if(testdata.Length > 0) {
                //var ret = true;
                //for(var i = 0x34; i < 0x38; i++)
                //    if(testdata[i] != 0x00)
                //        ret = false;
                //if(ret)
                //    return true;
                var test = Encoding.ASCII.GetString(testdata, 0x34, 0x4);
                return (test.Equals("\0\0\0\0") /* The bytes are 0x00... */ || test.Equals("PROD", StringComparison.CurrentCultureIgnoreCase) || test.Equals("PNET", StringComparison.CurrentCultureIgnoreCase));
            }
            return false;
        }

        private void Form1Load(object sender, EventArgs e) {
            var ver = Assembly.GetAssembly(typeof(Main)).GetName().Version;
            Text += string.Format("{0}.{1} (Build: {2})", ver.Major, ver.Minor, ver.Build);
            newtype.Items.Add(Resources.Retail);
            newtype.Items.Add(Resources.Devkit);
            newtype.Text = Resources.Retail;
            newsig.Items.Add(Resources.Silver);
            newsig.Items.Add(Resources.Gold);
            newsig.Items.Add(Resources.FamilyGold);
            newsig.Text = Resources.Gold;
        }

        private void PatchsigClick(object sender, EventArgs e) {
            status.Text = Resources.PatchingLiveSignature;
            switch(newsig.Text) {
                case "Silver":
                    Array.Copy(_silver, 0, _data, 0x30, _silver.Length);
                    break;
                case "Family Gold":
                    Array.Copy(_familygold, 0, _data, 0x30, _familygold.Length);
                    break;
                default:
                    Array.Copy(_gold, 0, _data, 0x30, _gold.Length);
                    break;
            }
            status.Text = Resources.PatchingLiveSignatureDone;
            _open = true;
        }

        private void PatchtypeClick(object sender, EventArgs e) {
            status.Text = Resources.PatchingAccType;
            Array.Copy(newtype.Text.Equals(Resources.Retail, StringComparison.CurrentCultureIgnoreCase) ? _retailacc : _devkitacc, 0, _data, 0x34, 0x4);
            status.Text = Resources.AccTypePatchDone;
            _open = true;
        }

        private void GetPasscodeToolStripMenuItemClick(object sender, EventArgs e) {
            var passcode = "";
            for(var i = 0x38; i < 0x3C; i++) {
                switch(_data[i]) {
                    case 0x00:
                        passcode = Resources.ERROR;
                        i = 0x3C;
                        break;
                    case 0x01:
                        passcode += " D-PAD Up";
                        break;
                    case 0x02:
                        passcode += " D-PAD Right";
                        break;
                    case 0x03:
                        passcode += " D-PAD Left";
                        break;
                    case 0x04:
                        passcode += " D-PAD Down";
                        break;
                    case 0x05:
                        passcode += " X Button (Blue)";
                        break;
                    case 0x06:
                        passcode += " Y Button (Yellow)";
                        break;
                    case 0x09:
                        passcode += " Left Trigger";
                        break;
                    case 0x0A:
                        passcode += " Right Trigger";
                        break;
                    case 0x0B:
                        passcode += " Left Bumper";
                        break;
                    case 0x0C:
                        passcode += " Right Bumper";
                        break;
                    default:
                        passcode += string.Format(" Unkown ({0:X2})", _data[i]);
                        break;
                }
            }
            MessageBox.Show(string.Format("Your passcode is: {0}", passcode), Resources.YourPasscodeIsTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearPasscodeToolStripMenuItemClick(object sender, EventArgs e) {
            status.Text = Resources.RemovingPasscode;
            SetBytes(ref _data, 0x00, 0x38, 0x4);
            _data[0] = 0x20;
            getPasscodeToolStripMenuItem.Enabled = false;
            clearPasscodeToolStripMenuItem.Enabled = false;
            status.Text = Resources.PassCodeRemoved;
            _open = true;
        }

        private void DecryptProfileToolStripMenuItemClick(object sender, EventArgs e) {
            decryptProfileToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = true;
            status.Text = Resources.TryingRetailKey;
            var crypto = new Crypto();
            var key = crypto.Retailkey;
            var test = Crypto.Decrypt(_data, key);
            if(Isdecrypted(test)) {
                _data = test;
                status.Text = Resources.DecryptedWithRetailKey;
                GetcurrentClick(null, null);
                encryptProfileToolStripMenuItem.Enabled = true;
                _open = true;
            }
            else {
                status.Text = Resources.TryingDevkitKey;
                key = crypto.Devkey;
                test = Crypto.Decrypt(_data, key);
                if(Isdecrypted(test)) {
                    _data = test;
                    GetcurrentClick(null, null);
                    status.Text = Resources.DecryptedWithDevkitKey;
                    encryptProfileToolStripMenuItem.Enabled = true;
                    _open = true;
                }
                else
                    status.Text = Resources.UnableToDecrypt;
            }
        }

        private void EncryptProfileToolStripMenuItemClick(object sender, EventArgs e) {
            encryptProfileToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = true;
            status.Text = Resources.EncryptingAccount;
            var key = new byte[0];
            var crypto = new Crypto();
            switch (Encoding.ASCII.GetString(_data, 0x34, 4))
            {
                case "PNET":
                    _data = Crypto.Encrypt(_data, crypto.Devkey);
                    break;
                case "PROD":
                    _data = Crypto.Encrypt(_data, crypto.Retailkey);
                    break;
                default:
                    switch (MessageBox.Show(Resources.UnableToDetermineAccType, Resources.RetailProfileTitle, MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            _data = Crypto.Encrypt(_data, crypto.Retailkey);
                            break;
                        case DialogResult.No:
                            _data = Crypto.Encrypt(_data, crypto.Devkey);
                            break;
                    }
                    break;
            }
            if(key.Length > 0)
                decryptProfileToolStripMenuItem.Enabled = true;
            else
                encryptProfileToolStripMenuItem.Enabled = true;
            status.Text = Resources.EncryptionComplete;
            _open = true;
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = _open && MessageBox.Show(Resources.ExitWithoutSaving, Resources.ExitWithoutSavingTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes;
        }
    }
}