namespace SwizzContact
{
    internal sealed partial class Filter
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.zipbox = new System.Windows.Forms.TextBox();
            this.adressbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.emailbox = new System.Windows.Forms.TextBox();
            this.countrybox = new System.Windows.Forms.TextBox();
            this.areabox = new System.Windows.Forms.TextBox();
            this.namebox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.companybox = new System.Windows.Forms.TextBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.resetbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Zip-Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Address:";
            // 
            // zipbox
            // 
            this.zipbox.Location = new System.Drawing.Point(256, 32);
            this.zipbox.MaxLength = 20;
            this.zipbox.Name = "zipbox";
            this.zipbox.Size = new System.Drawing.Size(123, 20);
            this.zipbox.TabIndex = 4;
            this.zipbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterEnter);
            // 
            // adressbox
            // 
            this.adressbox.Location = new System.Drawing.Point(68, 32);
            this.adressbox.MaxLength = 200;
            this.adressbox.Name = "adressbox";
            this.adressbox.Size = new System.Drawing.Size(123, 20);
            this.adressbox.TabIndex = 3;
            this.adressbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterEnter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(385, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Country:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(399, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Area:";
            // 
            // emailbox
            // 
            this.emailbox.Location = new System.Drawing.Point(256, 6);
            this.emailbox.MaxLength = 200;
            this.emailbox.Name = "emailbox";
            this.emailbox.Size = new System.Drawing.Size(123, 20);
            this.emailbox.TabIndex = 1;
            this.emailbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterEnter);
            // 
            // countrybox
            // 
            this.countrybox.Location = new System.Drawing.Point(437, 6);
            this.countrybox.MaxLength = 100;
            this.countrybox.Name = "countrybox";
            this.countrybox.Size = new System.Drawing.Size(123, 20);
            this.countrybox.TabIndex = 2;
            this.countrybox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterEnter);
            // 
            // areabox
            // 
            this.areabox.Location = new System.Drawing.Point(437, 32);
            this.areabox.MaxLength = 200;
            this.areabox.Name = "areabox";
            this.areabox.Size = new System.Drawing.Size(123, 20);
            this.areabox.TabIndex = 5;
            this.areabox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterEnter);
            // 
            // namebox
            // 
            this.namebox.Location = new System.Drawing.Point(68, 6);
            this.namebox.MaxLength = 100;
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(123, 20);
            this.namebox.TabIndex = 0;
            this.namebox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "E-Mail:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Company:";
            // 
            // companybox
            // 
            this.companybox.Location = new System.Drawing.Point(68, 58);
            this.companybox.MaxLength = 300;
            this.companybox.Name = "companybox";
            this.companybox.Size = new System.Drawing.Size(123, 20);
            this.companybox.TabIndex = 9;
            this.companybox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterEnter);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(11, 84);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(548, 46);
            this.savebtn.TabIndex = 11;
            this.savebtn.Text = "Apply Filter";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.SavebtnClick);
            // 
            // resetbtn
            // 
            this.resetbtn.Location = new System.Drawing.Point(12, 136);
            this.resetbtn.Name = "resetbtn";
            this.resetbtn.Size = new System.Drawing.Size(548, 46);
            this.resetbtn.TabIndex = 12;
            this.resetbtn.Text = "Reset";
            this.resetbtn.UseVisualStyleBackColor = true;
            this.resetbtn.Click += new System.EventHandler(this.ResetbtnClick);
            // 
            // Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(572, 194);
            this.Controls.Add(this.resetbtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.companybox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.namebox);
            this.Controls.Add(this.areabox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.countrybox);
            this.Controls.Add(this.emailbox);
            this.Controls.Add(this.zipbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.adressbox);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Filter";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Trust-IT Contacts Filter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox zipbox;
        private System.Windows.Forms.TextBox adressbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox emailbox;
        private System.Windows.Forms.TextBox countrybox;
        private System.Windows.Forms.TextBox areabox;
        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox companybox;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button resetbtn;

    }
}