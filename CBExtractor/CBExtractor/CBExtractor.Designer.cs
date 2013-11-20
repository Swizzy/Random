namespace CBExtractor
{
    internal sealed partial class CBExtractor
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new SafeToolStripLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.bw2 = new System.ComponentModel.BackgroundWorker();
            this.scanner = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 135);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(360, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(26, 17);
            this.status.Text = "shit";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(335, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Scan Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // bw
            // 
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwDoWork);
            // 
            // bw2
            // 
            this.bw2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Bw2DoWork);
            // 
            // scanner
            // 
            this.scanner.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ScannerDoWork);
            this.scanner.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ScannerRunWorkerCompleted);
            // 
            // CBExtractor
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 157);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "CBExtractor";
            this.Text = "CBExtractor";
            this.Load += new System.EventHandler(this.CBExtractorLoad);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CBExtractorDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.CBExtractorDragEnter);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        internal SafeToolStripLabel status;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker bw;
        private System.ComponentModel.BackgroundWorker bw2;
        private System.ComponentModel.BackgroundWorker scanner;
    }
}

