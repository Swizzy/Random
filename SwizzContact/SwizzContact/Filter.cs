namespace SwizzContact {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;
    using SwizzContact.Properties;

    internal sealed partial class Filter : Form {
        internal Filter() {
            InitializeComponent();
            Icon = Resources.icon;
        }

        private void SavebtnClick(object sender = null, EventArgs e = null) {
            Main.Sql = File.Exists(Main.Appdatadir + "\\contacts.sdf") ? new Sqlmanager(Main.Appdatadir) : new Sqlmanager("|DataDirectory|");
            var thread = new Thread(SetFilter);
            thread.Start();
        }

        private void SetFilter() {
            var data = Main.Sql.GetFilterd(namebox.Text, emailbox.Text, countrybox.Text, adressbox.Text, zipbox.Text, areabox.Text, companybox.Text);
            if(Main.List.InvokeRequired) {
                var d = new Additem(Main.UpdateList);
                Main.List.Invoke(d, new object[] { data, true });
            }
            else
                Main.UpdateList(data);
            CloseWindow(true);
        }

        private void CloseWindow(bool close) {
            if(InvokeRequired) {
                var d = new Closer(CloseWindow);
                Invoke(d, close);
            }
            else
                Close();
        }

        private void ResetbtnClick(object sender, EventArgs e) {
            namebox.Text = "";
            emailbox.Text = "";
            countrybox.Text = "";
            adressbox.Text = "";
            zipbox.Text = "";
            areabox.Text = "";
            companybox.Text = "";
        }

        private void FilterEnter(object sender, KeyEventArgs e) {
            if(e.KeyData == Keys.Enter)
                SavebtnClick();
        }

        #region Nested type: Additem

        private delegate void Additem(IEnumerable<Sqlmanager.Dbentry> ret, bool reset);

        #endregion

        #region Nested type: Closer

        private delegate void Closer(bool close);

        #endregion
    }
}