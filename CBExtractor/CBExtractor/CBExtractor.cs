namespace CBExtractor {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;
    using global::CBExtractor.Properties;

    internal sealed partial class CBExtractor : Form {
        private List<string> _files;

        internal CBExtractor() {
            InitializeComponent();
        }

        private static UInt16 Swap16(UInt16 input) {
            return (UInt16) ((input & 0xFF00) >> 8 | (input & 0x00FF) << 8);
        }

        private static UInt32 Swap32(UInt32 input) {
            return (input & 0x000000FFU) << 24 | (input & 0x0000FF00U) << 8 | (input & 0x00FF0000U) >> 8 | (input & 0xFF000000U) >> 24;
        }

        private void CBExtractorDragEnter(object sender, DragEventArgs e) {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private static bool Verifynand(string file) {
            MainClass.SetStatus(string.Format("Verifying NAND image: {0}", file));
            try {
                using(var br = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read, FileShare.Read))) {
                    if(br.BaseStream.Length <= 2)
                        return false;
                    var tmp = br.ReadBytes(2);
                    var ret = ((tmp[0] == 0xFF) && (tmp[1] == 0x4F));
                    br.Close();
                    GC.Collect();
                    return ret;
                }
            }
            catch(IOException) {
                if(MessageBox.Show(string.Format("ERROR: Unable to verify that your image is a NAND\nThe file is probably beeing used by another software...\nClose any open programs that might be using\n\n{0}\n\nClick on Retry to try again, or Cancel to abort...", file), Resources.UnableToLoadNANDErrorLabel, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    return Verifynand(file);
            }
            return false;
        }

        private static bool HasSpare(string file) {
            MainClass.SetStatus(string.Format("Checking image for spare: {0}", file));
            try {
                byte[] tmp;
                using(var br = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read, FileShare.Read))) {
                    if(br.BaseStream.Length <= 0x630)
                        return false;
                    tmp = br.ReadBytes(0x630);
                    br.Close();
                }
                var ret = false;
                for(var i = 0; i < 0x630; i += 0x210) {
                    if(!CheckPageForSpare(ref tmp, i))
                        continue;
                    ret = true;
                    i = 0x630;
                }
                return ret;
            }
            catch(IOException) {
                if(MessageBox.Show(string.Format("ERROR: Unable to check if your NAND Image contains spare or not\nThe file is probably beeing used by another software...\nClose any open programs that might be using\n\n{0}\n\nClick on Retry to try again, or Cancel to abort...", file), @"ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    return HasSpare(file);
            }
            return false;
        }

        private static byte[] CalculateEDC(ref byte[] data, int offset) {
            UInt32 i, val = 0, v = 0;
            var count = 0;
            var edc = new byte[4];
            for(i = 0; i < 0x1066; i++) {
                if((i & 31) == 0) {
                    v = ~BitConverter.ToUInt32(data, (count + offset));
                    count += 4;
                }
                val ^= v & 1;
                v >>= 1;
                if((val & 1) != 0)
                    val ^= 0x6954559;
                val >>= 1;
            }
            val = ~val;
            edc[0] = (byte) (val << 6);
            edc[1] = (byte) ((val >> 2) & 0xFF);
            edc[2] = (byte) ((val >> 10) & 0xFF);
            edc[3] = (byte) ((val >> 18) & 0xFF);
            return edc;
        }

        private static bool CheckPageForSpare(ref byte[] data, int offset) {
            var edc = CalculateEDC(ref data, offset);
            offset += 0x20C;
            return ((edc[0] == (data[offset])) && (edc[1] == data[offset + 1]) && (edc[2] == data[offset + 2]) && (edc[3] == data[offset + 3]));
        }

        private void CBExtractorDragDrop(object sender, DragEventArgs e) {
            if(bw2.IsBusy) {
                MessageBox.Show(@"BE PATIENT!");
                return;
            }
            var fileList = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
            var que = new List<string>();
            foreach(var s in fileList) {
                if(Verifynand(s)) {
                    if(!bw.IsBusy)
                        bw.RunWorkerAsync(s);
                    else
                        que.Add(s);
                }
            }
            if(que.Count > 0)
                bw2.RunWorkerAsync(que);
        }

        private static uint GetCBVersion(string file, bool ecced) {
            MainClass.SetStatus("Grabbing CB version...");
            try {
                using(var br = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read, FileShare.Read))) {
                    byte[] tmp;
                    if(!ecced) {
                        if(br.BaseStream.Length <= 0x8000)
                            return 0;
                        br.BaseStream.Seek(0x8000, SeekOrigin.Begin);
                        tmp = br.ReadBytes(4);
                        if(tmp[0] != 0x43 && tmp[1] != 0x42)
                            return 0;
                        return Swap16(BitConverter.ToUInt16(tmp, 2));
                    }
                    if(br.BaseStream.Length <= 0x8400)
                        return 0;
                    br.BaseStream.Seek(0x8400, SeekOrigin.Begin);
                    tmp = br.ReadBytes(4);
                    if(tmp[0] != 0x43 && tmp[1] != 0x42)
                        return 0;
                    return Swap16(BitConverter.ToUInt16(tmp, 2));
                }
            }
            catch(IOException) {
                if(MessageBox.Show(@"ERROR: can't get CB version, try closing shit... try again? (retry)", Resources.UnableToLoadNANDErrorLabel, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    return GetCBVersion(file, ecced);
            }
            return 0;
        }

        private static bool ExtractCB(string file, string targetfolder, bool ecced, uint version) {
            try {
                using(var br = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read, FileShare.Read))) {
                    uint size;
                    byte[] data;
                    long pos;
                    if(ecced) {
                        MainClass.SetStatus(string.Format("Extracting CB_A {0}...", version));
                        br.BaseStream.Seek(0x8400, SeekOrigin.Begin);
                        data = br.ReadBytes(0x10);
                        br.BaseStream.Seek(0x8400, SeekOrigin.Begin);
                        size = Swap32(BitConverter.ToUInt32(data, 0xC));
                        var rawsize = (int) ((size / 0x200) * 0x210);
                        if(br.BaseStream.Length <= 0x8400 + rawsize) {
                            br.Close();
                            return false;
                        }
                        data = new byte[size];
                        for(var i = 0; i < size;) {
                            for(var j = 0; j < 0x200; j++) {
                                if(i == size)
                                    break;
                                data[i] = br.ReadByte();
                                i++;
                            }
                            if(i == size)
                                break;
                            for(var j = 0; j < 0x10; j++)
                                br.ReadByte();
                        }
                        File.WriteAllBytes(string.Format("{0}ENC_CB_A_{1}.bin", targetfolder, version), data);
                        File.WriteAllText(string.Format("{0}ENC_CB_A_{1}.bin_src.txt", targetfolder, version), file);
                        pos = br.BaseStream.Position;
                        data = br.ReadBytes(0x10);
                        if(data[0] != 0x43 && data[1] != 0x42) {
                            br.Close();
                            return false;
                        }
                        MainClass.SetStatus(string.Format("Extracting CB_B {0}...", version));
                        br.BaseStream.Seek(pos, SeekOrigin.Begin);
                        size = Swap32(BitConverter.ToUInt32(data, 0xC));
                        rawsize = (int) ((size / 0x200) * 0x210);
                        if(br.BaseStream.Length <= pos + rawsize)
                            return true;
                        data = new byte[size];
                        for(var i = 0; i < size; i += 0x200) {
                            for(var j = 0; j < 0x200; j++) {
                                if(i == size)
                                    break;
                                data[i] = br.ReadByte();
                                i++;
                            }
                            if(i == size)
                                break;
                            for(var j = 0; j < 0x10; j++)
                                br.ReadByte();
                        }
                        br.Close();
                        File.WriteAllBytes(string.Format("{0}ENC_CB_B_{1}.bin", targetfolder, version), data);
                        return true;
                    }

                    MainClass.SetStatus(string.Format("Extracting CB_A {0}...", version));
                    br.BaseStream.Seek(0x8000, SeekOrigin.Begin);
                    data = br.ReadBytes(0x10);
                    br.BaseStream.Seek(0x8000, SeekOrigin.Begin);
                    size = Swap32(BitConverter.ToUInt32(data, 0xC));
                    if(br.BaseStream.Length <= 0x8000 + size) {
                        br.Close();
                        return false;
                    }
                    data = br.ReadBytes((int) size);
                    File.WriteAllBytes(string.Format("{0}ENC_CB_A_{1}.bin", targetfolder, version), data);
                    File.WriteAllText(string.Format("{0}ENC_CB_A_{1}.bin_src.txt", targetfolder, version), file);
                    pos = br.BaseStream.Position;
                    data = br.ReadBytes(0x10);
                    if(data[0] != 0x43 && data[1] != 0x42) {
                        br.Close();
                        return false;
                    }
                    MainClass.SetStatus(string.Format("Extracting CB_B {0}...", version));
                    br.BaseStream.Seek(pos, SeekOrigin.Begin);
                    size = Swap32(BitConverter.ToUInt32(data, 0xC));

                    if(br.BaseStream.Length <= pos + size)
                        return true;
                    data = br.ReadBytes((int) size);
                    br.Close();
                    File.WriteAllBytes(string.Format("{0}ENC_CB_B_{1}.bin", targetfolder, version), data);
                    return true;
                }
            }
            catch(IOException) {
                if(MessageBox.Show(@"ERROR: Can't extract... try closing shit... try again? (retry)", Resources.UnableToLoadNANDErrorLabel, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    return ExtractCB(file, targetfolder, ecced, version);
            }
            return false;
        }

        private void CBExtractorLoad(object sender, EventArgs e) {
            MainClass.SetStatus("Waiting for user input...");
        }

        private void BwDoWork(object sender, DoWorkEventArgs e) {
            var file = e.Argument as string;
            var ecced = HasSpare(file);
            var cb = GetCBVersion(file, ecced);
            if(cb == 0)
                return;
            var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            if(directoryName == null)
                return;
            var targetfolder = directoryName.Substring(6) + "\\Output\\";
            Directory.CreateDirectory(targetfolder);
            if(!File.Exists(string.Format("{0}ENC_CB_A_{1}.bin", targetfolder, cb)))
                ExtractCB(file, targetfolder, ecced, cb);
            MainClass.SetStatus("Done!");
        }

        private void Bw2DoWork(object sender, DoWorkEventArgs e) {
            var list = e.Argument as List<string>;
            if(list == null)
                return;
            foreach(var s in list) {
                bw.RunWorkerAsync(s);
                while(bw.IsBusy)
                    Thread.Sleep(100);
            }
        }

        private void Button1Click(object sender, EventArgs e) {
            var fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() != DialogResult.OK)
                return;
            button1.Enabled = false;
            scanner.RunWorkerAsync(fbd.SelectedPath);
        }

        private void ScannerDoWork(object sender, DoWorkEventArgs e) {
            _files = new List<string>();
            ScanFolders(e.Argument as string);
            var que = new List<string>();
            foreach(var s in _files) {
                if(Verifynand(s))
                    que.Add(s);
            }
            if(bw2.IsBusy) {
                while(bw2.IsBusy)
                    Thread.Sleep(100);
            }
            bw2.RunWorkerAsync(que);
            while(bw2.IsBusy)
                Thread.Sleep(100);
        }

        private void ScanFolders(string source) {
            foreach(var f in Directory.GetFiles(source))
                _files.Add(f);
            foreach(var d in Directory.GetDirectories(source))
                ScanFolders(d);
        }

        private void ScannerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            button1.Enabled = true;
        }
    }
}