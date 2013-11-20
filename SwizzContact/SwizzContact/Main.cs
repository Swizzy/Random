namespace SwizzContact {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;
    using SwizzContact.Properties;

    internal sealed partial class Main : Form {
        internal static Sqlmanager Sql;
        internal static ListView List;
        internal static string Appdatadir;

        internal Main() {
            InitializeComponent();
            List = list;
            Icon = Resources.icon;
            Appdatadir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\SwizzContact";
            Directory.CreateDirectory(Appdatadir);
            if(!File.Exists(Appdatadir + "\\contacts.sdf") || !File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\contacts.sdf"))
                Generatedb();
            Sql = File.Exists(Appdatadir + "\\contacts.sdf") ? new Sqlmanager(Appdatadir) : new Sqlmanager("|DataDirectory|");
            if(GetAutoloadState())
                return;
            var worker = new Thread(Showall);
            worker.Start();
        }

        private void AddContactToolStripMenuItemClick(object sender, EventArgs e) {
            var isopen = false;
            foreach(Form a in Application.OpenForms) {
                if(!(a is AddForm))
                    continue;
                isopen = true;
                Showform(a);
            }
            if(isopen)
                return;
            var form = new AddForm();
            form.Show();
        }

        private static void Showform(Form a) {
            a.Visible = true;
            a.TopMost = true;
            a.Focus();
            a.BringToFront();
            a.TopMost = false;
        }

        private void SearchToolStripMenuItemClick(object sender, EventArgs e) {
            var isopen = false;
            foreach(Form a in Application.OpenForms) {
                if(!(a is Filter))
                    continue;
                isopen = true;
                Showform(a);
            }
            if(isopen)
                return;
            var form = new Filter();
            form.Show();
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e) {
            Close();
        }

        private void ReloadListToolStripMenuItemClick(object sender, EventArgs e) {
            Showall();
        }

        private static void Showall() {
            Sql = File.Exists(Appdatadir + "\\contacts.sdf") ? new Sqlmanager(Appdatadir) : new Sqlmanager("|DataDirectory|");
            if(List.InvokeRequired) {
                var d = new Additem(UpdateList);
                List.Invoke(d, new object[] { Sql.GetData(), true });
            }
            else
                UpdateList(Sql.GetData());
        }

        public static void ShowLast(bool update = false, string id = "") {
            if(update) {
                foreach(var e in List.Items) {
                    if(!(e is ListViewItem))
                        continue;
                    var lvi = e as ListViewItem;
                    if(lvi.Text == id)
                        List.Items.Remove(lvi);
                }
            }
            UpdateList(Sql.GetLast(), false);
        }

        private static void Generatedb() {
            var fi = new FileInfo(Appdatadir + "\\contacts.sdf");
            if((!fi.Exists) || (fi.Length == 0)) {
                var toexe = fi.OpenWrite();
                var fromexe = Assembly.GetExecutingAssembly().GetManifestResourceStream("SwizzContact.Contacts.sdf");
                const int size = 4096;
                var bytes = new byte[size];
                int numBytes;
                while(fromexe != null && (numBytes = fromexe.Read(bytes, 0, size)) > 0)
                    toexe.Write(bytes, 0, numBytes);
                toexe.Close();
                if(fromexe != null)
                    fromexe.Close();
            }
        }

        public static void UpdateList(IEnumerable<Sqlmanager.Dbentry> ret, bool reset = true) {
            if(reset)
                List.Items.Clear();
            foreach(var db in ret) {
                var tmp = new ListViewItem(db.Id);
                tmp.SubItems.Add(!string.IsNullOrEmpty(db.Name.Trim()) ? db.Name.Trim() : "");
                tmp.SubItems.Add(!string.IsNullOrEmpty(db.Email.Trim()) ? db.Email.Trim() : "");
                tmp.SubItems.Add(!string.IsNullOrEmpty(db.Country.Trim()) ? db.Country.Trim() : "");
                tmp.SubItems.Add(!string.IsNullOrEmpty(db.Adress.Trim()) ? db.Adress.Trim() : "");
                tmp.SubItems.Add(!string.IsNullOrEmpty(db.Zipcode.Trim()) ? db.Zipcode.Trim() : "");
                tmp.SubItems.Add(!string.IsNullOrEmpty(db.Area.Trim()) ? db.Area.Trim() : "");
                tmp.SubItems.Add(!string.IsNullOrEmpty(db.Office) ? db.Office.Trim() : "");
                tmp.SubItems.Add(!string.IsNullOrEmpty(db.Mobile.Trim()) ? db.Mobile.Trim() : "");
                tmp.SubItems.Add(!string.IsNullOrEmpty(db.Home.Trim()) ? db.Home.Trim() : "");
                tmp.SubItems.Add(!string.IsNullOrEmpty(db.Company.Trim()) ? db.Company.Trim() : "");
                tmp.SubItems.Add(!string.IsNullOrEmpty(db.Other) ? db.Other.Trim().Replace(Environment.NewLine, "\\n") : "");
                List.Items.Add(tmp);
            }
            GC.Collect();
        }

        private void EditToolStripMenuItemClick(object sender, EventArgs e) {
            foreach(Form a in Application.OpenForms) {
                if(!(a is AddForm))
                    continue;
                a.Close();
            }
            var form = new AddForm(List.SelectedItems[0].Text, List.SelectedItems[0].SubItems[1].Text, List.SelectedItems[0].SubItems[2].Text, List.SelectedItems[0].SubItems[3].Text, List.SelectedItems[0].SubItems[4].Text, List.SelectedItems[0].SubItems[5].Text, List.SelectedItems[0].SubItems[6].Text, List.SelectedItems[0].SubItems[7].Text, List.SelectedItems[0].SubItems[8].Text, List.SelectedItems[0].SubItems[9].Text, List.SelectedItems[0].SubItems[10].Text, List.SelectedItems[0].SubItems[11].Text);
            form.Show();
        }

        private void ListMouseClick(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Right)
                listmenu.Show(List.PointToScreen(e.Location));
        }

        private void ListmenuOpening(object sender, CancelEventArgs e) {
            if(List.SelectedItems.Count == 0)
                e.Cancel = true;
        }

        private void RemoveToolStripMenuItemClick(object sender, EventArgs e) {
            if(MessageBox.Show(Resources.Warning_Delete_entry, Resources.Are_you_sure_title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            Sql.Deleteentry(List.SelectedItems[0].Text);
            Showall();
        }

        private void EmailboxDoubleClick(object sender, EventArgs e) {
            if(!IsValidEmail(emailbox.Text))
                return;
            Process.Start(string.Format("mailto:{0}", emailbox.Text));
        }

        private static bool IsValidEmail(string strIn) {
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        private void PictureBox1Click(object sender, EventArgs e) {
            Process.Start("http://www.trustit.se/");
        }

        private void DisableAutoLoadToolStripMenuItemClick(object sender, EventArgs e) {
            SetAutoloadState(!GetAutoloadState());
        }

        private bool GetAutoloadState() {
            try {
                var storage = IsolatedStorageFile.GetUserStoreForAssembly();
                var stream = new IsolatedStorageFileStream("autoload", FileMode.Open, storage);
                var reader = new StreamReader(stream);
                if(reader.ReadToEnd().Trim().Equals("true", StringComparison.CurrentCultureIgnoreCase)) {
                    reader.Close();
                    stream.Close();
                    storage.Close();
                    storage.Dispose();
                    GC.Collect();
                    disableAutoLoadToolStripMenuItem.Text = Resources.enableautoload;
                    return true;
                }
                reader.Close();
                stream.Close();
                storage.Close();
                storage.Dispose();
                GC.Collect();
            }
            catch {
            }
            disableAutoLoadToolStripMenuItem.Text = Resources.disableautoload;
            return false;
        }

        private void SetAutoloadState(bool newstate) {
            try {
                var storage = IsolatedStorageFile.GetUserStoreForAssembly();
                var stream = new IsolatedStorageFileStream("autoload", FileMode.OpenOrCreate, storage);
                var writer = new StreamWriter(stream);
                writer.WriteLine(newstate.ToString().ToLower());
                writer.Close();
                stream.Close();
                storage.Close();
                storage.Dispose();
                GC.Collect();
            }
            catch {
            }
            disableAutoLoadToolStripMenuItem.Text = newstate ? Resources.enableautoload : Resources.disableautoload;
        }

        private void ListChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if(List.SelectedItems.Count == 0)
                return;
            namebox.Text = List.SelectedItems[0].SubItems[1].Text;
            emailbox.Text = List.SelectedItems[0].SubItems[2].Text;
            countrybox.Text = List.SelectedItems[0].SubItems[3].Text;
            adressbox.Text = List.SelectedItems[0].SubItems[4].Text;
            zipbox.Text = List.SelectedItems[0].SubItems[5].Text;
            areabox.Text = List.SelectedItems[0].SubItems[6].Text;
            officebox.Text = List.SelectedItems[0].SubItems[7].Text;
            mobilebox.Text = List.SelectedItems[0].SubItems[8].Text;
            homebox.Text = List.SelectedItems[0].SubItems[9].Text;
            companybox.Text = List.SelectedItems[0].SubItems[10].Text;
            otherbox.Text = List.SelectedItems[0].SubItems[11].Text.Replace("\\n", Environment.NewLine);
        }

        #region Nested type: Additem

        private delegate void Additem(IEnumerable<Sqlmanager.Dbentry> ret, bool reset);

        #endregion
    }
}