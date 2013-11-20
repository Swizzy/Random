namespace SwizzContact {
    using System;
    using System.Windows.Forms;
    using SwizzContact.Properties;

    internal sealed partial class AddForm : Form {
        private string _id;

        internal AddForm(string id = "", string name = "", string email = "", string country = "", string adress = "", string zipcode = "", string area = "", string office = "", string mobile = "", string home = "", string company = "", string other = "") {
            InitializeComponent();
            Icon = Resources.icon;
            _id = id;
            namebox.Text = name;
            emailbox.Text = email;
            countrybox.Text = country;
            adressbox.Text = adress;
            zipbox.Text = zipcode;
            areabox.Text = area;
            officebox.Text = office;
            mobilebox.Text = mobile;
            homebox.Text = home;
            companybox.Text = company;
            otherbox.Text = other.Replace("\\n", Environment.NewLine);
        }

        private void ResetbtnClick(object sender = null, EventArgs e = null) {
            foreach(var c in Controls) {
                if(!(c is TextBox))
                    continue;
                var tb = c as TextBox;
                tb.Text = "";
            }
        }

        private void SavebtnClick(object sender, EventArgs e) {
            var data = new Sqlmanager.Dbentry { Id = _id, Name = namebox.Text, Email = emailbox.Text, Adress = adressbox.Text, Zipcode = zipbox.Text, Country = countrybox.Text, Area = areabox.Text, Office = officebox.Text, Mobile = mobilebox.Text, Home = homebox.Text, Company = companybox.Text, Other = otherbox.Text.Replace(Environment.NewLine, "\\n") };
            if(string.IsNullOrEmpty(_id))
                Main.Sql.AddContact(data);
            else {
                Main.Sql.UpdContact(data);
                Main.ShowLast(true, _id);
            }
            _id = "";
        }
    }
}