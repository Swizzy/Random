namespace NintendoParentalTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.servicecodebox = new System.Windows.Forms.TextBox();
            this.datebox = new System.Windows.Forms.DateTimePicker();
            this.getcodebtn = new System.Windows.Forms.Button();
            this.outputbox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servicecode:";
            // 
            // servicecodebox
            // 
            this.servicecodebox.Location = new System.Drawing.Point(88, 12);
            this.servicecodebox.Name = "servicecodebox";
            this.servicecodebox.Size = new System.Drawing.Size(184, 20);
            this.servicecodebox.TabIndex = 1;
            this.servicecodebox.TextChanged += new System.EventHandler(this.ServicecodeboxTextChanged);
            // 
            // datebox
            // 
            this.datebox.Location = new System.Drawing.Point(12, 38);
            this.datebox.Name = "datebox";
            this.datebox.Size = new System.Drawing.Size(260, 20);
            this.datebox.TabIndex = 2;
            // 
            // getcodebtn
            // 
            this.getcodebtn.Location = new System.Drawing.Point(12, 64);
            this.getcodebtn.Name = "getcodebtn";
            this.getcodebtn.Size = new System.Drawing.Size(260, 23);
            this.getcodebtn.TabIndex = 3;
            this.getcodebtn.Text = "GetCode";
            this.getcodebtn.UseVisualStyleBackColor = true;
            this.getcodebtn.Click += new System.EventHandler(this.GetcodebtnClick);
            // 
            // outputbox
            // 
            this.outputbox.Location = new System.Drawing.Point(12, 93);
            this.outputbox.Name = "outputbox";
            this.outputbox.ReadOnly = true;
            this.outputbox.Size = new System.Drawing.Size(260, 108);
            this.outputbox.TabIndex = 4;
            this.outputbox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(284, 213);
            this.Controls.Add(this.outputbox);
            this.Controls.Add(this.getcodebtn);
            this.Controls.Add(this.datebox);
            this.Controls.Add(this.servicecodebox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Nintendo Parental Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox servicecodebox;
        private System.Windows.Forms.DateTimePicker datebox;
        private System.Windows.Forms.Button getcodebtn;
        private System.Windows.Forms.RichTextBox outputbox;
    }
}

