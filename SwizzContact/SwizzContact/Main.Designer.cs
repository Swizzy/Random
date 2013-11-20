namespace SwizzContact
{
    internal sealed partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Mainmenu = new System.Windows.Forms.MenuStrip();
            this.disableAutoLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.list = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Country = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ZipCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Area = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Office = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mobile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Home = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Company = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Other = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.companybox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.otherbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.officebox = new System.Windows.Forms.TextBox();
            this.namebox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.adressbox = new System.Windows.Forms.TextBox();
            this.areabox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.zipbox = new System.Windows.Forms.TextBox();
            this.homebox = new System.Windows.Forms.TextBox();
            this.emailbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mobilebox = new System.Windows.Forms.TextBox();
            this.countrybox = new System.Windows.Forms.TextBox();
            this.listmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swizzContactDatabase = new SwizzContact.SwizzContactDatabase();
            this.swizzContactDatabaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Mainmenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.listmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.swizzContactDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swizzContactDatabaseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Mainmenu
            // 
            this.Mainmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disableAutoLoadToolStripMenuItem,
            this.reloadListToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.addContactToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.Mainmenu.Location = new System.Drawing.Point(0, 0);
            this.Mainmenu.Name = "Mainmenu";
            this.Mainmenu.Size = new System.Drawing.Size(794, 24);
            this.Mainmenu.TabIndex = 7;
            this.Mainmenu.Text = "menuStrip1";
            // 
            // disableAutoLoadToolStripMenuItem
            // 
            this.disableAutoLoadToolStripMenuItem.Name = "disableAutoLoadToolStripMenuItem";
            this.disableAutoLoadToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.disableAutoLoadToolStripMenuItem.Text = "Disable Autoload";
            this.disableAutoLoadToolStripMenuItem.Click += new System.EventHandler(this.DisableAutoLoadToolStripMenuItemClick);
            // 
            // reloadListToolStripMenuItem
            // 
            this.reloadListToolStripMenuItem.Name = "reloadListToolStripMenuItem";
            this.reloadListToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reloadListToolStripMenuItem.Text = "Show All";
            this.reloadListToolStripMenuItem.Click += new System.EventHandler(this.ReloadListToolStripMenuItemClick);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.searchToolStripMenuItem.Text = "Filter";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItemClick);
            // 
            // addContactToolStripMenuItem
            // 
            this.addContactToolStripMenuItem.Name = "addContactToolStripMenuItem";
            this.addContactToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.addContactToolStripMenuItem.Text = "Add Contact";
            this.addContactToolStripMenuItem.Click += new System.EventHandler(this.AddContactToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // list
            // 
            this.list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.Cname,
            this.Email,
            this.Country,
            this.Address,
            this.ZipCode,
            this.Area,
            this.Office,
            this.Mobile,
            this.Home,
            this.Company,
            this.Other});
            this.list.FullRowSelect = true;
            this.list.GridLines = true;
            this.list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.list.HideSelection = false;
            this.list.Location = new System.Drawing.Point(12, 156);
            this.list.MultiSelect = false;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(770, 186);
            this.list.TabIndex = 8;
            this.list.UseCompatibleStateImageBehavior = false;
            this.list.View = System.Windows.Forms.View.Details;
            this.list.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListChanged);
            this.list.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListMouseClick);
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 30;
            // 
            // Cname
            // 
            this.Cname.Text = "Name";
            // 
            // Email
            // 
            this.Email.Text = "E-Mail";
            // 
            // Country
            // 
            this.Country.Text = "Country";
            // 
            // Address
            // 
            this.Address.Text = "Address";
            // 
            // ZipCode
            // 
            this.ZipCode.Text = "Zip-Code";
            // 
            // Area
            // 
            this.Area.Text = "Area";
            // 
            // Office
            // 
            this.Office.Text = "Office";
            // 
            // Mobile
            // 
            this.Mobile.Text = "Mobile";
            // 
            // Home
            // 
            this.Home.Text = "Home";
            // 
            // Company
            // 
            this.Company.Text = "Company";
            // 
            // Other
            // 
            this.Other.Text = "Other";
            this.Other.Width = 142;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.companybox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.otherbox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.officebox);
            this.groupBox1.Controls.Add(this.namebox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.adressbox);
            this.groupBox1.Controls.Add(this.areabox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.zipbox);
            this.groupBox1.Controls.Add(this.homebox);
            this.groupBox1.Controls.Add(this.emailbox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.mobilebox);
            this.groupBox1.Controls.Add(this.countrybox);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(770, 123);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected";
            // 
            // companybox
            // 
            this.companybox.Location = new System.Drawing.Point(66, 97);
            this.companybox.Name = "companybox";
            this.companybox.ReadOnly = true;
            this.companybox.Size = new System.Drawing.Size(123, 20);
            this.companybox.TabIndex = 55;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 60;
            this.label11.Text = "Company:";
            // 
            // otherbox
            // 
            this.otherbox.Location = new System.Drawing.Point(564, 19);
            this.otherbox.Multiline = true;
            this.otherbox.Name = "otherbox";
            this.otherbox.ReadOnly = true;
            this.otherbox.Size = new System.Drawing.Size(200, 98);
            this.otherbox.TabIndex = 56;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(489, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 64;
            this.label10.Text = "Other/Notes:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Office:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(383, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 65;
            this.label8.Text = "Country:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "E-Mail:";
            // 
            // officebox
            // 
            this.officebox.Location = new System.Drawing.Point(66, 71);
            this.officebox.Name = "officebox";
            this.officebox.ReadOnly = true;
            this.officebox.Size = new System.Drawing.Size(123, 20);
            this.officebox.TabIndex = 52;
            // 
            // namebox
            // 
            this.namebox.Location = new System.Drawing.Point(66, 19);
            this.namebox.Name = "namebox";
            this.namebox.ReadOnly = true;
            this.namebox.Size = new System.Drawing.Size(123, 20);
            this.namebox.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(391, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 67;
            this.label9.Text = "Home:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Mobile:";
            // 
            // adressbox
            // 
            this.adressbox.Location = new System.Drawing.Point(66, 45);
            this.adressbox.Name = "adressbox";
            this.adressbox.ReadOnly = true;
            this.adressbox.Size = new System.Drawing.Size(123, 20);
            this.adressbox.TabIndex = 49;
            // 
            // areabox
            // 
            this.areabox.Location = new System.Drawing.Point(435, 45);
            this.areabox.Name = "areabox";
            this.areabox.ReadOnly = true;
            this.areabox.Size = new System.Drawing.Size(123, 20);
            this.areabox.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(397, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "Area:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Zip-Code:";
            // 
            // zipbox
            // 
            this.zipbox.Location = new System.Drawing.Point(254, 45);
            this.zipbox.Name = "zipbox";
            this.zipbox.ReadOnly = true;
            this.zipbox.Size = new System.Drawing.Size(123, 20);
            this.zipbox.TabIndex = 50;
            // 
            // homebox
            // 
            this.homebox.Location = new System.Drawing.Point(435, 71);
            this.homebox.Name = "homebox";
            this.homebox.ReadOnly = true;
            this.homebox.Size = new System.Drawing.Size(123, 20);
            this.homebox.TabIndex = 54;
            // 
            // emailbox
            // 
            this.emailbox.Location = new System.Drawing.Point(254, 19);
            this.emailbox.Name = "emailbox";
            this.emailbox.ReadOnly = true;
            this.emailbox.Size = new System.Drawing.Size(123, 20);
            this.emailbox.TabIndex = 47;
            this.emailbox.DoubleClick += new System.EventHandler(this.EmailboxDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Address:";
            // 
            // mobilebox
            // 
            this.mobilebox.Location = new System.Drawing.Point(254, 71);
            this.mobilebox.Name = "mobilebox";
            this.mobilebox.ReadOnly = true;
            this.mobilebox.Size = new System.Drawing.Size(123, 20);
            this.mobilebox.TabIndex = 53;
            // 
            // countrybox
            // 
            this.countrybox.Location = new System.Drawing.Point(435, 19);
            this.countrybox.Name = "countrybox";
            this.countrybox.ReadOnly = true;
            this.countrybox.Size = new System.Drawing.Size(123, 20);
            this.countrybox.TabIndex = 48;
            // 
            // listmenu
            // 
            this.listmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.listmenu.Name = "listmenu";
            this.listmenu.ShowItemToolTips = false;
            this.listmenu.Size = new System.Drawing.Size(118, 48);
            this.listmenu.Opening += new System.ComponentModel.CancelEventHandler(this.ListmenuOpening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItemClick);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItemClick);
            // 
            // swizzContactDatabase
            // 
            this.swizzContactDatabase.DataSetName = "SwizzContactDatabase";
            this.swizzContactDatabase.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // swizzContactDatabaseBindingSource
            // 
            this.swizzContactDatabaseBindingSource.DataSource = this.swizzContactDatabase;
            this.swizzContactDatabaseBindingSource.Position = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(794, 353);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.list);
            this.Controls.Add(this.Mainmenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Trust-IT Contacts by Swizzy";
            this.Mainmenu.ResumeLayout(false);
            this.Mainmenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.listmenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.swizzContactDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swizzContactDatabaseBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Mainmenu;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addContactToolStripMenuItem;
        private SwizzContactDatabase swizzContactDatabase;
        private System.Windows.Forms.BindingSource swizzContactDatabaseBindingSource;
        private System.Windows.Forms.ListView list;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox companybox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox otherbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox officebox;
        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox adressbox;
        private System.Windows.Forms.TextBox areabox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox zipbox;
        private System.Windows.Forms.TextBox homebox;
        private System.Windows.Forms.TextBox emailbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mobilebox;
        private System.Windows.Forms.TextBox countrybox;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader Cname;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Country;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.ColumnHeader ZipCode;
        private System.Windows.Forms.ColumnHeader Area;
        private System.Windows.Forms.ColumnHeader Office;
        private System.Windows.Forms.ColumnHeader Mobile;
        private System.Windows.Forms.ColumnHeader Home;
        private System.Windows.Forms.ColumnHeader Other;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadListToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Company;
        private System.Windows.Forms.ContextMenuStrip listmenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableAutoLoadToolStripMenuItem;
    }
}

