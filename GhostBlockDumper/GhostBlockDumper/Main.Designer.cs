namespace GhostBlockDumper
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
            this.dumpbtn = new System.Windows.Forms.Button();
            this.closebtn = new System.Windows.Forms.Button();
            this.size = new System.Windows.Forms.GroupBox();
            this.bb = new System.Windows.Forms.RadioButton();
            this.sb = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.block = new System.Windows.Forms.TextBox();
            this.device = new System.Windows.Forms.GroupBox();
            this.lpt = new System.Windows.Forms.RadioButton();
            this.usb = new System.Windows.Forms.RadioButton();
            this.times = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.outlog = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.running = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.size.SuspendLayout();
            this.device.SuspendLayout();
            this.SuspendLayout();
            // 
            // dumpbtn
            // 
            this.dumpbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dumpbtn.Location = new System.Drawing.Point(12, 287);
            this.dumpbtn.Name = "dumpbtn";
            this.dumpbtn.Size = new System.Drawing.Size(75, 23);
            this.dumpbtn.TabIndex = 0;
            this.dumpbtn.Text = "Dump";
            this.dumpbtn.UseVisualStyleBackColor = true;
            this.dumpbtn.Click += new System.EventHandler(this.DumpbtnClick);
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closebtn.Location = new System.Drawing.Point(267, 287);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(75, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.ClosebtnClick);
            // 
            // size
            // 
            this.size.Controls.Add(this.bb);
            this.size.Controls.Add(this.sb);
            this.size.Location = new System.Drawing.Point(12, 12);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(76, 65);
            this.size.TabIndex = 2;
            this.size.TabStop = false;
            this.size.Text = "Nand Size";
            // 
            // bb
            // 
            this.bb.AutoSize = true;
            this.bb.Location = new System.Drawing.Point(6, 38);
            this.bb.Name = "bb";
            this.bb.Size = new System.Drawing.Size(66, 17);
            this.bb.TabIndex = 1;
            this.bb.TabStop = true;
            this.bb.Text = "Bigblock";
            this.bb.UseVisualStyleBackColor = true;
            // 
            // sb
            // 
            this.sb.AutoSize = true;
            this.sb.Checked = true;
            this.sb.Location = new System.Drawing.Point(6, 19);
            this.sb.Name = "sb";
            this.sb.Size = new System.Drawing.Size(52, 17);
            this.sb.TabIndex = 0;
            this.sb.TabStop = true;
            this.sb.Text = "16Mb";
            this.sb.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ghost block:";
            // 
            // block
            // 
            this.block.Location = new System.Drawing.Point(291, 35);
            this.block.MaxLength = 3;
            this.block.Name = "block";
            this.block.Size = new System.Drawing.Size(53, 20);
            this.block.TabIndex = 4;
            this.block.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BlockKeyPress);
            // 
            // device
            // 
            this.device.Controls.Add(this.lpt);
            this.device.Controls.Add(this.usb);
            this.device.Location = new System.Drawing.Point(94, 12);
            this.device.Name = "device";
            this.device.Size = new System.Drawing.Size(106, 46);
            this.device.TabIndex = 5;
            this.device.TabStop = false;
            this.device.Text = "Dumping Device";
            // 
            // lpt
            // 
            this.lpt.AutoSize = true;
            this.lpt.Location = new System.Drawing.Point(55, 19);
            this.lpt.Name = "lpt";
            this.lpt.Size = new System.Drawing.Size(45, 17);
            this.lpt.TabIndex = 7;
            this.lpt.Text = "LPT";
            this.lpt.UseVisualStyleBackColor = true;
            // 
            // usb
            // 
            this.usb.AutoSize = true;
            this.usb.Checked = true;
            this.usb.Location = new System.Drawing.Point(6, 19);
            this.usb.Name = "usb";
            this.usb.Size = new System.Drawing.Size(47, 17);
            this.usb.TabIndex = 6;
            this.usb.TabStop = true;
            this.usb.Text = "USB";
            this.usb.UseVisualStyleBackColor = true;
            // 
            // times
            // 
            this.times.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.times.FormattingEnabled = true;
            this.times.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.times.Location = new System.Drawing.Point(291, 9);
            this.times.Name = "times";
            this.times.Size = new System.Drawing.Size(52, 21);
            this.times.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Times to dump:";
            // 
            // outlog
            // 
            this.outlog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outlog.Location = new System.Drawing.Point(12, 96);
            this.outlog.Name = "outlog";
            this.outlog.ReadOnly = true;
            this.outlog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.outlog.ShowSelectionMargin = true;
            this.outlog.Size = new System.Drawing.Size(330, 185);
            this.outlog.TabIndex = 8;
            this.outlog.Text = "";
            this.outlog.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Log:";
            // 
            // running
            // 
            this.running.Location = new System.Drawing.Point(189, 61);
            this.running.Name = "running";
            this.running.Size = new System.Drawing.Size(153, 23);
            this.running.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nandpro running:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 321);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.running);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outlog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.times);
            this.Controls.Add(this.device);
            this.Controls.Add(this.block);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.size);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.dumpbtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(370, 999999974);
            this.MinimumSize = new System.Drawing.Size(370, 274);
            this.Name = "Main";
            this.Text = "Ghost Block Dumper Version:";
            this.Load += new System.EventHandler(this.MainLoad);
            this.size.ResumeLayout(false);
            this.size.PerformLayout();
            this.device.ResumeLayout(false);
            this.device.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dumpbtn;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.GroupBox size;
        private System.Windows.Forms.RadioButton sb;
        private System.Windows.Forms.RadioButton bb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox block;
        private System.Windows.Forms.GroupBox device;
        private System.Windows.Forms.RadioButton usb;
        private System.Windows.Forms.RadioButton lpt;
        private System.Windows.Forms.ComboBox times;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox outlog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar running;
        private System.Windows.Forms.Label label4;
    }
}

