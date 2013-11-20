namespace x360_Account_Editor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decryptProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.getcurrent = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.currtype = new System.Windows.Forms.TextBox();
            this.currxuid = new System.Windows.Forms.TextBox();
            this.makeoffline = new System.Windows.Forms.Button();
            this.makeonline = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.functions = new System.Windows.Forms.GroupBox();
            this.genxuid = new System.Windows.Forms.Button();
            this.modxuid = new System.Windows.Forms.Button();
            this.modname = new System.Windows.Forms.Button();
            this.copycurrent = new System.Windows.Forms.Button();
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
            this.menuStrip1.Size = new System.Drawing.Size(602, 24);
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decryptProfileToolStripMenuItem,
            this.encryptProfileToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // decryptProfileToolStripMenuItem
            // 
            this.decryptProfileToolStripMenuItem.Enabled = false;
            this.decryptProfileToolStripMenuItem.Name = "decryptProfileToolStripMenuItem";
            this.decryptProfileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.decryptProfileToolStripMenuItem.Text = "Decrypt Profile";
            // 
            // encryptProfileToolStripMenuItem
            // 
            this.encryptProfileToolStripMenuItem.Enabled = false;
            this.encryptProfileToolStripMenuItem.Name = "encryptProfileToolStripMenuItem";
            this.encryptProfileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.encryptProfileToolStripMenuItem.Text = "Encrypt Profile";
            // 
            // currname
            // 
            this.currname.Location = new System.Drawing.Point(50, 19);
            this.currname.Name = "currname";
            this.currname.ReadOnly = true;
            this.currname.Size = new System.Drawing.Size(144, 20);
            this.currname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.getcurrent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.currtype);
            this.groupBox1.Controls.Add(this.currxuid);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.currname);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 135);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Account info";
            // 
            // getcurrent
            // 
            this.getcurrent.Enabled = false;
            this.getcurrent.Location = new System.Drawing.Point(6, 106);
            this.getcurrent.Name = "getcurrent";
            this.getcurrent.Size = new System.Drawing.Size(196, 23);
            this.getcurrent.TabIndex = 6;
            this.getcurrent.Text = "Get current information";
            this.getcurrent.UseVisualStyleBackColor = true;
            this.getcurrent.Click += new System.EventHandler(this.getcurrent_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "XUID:";
            // 
            // currtype
            // 
            this.currtype.Location = new System.Drawing.Point(50, 71);
            this.currtype.Name = "currtype";
            this.currtype.ReadOnly = true;
            this.currtype.Size = new System.Drawing.Size(144, 20);
            this.currtype.TabIndex = 3;
            // 
            // currxuid
            // 
            this.currxuid.Location = new System.Drawing.Point(50, 45);
            this.currxuid.Name = "currxuid";
            this.currxuid.ReadOnly = true;
            this.currxuid.Size = new System.Drawing.Size(144, 20);
            this.currxuid.TabIndex = 3;
            // 
            // makeoffline
            // 
            this.makeoffline.Location = new System.Drawing.Point(103, 77);
            this.makeoffline.Name = "makeoffline";
            this.makeoffline.Size = new System.Drawing.Size(91, 23);
            this.makeoffline.TabIndex = 13;
            this.makeoffline.Text = "Make Offline";
            this.makeoffline.UseVisualStyleBackColor = true;
            this.makeoffline.Click += new System.EventHandler(this.makeoffline_Click);
            // 
            // makeonline
            // 
            this.makeonline.Location = new System.Drawing.Point(6, 77);
            this.makeonline.Name = "makeonline";
            this.makeonline.Size = new System.Drawing.Size(91, 23);
            this.makeonline.TabIndex = 12;
            this.makeonline.Text = "Make Online";
            this.makeonline.UseVisualStyleBackColor = true;
            this.makeonline.Click += new System.EventHandler(this.makeonline_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 173);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(602, 22);
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
            this.functions.Controls.Add(this.genxuid);
            this.functions.Controls.Add(this.modxuid);
            this.functions.Controls.Add(this.modname);
            this.functions.Controls.Add(this.makeoffline);
            this.functions.Controls.Add(this.copycurrent);
            this.functions.Controls.Add(this.makeonline);
            this.functions.Controls.Add(this.label5);
            this.functions.Controls.Add(this.newxuid);
            this.functions.Controls.Add(this.label6);
            this.functions.Controls.Add(this.newname);
            this.functions.Location = new System.Drawing.Point(226, 27);
            this.functions.Name = "functions";
            this.functions.Size = new System.Drawing.Size(362, 135);
            this.functions.TabIndex = 3;
            this.functions.TabStop = false;
            this.functions.Text = "Functions";
            // 
            // genxuid
            // 
            this.genxuid.Location = new System.Drawing.Point(200, 77);
            this.genxuid.Name = "genxuid";
            this.genxuid.Size = new System.Drawing.Size(156, 23);
            this.genxuid.TabIndex = 15;
            this.genxuid.Text = "Generate XUID";
            this.genxuid.UseVisualStyleBackColor = true;
            this.genxuid.Click += new System.EventHandler(this.genxuid_Click);
            // 
            // modxuid
            // 
            this.modxuid.Enabled = false;
            this.modxuid.Location = new System.Drawing.Point(200, 48);
            this.modxuid.Name = "modxuid";
            this.modxuid.Size = new System.Drawing.Size(156, 23);
            this.modxuid.TabIndex = 15;
            this.modxuid.Text = "Change XUID";
            this.modxuid.UseVisualStyleBackColor = true;
            this.modxuid.Click += new System.EventHandler(this.modxuid_Click);
            // 
            // modname
            // 
            this.modname.Enabled = false;
            this.modname.Location = new System.Drawing.Point(200, 19);
            this.modname.Name = "modname";
            this.modname.Size = new System.Drawing.Size(156, 23);
            this.modname.TabIndex = 14;
            this.modname.Text = "Change Name";
            this.modname.UseVisualStyleBackColor = true;
            this.modname.Click += new System.EventHandler(this.modname_Click);
            // 
            // copycurrent
            // 
            this.copycurrent.Enabled = false;
            this.copycurrent.Location = new System.Drawing.Point(6, 106);
            this.copycurrent.Name = "copycurrent";
            this.copycurrent.Size = new System.Drawing.Size(350, 23);
            this.copycurrent.TabIndex = 6;
            this.copycurrent.Text = "Copy current";
            this.copycurrent.UseVisualStyleBackColor = true;
            this.copycurrent.Click += new System.EventHandler(this.copycurrent_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "XUID:";
            // 
            // newxuid
            // 
            this.newxuid.Location = new System.Drawing.Point(50, 45);
            this.newxuid.MaxLength = 16;
            this.newxuid.Name = "newxuid";
            this.newxuid.Size = new System.Drawing.Size(144, 20);
            this.newxuid.TabIndex = 3;
            this.newxuid.TextChanged += new System.EventHandler(this.newxuid_TextChanged);
            this.newxuid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hexinput);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Name:";
            // 
            // newname
            // 
            this.newname.Location = new System.Drawing.Point(50, 19);
            this.newname.MaxLength = 15;
            this.newname.Name = "newname";
            this.newname.Size = new System.Drawing.Size(144, 20);
            this.newname.TabIndex = 1;
            this.newname.TextChanged += new System.EventHandler(this.newname_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(602, 195);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.functions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Button makeonline;
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


    }
}

