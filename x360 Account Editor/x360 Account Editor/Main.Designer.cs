namespace x360_Account_Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decryptProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getPasscodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPasscodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.getcurrent = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.currsig = new System.Windows.Forms.TextBox();
            this.currtype2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.currtype = new System.Windows.Forms.TextBox();
            this.currxuid = new System.Windows.Forms.TextBox();
            this.makeoffline = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.functions = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.newsig = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.newtype = new System.Windows.Forms.ComboBox();
            this.patchtype = new System.Windows.Forms.Button();
            this.genxuid = new System.Windows.Forms.Button();
            this.modxuid = new System.Windows.Forms.Button();
            this.modname = new System.Windows.Forms.Button();
            this.copycurrent = new System.Windows.Forms.Button();
            this.makeonline = new System.Windows.Forms.Button();
            this.patchsig = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.newxuid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.newname = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.functions.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(627, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decryptProfileToolStripMenuItem,
            this.encryptProfileToolStripMenuItem,
            this.getPasscodeToolStripMenuItem,
            this.clearPasscodeToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // decryptProfileToolStripMenuItem
            // 
            this.decryptProfileToolStripMenuItem.Enabled = false;
            this.decryptProfileToolStripMenuItem.Name = "decryptProfileToolStripMenuItem";
            this.decryptProfileToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.decryptProfileToolStripMenuItem.Text = "Decrypt Profile";
            this.decryptProfileToolStripMenuItem.Click += new System.EventHandler(this.DecryptProfileToolStripMenuItemClick);
            // 
            // encryptProfileToolStripMenuItem
            // 
            this.encryptProfileToolStripMenuItem.Enabled = false;
            this.encryptProfileToolStripMenuItem.Name = "encryptProfileToolStripMenuItem";
            this.encryptProfileToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.encryptProfileToolStripMenuItem.Text = "Encrypt Profile";
            this.encryptProfileToolStripMenuItem.Click += new System.EventHandler(this.EncryptProfileToolStripMenuItemClick);
            // 
            // getPasscodeToolStripMenuItem
            // 
            this.getPasscodeToolStripMenuItem.Enabled = false;
            this.getPasscodeToolStripMenuItem.Name = "getPasscodeToolStripMenuItem";
            this.getPasscodeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.getPasscodeToolStripMenuItem.Text = "Get Passcode";
            this.getPasscodeToolStripMenuItem.Click += new System.EventHandler(this.GetPasscodeToolStripMenuItemClick);
            // 
            // clearPasscodeToolStripMenuItem
            // 
            this.clearPasscodeToolStripMenuItem.Enabled = false;
            this.clearPasscodeToolStripMenuItem.Name = "clearPasscodeToolStripMenuItem";
            this.clearPasscodeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.clearPasscodeToolStripMenuItem.Text = "Clear Passcode";
            this.clearPasscodeToolStripMenuItem.Click += new System.EventHandler(this.ClearPasscodeToolStripMenuItemClick);
            // 
            // currname
            // 
            this.currname.Location = new System.Drawing.Point(67, 19);
            this.currname.Name = "currname";
            this.currname.ReadOnly = true;
            this.currname.Size = new System.Drawing.Size(144, 20);
            this.currname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.getcurrent);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.currsig);
            this.groupBox1.Controls.Add(this.currtype2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.currtype);
            this.groupBox1.Controls.Add(this.currxuid);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.currname);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 193);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Account info";
            // 
            // getcurrent
            // 
            this.getcurrent.Enabled = false;
            this.getcurrent.Location = new System.Drawing.Point(6, 149);
            this.getcurrent.Name = "getcurrent";
            this.getcurrent.Size = new System.Drawing.Size(205, 38);
            this.getcurrent.TabIndex = 6;
            this.getcurrent.Text = "Get current information";
            this.getcurrent.UseVisualStyleBackColor = true;
            this.getcurrent.Click += new System.EventHandler(this.GetcurrentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Signature:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Online:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Type:";
            // 
            // currsig
            // 
            this.currsig.Location = new System.Drawing.Point(67, 123);
            this.currsig.Name = "currsig";
            this.currsig.ReadOnly = true;
            this.currsig.Size = new System.Drawing.Size(144, 20);
            this.currsig.TabIndex = 3;
            // 
            // currtype2
            // 
            this.currtype2.Location = new System.Drawing.Point(67, 97);
            this.currtype2.Name = "currtype2";
            this.currtype2.ReadOnly = true;
            this.currtype2.Size = new System.Drawing.Size(144, 20);
            this.currtype2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "XUID:";
            // 
            // currtype
            // 
            this.currtype.Location = new System.Drawing.Point(67, 71);
            this.currtype.Name = "currtype";
            this.currtype.ReadOnly = true;
            this.currtype.Size = new System.Drawing.Size(144, 20);
            this.currtype.TabIndex = 3;
            // 
            // currxuid
            // 
            this.currxuid.Location = new System.Drawing.Point(67, 45);
            this.currxuid.Name = "currxuid";
            this.currxuid.ReadOnly = true;
            this.currxuid.Size = new System.Drawing.Size(144, 20);
            this.currxuid.TabIndex = 3;
            // 
            // makeoffline
            // 
            this.makeoffline.Location = new System.Drawing.Point(217, 135);
            this.makeoffline.Name = "makeoffline";
            this.makeoffline.Size = new System.Drawing.Size(156, 23);
            this.makeoffline.TabIndex = 13;
            this.makeoffline.Text = "Make Offline";
            this.makeoffline.UseVisualStyleBackColor = true;
            this.makeoffline.Click += new System.EventHandler(this.MakeofflineClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 231);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(627, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(150, 17);
            this.status.Text = "Please load an account file!";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.AddExtension = false;
            this.openFileDialog1.FileName = "Account";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.AddExtension = false;
            this.saveFileDialog1.FileName = "Account";
            // 
            // functions
            // 
            this.functions.Controls.Add(this.label9);
            this.functions.Controls.Add(this.newsig);
            this.functions.Controls.Add(this.label8);
            this.functions.Controls.Add(this.newtype);
            this.functions.Controls.Add(this.patchtype);
            this.functions.Controls.Add(this.genxuid);
            this.functions.Controls.Add(this.modxuid);
            this.functions.Controls.Add(this.modname);
            this.functions.Controls.Add(this.makeoffline);
            this.functions.Controls.Add(this.copycurrent);
            this.functions.Controls.Add(this.makeonline);
            this.functions.Controls.Add(this.patchsig);
            this.functions.Controls.Add(this.label5);
            this.functions.Controls.Add(this.newxuid);
            this.functions.Controls.Add(this.label6);
            this.functions.Controls.Add(this.newname);
            this.functions.Location = new System.Drawing.Point(235, 27);
            this.functions.Name = "functions";
            this.functions.Size = new System.Drawing.Size(383, 193);
            this.functions.TabIndex = 3;
            this.functions.TabStop = false;
            this.functions.Text = "Functions";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Signature:";
            // 
            // newsig
            // 
            this.newsig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.newsig.FormattingEnabled = true;
            this.newsig.Location = new System.Drawing.Point(67, 98);
            this.newsig.Name = "newsig";
            this.newsig.Size = new System.Drawing.Size(144, 21);
            this.newsig.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Type:";
            // 
            // newtype
            // 
            this.newtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.newtype.FormattingEnabled = true;
            this.newtype.Location = new System.Drawing.Point(67, 71);
            this.newtype.Name = "newtype";
            this.newtype.Size = new System.Drawing.Size(144, 21);
            this.newtype.TabIndex = 17;
            // 
            // patchtype
            // 
            this.patchtype.Location = new System.Drawing.Point(217, 77);
            this.patchtype.Name = "patchtype";
            this.patchtype.Size = new System.Drawing.Size(156, 23);
            this.patchtype.TabIndex = 16;
            this.patchtype.Text = "Patch account type";
            this.patchtype.UseVisualStyleBackColor = true;
            this.patchtype.Click += new System.EventHandler(this.PatchtypeClick);
            // 
            // genxuid
            // 
            this.genxuid.Location = new System.Drawing.Point(6, 125);
            this.genxuid.Name = "genxuid";
            this.genxuid.Size = new System.Drawing.Size(205, 23);
            this.genxuid.TabIndex = 15;
            this.genxuid.Text = "Generate new XUID";
            this.genxuid.UseVisualStyleBackColor = true;
            this.genxuid.Click += new System.EventHandler(this.GenxuidClick);
            // 
            // modxuid
            // 
            this.modxuid.Enabled = false;
            this.modxuid.Location = new System.Drawing.Point(217, 48);
            this.modxuid.Name = "modxuid";
            this.modxuid.Size = new System.Drawing.Size(156, 23);
            this.modxuid.TabIndex = 15;
            this.modxuid.Text = "Patch XUID";
            this.modxuid.UseVisualStyleBackColor = true;
            this.modxuid.Click += new System.EventHandler(this.ModxuidClick);
            // 
            // modname
            // 
            this.modname.Enabled = false;
            this.modname.Location = new System.Drawing.Point(217, 19);
            this.modname.Name = "modname";
            this.modname.Size = new System.Drawing.Size(156, 23);
            this.modname.TabIndex = 14;
            this.modname.Text = "Patch Name";
            this.modname.UseVisualStyleBackColor = true;
            this.modname.Click += new System.EventHandler(this.ModnameClick);
            // 
            // copycurrent
            // 
            this.copycurrent.Enabled = false;
            this.copycurrent.Location = new System.Drawing.Point(6, 156);
            this.copycurrent.Name = "copycurrent";
            this.copycurrent.Size = new System.Drawing.Size(205, 31);
            this.copycurrent.TabIndex = 6;
            this.copycurrent.Text = "Copy current";
            this.copycurrent.UseVisualStyleBackColor = true;
            this.copycurrent.Click += new System.EventHandler(this.CopycurrentClick);
            // 
            // makeonline
            // 
            this.makeonline.Location = new System.Drawing.Point(217, 164);
            this.makeonline.Name = "makeonline";
            this.makeonline.Size = new System.Drawing.Size(156, 23);
            this.makeonline.TabIndex = 12;
            this.makeonline.Text = "Make Online";
            this.makeonline.UseVisualStyleBackColor = true;
            this.makeonline.Click += new System.EventHandler(this.MakeonlineClick);
            // 
            // patchsig
            // 
            this.patchsig.Location = new System.Drawing.Point(217, 106);
            this.patchsig.Name = "patchsig";
            this.patchsig.Size = new System.Drawing.Size(156, 23);
            this.patchsig.TabIndex = 12;
            this.patchsig.Text = "Patch Live signature";
            this.patchsig.UseVisualStyleBackColor = true;
            this.patchsig.Click += new System.EventHandler(this.PatchsigClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "XUID:";
            // 
            // newxuid
            // 
            this.newxuid.Location = new System.Drawing.Point(67, 45);
            this.newxuid.MaxLength = 16;
            this.newxuid.Name = "newxuid";
            this.newxuid.Size = new System.Drawing.Size(144, 20);
            this.newxuid.TabIndex = 3;
            this.newxuid.TextChanged += new System.EventHandler(this.NewxuidTextChanged);
            this.newxuid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Hexinput);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Name:";
            // 
            // newname
            // 
            this.newname.Location = new System.Drawing.Point(67, 19);
            this.newname.MaxLength = 15;
            this.newname.Name = "newname";
            this.newname.Size = new System.Drawing.Size(144, 20);
            this.newname.TabIndex = 1;
            this.newname.TextChanged += new System.EventHandler(this.NewnameTextChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(627, 253);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.functions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "x360 Account Editor v";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.Load += new System.EventHandler(this.Form1Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.functions.ResumeLayout(false);
            this.functions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decryptProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encryptProfileToolStripMenuItem;
        private System.Windows.Forms.TextBox currname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox currxuid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox currtype;
        private System.Windows.Forms.Button getcurrent;
        private System.Windows.Forms.Button makeoffline;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox functions;
        private System.Windows.Forms.Button modxuid;
        private System.Windows.Forms.Button modname;
        private System.Windows.Forms.Button copycurrent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox newxuid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox newname;
        private System.Windows.Forms.Button genxuid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox currsig;
        private System.Windows.Forms.TextBox currtype2;
        private System.Windows.Forms.Button makeonline;
        private System.Windows.Forms.Button patchsig;
        private System.Windows.Forms.Button patchtype;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox newsig;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox newtype;
        private System.Windows.Forms.ToolStripMenuItem getPasscodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearPasscodeToolStripMenuItem;


    }
}

