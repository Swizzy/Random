namespace GhostBlockDumper {
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;

    internal sealed partial class Main : Form {
        private const string Version = "1.0";
        private static readonly string Dir = Directory.GetCurrentDirectory();
        private static RichTextBox _rtb;
        private static ProgressBar _pb;
        private static Process _proc;

        internal Main() {
            InitializeComponent();
        }

        private void MainLoad(object sender, EventArgs e) {
            Text = string.Format("{0} {1}", Text, Version);
            _rtb = outlog;
            _pb = running;
            times.Text = @"3";
        }

        private void ClosebtnClick(object sender, EventArgs e) {
            Application.Exit();
        }

        private void BlockKeyPress(object sender, KeyPressEventArgs e) {
            if(e.KeyChar != '\b')
                e.Handled = !Uri.IsHexDigit(e.KeyChar);
        }

        private string[] Data() {
            var ret = new string[4];

            foreach(Control con in Controls) {
                if(!(con is GroupBox))
                    continue;
                var group = con as GroupBox;
                switch(@group.Name) {
                    case "size":
                        foreach(Control nand in @group.Controls) {
                            if(!(nand is RadioButton))
                                continue;
                            var radio = nand as RadioButton;
                            if(!radio.Checked)
                                continue;
                            ret[0] = radio.Text;
                            if(ret[0].Equals("16mb", StringComparison.CurrentCultureIgnoreCase))
                                ret[0] = "3FF";
                            else
                                ret[0] = "FFF";
                        }
                        break;
                    case "device":
                        foreach(Control dumpdev in @group.Controls) {
                            if(!(dumpdev is RadioButton))
                                continue;
                            var radio = dumpdev as RadioButton;
                            if(radio.Checked)
                                ret[1] = radio.Name;
                        }
                        break;
                }
            }
            ret[2] = times.Text;
            ret[3] = block.Text;
            return ret;
        }

        private void DumpbtnClick(object sender, EventArgs e) {
            try {
                _rtb.Text = "";
                var error = 0;
                var req = Data();
                for(var i = 0; i < 3; i++) {
                    if((req[i] != "") && (req[i] != null))
                        continue;
                    error++;
                    switch(i) {
                        case 0:
                            SetText("ERROR: Please specify what nand-size your motherboard have!");
                            break;
                        case 1:
                            SetText("ERROR: Please specify what device you will be using!");
                            break;
                        case 2:
                            SetText("ERROR: Please specify how many times to dump nand!");
                            break;
                        case 3:
                            SetText("ERROR: Please specify how many times to dump nand!");
                            break;
                    }
                }
                if(req[3] == "0") {
                    SetText("ERROR: You cannot select block 0, this is a CRITICAL bootloader block, if it's bad... so is your console...");
                    error++;
                }
                else if(req[3] == req[0]) {
                    SetText("ERROR: You cannot select block " + req[0] + ", if it's bad... so is your console...");
                    error++;
                }
                if(error == 0) {
                    var test = int.Parse(req[0], NumberStyles.HexNumber);
                    var test2 = int.Parse(req[3], NumberStyles.HexNumber);
                    test++;
                    if(test < test2) {
                        error++;
                        SetText("ERROR: You cannot select a block which doesn't exist in your nand!");
                    }
                }
                if(error == 0) {
                    dumpbtn.Enabled = false;
                    var sz = req[0] == "3FF" ? "16" : "66";
                    var cnt = Convert.ToInt32(req[2]);
                    var badstart = int.Parse(req[3], NumberStyles.HexNumber);
                    badstart++;
                    var badmax = int.Parse(req[0], NumberStyles.HexNumber);
                    badmax++;
                    var badend = badmax - badstart;
                    var nandver = "";
                    SetText("Dumping your nand (this may take a while):\n\n");
                    for(var i = 1; i <= cnt; i++) {
                        Nandpro(req[1] + ": -r" + sz + " orig" + i + "a.bin 0 " + req[3], nandver);
                        if(!File.Exists(Dir + "\\orig" + i + "a.bin"))
                            SetText("ERROR: Unable to dump nand:");
                        using(var sr = new StreamReader(Dir + "\\debuglog.txt")) {
                            SetText("Nandpro log:\n");
                            var txt = "";
                            while(txt != null) {
                                txt = sr.ReadLine();
                                if(txt != null)
                                    SetText(txt);
                            }
                            SetText("\n");
                            sr.Close();
                        }
                        Nandpro(req[1] + ": -r" + sz + " orig" + i + "b.bin " + badstart.ToString("X") + " " + badend.ToString("X"), nandver);
                        if(!File.Exists(Dir + "\\orig" + i + "b.bin"))
                            SetText("ERROR: Unable to dump nand:");
                        using(var sr = new StreamReader(Dir + "\\debuglog.txt")) {
                            var txt = "";
                            while(txt != null) {
                                txt = sr.ReadLine();
                                if(txt != null)
                                    SetText(txt);
                            }
                            SetText("\n");
                            sr.Close();
                        }
                    }
                    if((File.Exists(Dir + "\\orig1a.bin")) && (File.Exists(Dir + "\\orig1b.bin"))) {
                        SetText("Building full image(s):\n\n");
                        nandver = "2b";
                        error = 0;
                        for(var i = 1; i <= cnt; i++) {
                            try {
                                File.Copy(Dir + "\\files\\dummy" + sz + ".bin", Dir + "\\orig" + i + ".bin", true);
                            }
                            catch {
                                SetText("ERROR: Unable to copy dummy files! aborting!");
                                error++;
                            }
                            if(error == 0) {
                                Nandpro("orig" + i + ".bin" + ": -w" + sz + " orig" + i + "a.bin 0 ", nandver);
                                SetText("\n");
                                Nandpro("orig" + i + ".bin" + ": -w" + sz + " orig" + i + "b.bin " + badstart.ToString("X"), nandver);
                            }
                        }
                    }
                    if((cnt > 1) && (error == 0)) {
                        SetText("\n");
                        SetText("Checking dumps...");
                        var j = 0;
                        for(var i = 1; i <= cnt; i++) {
                            if(File.Exists(Dir + "\\orig" + j + ".bin")) {
                                var result = FileCompare(Dir + "\\orig" + i + ".bin", Dir + "\\orig" + j + ".bin");
                                SetText(result ? string.Format("dump {0} Matches dump {1}", j, i) : string.Format("dump{0} does NOT match dump{1}", j, i));
                            }
                            j++;
                        }
                    }
                }
                dumpbtn.Enabled = true;
            }
            catch {
            }
        }

        private void Nandpro(string arguments, string version) {
            SetText("Nandpro" + version + " " + arguments);
            var nandpro = new Process { StartInfo = { FileName = Dir + "\\files\\nandpro" + version + ".exe", Arguments = arguments, WorkingDirectory = Dir + "\\", UseShellExecute = false, CreateNoWindow = true } };
            nandpro.Start();
            _proc = nandpro;
            var sleeper = new Thread(Sleep);
            sleeper.Start();
            while(!nandpro.HasExited) {
                Application.DoEvents();
                Thread.Sleep(100);
            }
            Thread.Sleep(100);
            running.Value = 0;
        }

        private static void Sleep() {
            while(!_proc.HasExited) {
                Thread.Sleep(100);
                SetVal(0);
            }
        }

        private static void SetText(string text) {
            try {
                if(_rtb.InvokeRequired) {
                    var d = new SetTextCallback(SetText);
                    _rtb.Invoke(d, new object[] { text });
                }
                else {
                    if(!text.EndsWith("\n", StringComparison.Ordinal))
                        _rtb.AppendText(text + "\n");
                    else
                        _rtb.AppendText(text);
                    _rtb.SelectionStart = _rtb.Text.Length;
                    _rtb.ScrollToCaret();
                }
            }
            catch {
            }
        }

        private static void SetVal(int val) {
            try {
                if(_pb.InvokeRequired) {
                    var d = new SetValCallback(SetVal);
                    _pb.Invoke(d, new object[] { val });
                }
                else {
                    if(_pb.Value == 100)
                        _pb.Value = 0;
                    else
                        _pb.Value = _pb.Value + 1;
                }
            }
            catch {
            }
        }

        private static bool FileCompare(string file1, string file2) {
            int file1Byte;
            int file2Byte;
            if(file1 == file2)
                return true;
            var fs1 = new FileStream(file1, FileMode.Open);
            var fs2 = new FileStream(file2, FileMode.Open);
            if(fs1.Length != fs2.Length) {
                fs1.Close();
                fs2.Close();
                return false;
            }
            do {
                file1Byte = fs1.ReadByte();
                file2Byte = fs2.ReadByte();
            }
            while((file1Byte == file2Byte) && (file1Byte != -1));
            fs1.Close();
            fs2.Close();
            return ((file1Byte - file2Byte) == 0);
        }

        #region Nested type: SetTextCallback

        private delegate void SetTextCallback(string text);

        #endregion

        #region Nested type: SetValCallback

        private delegate void SetValCallback(int val);

        #endregion
    }
}