namespace CBDecryptor
{
    internal sealed partial class Form1
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
            this.cbakey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbkey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.blkeybtn = new System.Windows.Forms.Button();
            this.cbbkeybtn = new System.Windows.Forms.Button();
            this.loadcbabtn = new System.Windows.Forms.Button();
            this.loadcbbbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbapath = new System.Windows.Forms.TextBox();
            this.cbbpath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbakey
            // 
            this.cbakey.Location = new System.Drawing.Point(76, 14);
            this.cbakey.Name = "cbakey";
            this.cbakey.Size = new System.Drawing.Size(218, 20);
            this.cbakey.TabIndex = 0;
            this.cbakey.Text = "DD88AD0C9ED669E7B56794FB68563EFA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CB_A Key:";
            // 
            // cbbkey
            // 
            this.cbbkey.Location = new System.Drawing.Point(76, 43);
            this.cbbkey.Name = "cbbkey";
            this.cbbkey.Size = new System.Drawing.Size(218, 20);
            this.cbbkey.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "CB_B Key:";
            // 
            // blkeybtn
            // 
            this.blkeybtn.Location = new System.Drawing.Point(300, 12);
            this.blkeybtn.Name = "blkeybtn";
            this.blkeybtn.Size = new System.Drawing.Size(75, 23);
            this.blkeybtn.TabIndex = 2;
            this.blkeybtn.Text = "LoadKey";
            this.blkeybtn.UseVisualStyleBackColor = true;
            this.blkeybtn.Click += new System.EventHandler(this.BlkeybtnClick);
            // 
            // cbbkeybtn
            // 
            this.cbbkeybtn.Location = new System.Drawing.Point(300, 41);
            this.cbbkeybtn.Name = "cbbkeybtn";
            this.cbbkeybtn.Size = new System.Drawing.Size(75, 23);
            this.cbbkeybtn.TabIndex = 2;
            this.cbbkeybtn.Text = "LoadKey";
            this.cbbkeybtn.UseVisualStyleBackColor = true;
            this.cbbkeybtn.Click += new System.EventHandler(this.CbbkeybtnClick);
            // 
            // loadcbabtn
            // 
            this.loadcbabtn.Location = new System.Drawing.Point(300, 70);
            this.loadcbabtn.Name = "loadcbabtn";
            this.loadcbabtn.Size = new System.Drawing.Size(75, 23);
            this.loadcbabtn.TabIndex = 3;
            this.loadcbabtn.Text = "Load bin";
            this.loadcbabtn.UseVisualStyleBackColor = true;
            this.loadcbabtn.Click += new System.EventHandler(this.LoadcbabtnClick);
            // 
            // loadcbbbtn
            // 
            this.loadcbbbtn.Location = new System.Drawing.Point(300, 99);
            this.loadcbbbtn.Name = "loadcbbbtn";
            this.loadcbbbtn.Size = new System.Drawing.Size(75, 23);
            this.loadcbbbtn.TabIndex = 3;
            this.loadcbbbtn.Text = "Load bin";
            this.loadcbbbtn.UseVisualStyleBackColor = true;
            this.loadcbbbtn.Click += new System.EventHandler(this.LoadcbbbtnClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "CB_A:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "CB_B:";
            // 
            // cbapath
            // 
            this.cbapath.AllowDrop = true;
            this.cbapath.Location = new System.Drawing.Point(76, 72);
            this.cbapath.Name = "cbapath";
            this.cbapath.Size = new System.Drawing.Size(218, 20);
            this.cbapath.TabIndex = 0;
            this.cbapath.DragDrop += new System.Windows.Forms.DragEventHandler(this.CbapathDragDrop);
            this.cbapath.DragEnter += new System.Windows.Forms.DragEventHandler(this.CbapathDragEnter);
            // 
            // cbbpath
            // 
            this.cbbpath.AllowDrop = true;
            this.cbbpath.Location = new System.Drawing.Point(76, 101);
            this.cbbpath.Name = "cbbpath";
            this.cbbpath.Size = new System.Drawing.Size(218, 20);
            this.cbbpath.TabIndex = 0;
            this.cbbpath.DragDrop += new System.Windows.Forms.DragEventHandler(this.CbbpathDragDrop);
            this.cbbpath.DragEnter += new System.Windows.Forms.DragEventHandler(this.CbbpathDragEnter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(363, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Decrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 162);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.loadcbbbtn);
            this.Controls.Add(this.loadcbabtn);
            this.Controls.Add(this.cbbkeybtn);
            this.Controls.Add(this.blkeybtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbkey);
            this.Controls.Add(this.cbbpath);
            this.Controls.Add(this.cbapath);
            this.Controls.Add(this.cbakey);
            this.Name = "Form1";
            this.Text = "CBDecryptor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cbakey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cbbkey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button blkeybtn;
        private System.Windows.Forms.Button cbbkeybtn;
        private System.Windows.Forms.Button loadcbabtn;
        private System.Windows.Forms.Button loadcbbbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cbapath;
        private System.Windows.Forms.TextBox cbbpath;
        private System.Windows.Forms.Button button1;
    }
}

