using System;
using System.Windows.Forms;

namespace CPUKey_Checker
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Threading;

    public partial class Form1 : Form
    {
        static readonly List<string> Verified = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void CheckbtnClick(object sender, EventArgs e) {
            MessageBox.Show(CPUKeyCheck.VerifyKey(keybox.Text) ? "It's OK!" : string.Format("ERROR: {0}", CPUKeyCheck.GetLastError()));
        }

        private static string StripNonHex(string input)
        {
            return Regex.Replace(input, "[^0-9A-Fa-f]", "");
        }

        private void KeyboxTextChanged(object sender, EventArgs e)
        {
            if (!(sender is TextBox))
                return;
            var tb = sender as TextBox;
            tb.Text = StripNonHex(tb.Text);
            tb.SelectionStart = tb.Text.Length;
            checkbtn.Enabled = tb.Text.Length == 32 && !bw.IsBusy;
        }

        private void KeyboxKeyDown(object sender, KeyEventArgs e)
        {
            if (!(sender is TextBox) || !e.Control || e.KeyCode != Keys.A)
                return;
            var tb = sender as TextBox;
            tb.SelectAll();
            e.Handled = true;
        }

        private void Form1DragEnter(object sender, DragEventArgs e) { e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None; }

        private void Form1DragDrop(object sender, DragEventArgs e)
        {
            var fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var file in fileList)
            {
                string key;
                if (!CPUKeyCheck.GetCPUKeyFromFile(file, out key))
                    continue;
                keybox.Text = key;
                return;
            }
        }

        private void ScanbtnClick(object sender, EventArgs e)
        {
            var fsd = new FolderSelectDialog();
            if (!fsd.ShowDialog())
                return;
            scanbtn.Enabled = false;
            AllowDrop = false;
            checkbtn.Enabled = false;
            keybox.Enabled = false;
            status.Text = "Scanning...";
            bw.RunWorkerAsync(fsd.FileName);
            while (bw.IsBusy) {
                Application.DoEvents();
                Thread.Sleep(100);
            }
            scanbtn.Enabled = true;
            AllowDrop = true;
            checkbtn.Enabled = true;
            keybox.Enabled = true;
            keybox.Text = "";
        }

        private static void ScanFolders(ref List<string> list, string src) {
            Program.SetStatus(string.Format("Scanning {0}", src));
            foreach (var file in Directory.GetFiles(src))
                CheckFile(ref list, file);
            foreach (var dir in Directory.GetDirectories(src))
                ScanFolders(ref list, dir);
        }

        private static void CheckFile(ref List<string> list, string src) {
            Program.SetStatus(string.Format("Checking {0}", src));
            string key;
            if (!CPUKeyCheck.GetCPUKeyFromFile(src, out key))
                return;
            Program.SetKey(key);
            if (CPUKeyCheck.VerifyKey(key)) {
                Verified.Add("Key: " + key + " File: " + src);
                return;
            }
            list.Add("Key: " + key + " File: " + src + " Fail reason: " + CPUKeyCheck.GetLastError());
        }

        private void BWDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Verified.Clear();
            if (!(e.Argument is string))
                return;
            var list = new List<string>();
            ScanFolders(ref list, e.Argument as string);
            e.Result = list;
        }

        private void BWRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            if (!(e.Result is List<string>))
            {
                MessageBox.Show("ERROR: Unkown error occured...");
                return;
            }
            var res = e.Result as List<string>;
            if (res.Count != 0) {
                if (MessageBox.Show(string.Format("{0} Keys passed verification and {1} Didn't... do you want to save the list of failed keys to check out which ones?", Verified.Count, res.Count), "Save failed keys?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    var sfd = new SaveFileDialog();
                    if (sfd.ShowDialog() == DialogResult.OK)
                        File.WriteAllLines(sfd.FileName, res.ToArray());
                    else
                        MessageBox.Show("Run it again... and press OK!");
                }
            }
            else
                MessageBox.Show(Verified.Count != 0 ? string.Format("{0} Keys verified (ALL are OK)", Verified.Count) : "No keys found!");
            if (Verified.Count > 0) {
                if (MessageBox.Show("Do you want to save the verified keys somewhere?", "Save verified keys?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    var sfd = new SaveFileDialog();
                    if (sfd.ShowDialog() == DialogResult.OK)
                        File.WriteAllLines(sfd.FileName, Verified.ToArray());
                }
            }
        }

        internal void SetStatus(string input) {
            using (var g = CreateGraphics())
            {
                var size = g.MeasureString(input, status.Font);
                Program.Form.Width = (int)Math.Ceiling(size.Width) + 8;
            }
            status.Text = input;
        }
    }
}
