namespace CPUKey_Checker
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
            this.keybox = new System.Windows.Forms.TextBox();
            this.checkbtn = new System.Windows.Forms.Button();
            this.scanbtn = new System.Windows.Forms.Button();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // keybox
            // 
            this.keybox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keybox.Location = new System.Drawing.Point(12, 12);
            this.keybox.MaxLength = 32;
            this.keybox.Name = "keybox";
            this.keybox.Size = new System.Drawing.Size(218, 20);
            this.keybox.TabIndex = 0;
            this.keybox.TextChanged += new System.EventHandler(this.KeyboxTextChanged);
            this.keybox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyboxKeyDown);
            // 
            // checkbtn
            // 
            this.checkbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkbtn.Enabled = false;
            this.checkbtn.Location = new System.Drawing.Point(12, 38);
            this.checkbtn.Name = "checkbtn";
            this.checkbtn.Size = new System.Drawing.Size(218, 27);
            this.checkbtn.TabIndex = 1;
            this.checkbtn.Text = "Check Key";
            this.checkbtn.UseVisualStyleBackColor = true;
            this.checkbtn.Click += new System.EventHandler(this.CheckbtnClick);
            // 
            // scanbtn
            // 
            this.scanbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scanbtn.Location = new System.Drawing.Point(12, 67);
            this.scanbtn.Name = "scanbtn";
            this.scanbtn.Size = new System.Drawing.Size(218, 27);
            this.scanbtn.TabIndex = 1;
            this.scanbtn.Text = "Scan && Check Keys";
            this.scanbtn.UseVisualStyleBackColor = true;
            this.scanbtn.Click += new System.EventHandler(this.ScanbtnClick);
            // 
            // bw
            // 
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BWDoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BWRunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 104);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(242, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(39, 17);
            this.status.Text = "Status";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 126);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.scanbtn);
            this.Controls.Add(this.checkbtn);
            this.Controls.Add(this.keybox);
            this.MinimumSize = new System.Drawing.Size(258, 160);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "CPUKey Checker";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1DragEnter);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox keybox;
        private System.Windows.Forms.Button checkbtn;
        private System.Windows.Forms.Button scanbtn;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.StatusStrip statusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel status;
    }
}

