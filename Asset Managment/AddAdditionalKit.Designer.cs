namespace Asset_Managment
{
    partial class AddAdditionalKit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kitbox = new System.Windows.Forms.ListBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.HiddenScanBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kitbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Additional Kits";
            // 
            // kitbox
            // 
            this.kitbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kitbox.FormattingEnabled = true;
            this.kitbox.Location = new System.Drawing.Point(3, 16);
            this.kitbox.Name = "kitbox";
            this.kitbox.ScrollAlwaysVisible = true;
            this.kitbox.Size = new System.Drawing.Size(335, 179);
            this.kitbox.TabIndex = 1;
            // 
            // savebtn
            // 
            this.savebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(359, 12);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(96, 172);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "Add All Scanned Kits";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // HiddenScanBox
            // 
            this.HiddenScanBox.Location = new System.Drawing.Point(359, 190);
            this.HiddenScanBox.MaxLength = 4;
            this.HiddenScanBox.Name = "HiddenScanBox";
            this.HiddenScanBox.Size = new System.Drawing.Size(96, 20);
            this.HiddenScanBox.TabIndex = 2;
            this.HiddenScanBox.TextChanged += new System.EventHandler(this.HiddenScanBox_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AddAdditionalKit
            // 
            this.AcceptButton = this.savebtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 222);
            this.Controls.Add(this.HiddenScanBox);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "AddAdditionalKit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scan Additional Kits";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddAdditionalKit_FormClosing);
            this.Load += new System.EventHandler(this.AddAdditionalKit_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddAdditionalKit_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox HiddenScanBox;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ListBox kitbox;
    }
}