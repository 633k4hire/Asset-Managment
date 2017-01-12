namespace Asset_Managment
{
    partial class ScanRemove
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.orderNumber = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.shipper = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.engineer = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.shipTo = new System.Windows.Forms.ComboBox();
            this.removebtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.assetNo = new System.Windows.Forms.TextBox();
            this.AssetName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.kitbox = new System.Windows.Forms.ListBox();
            this.img = new System.Windows.Forms.PictureBox();
            this.Barcode = new System.Windows.Forms.PictureBox();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderNumber)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Barcode)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.orderNumber);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(560, 97);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(240, 47);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Service Order";
            // 
            // orderNumber
            // 
            this.orderNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderNumber.Location = new System.Drawing.Point(3, 16);
            this.orderNumber.Maximum = new decimal(new int[] {
            -1486618624,
            232830643,
            0,
            0});
            this.orderNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.orderNumber.Name = "orderNumber";
            this.orderNumber.Size = new System.Drawing.Size(234, 20);
            this.orderNumber.TabIndex = 1;
            this.orderNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.orderNumber.ValueChanged += new System.EventHandler(this.orderNumber_SelectedIndexChanged);
            this.orderNumber.Click += new System.EventHandler(this.orderNumber_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.shipper);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(560, 151);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(240, 47);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Person Shipping";
            // 
            // shipper
            // 
            this.shipper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shipper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shipper.FormattingEnabled = true;
            this.shipper.Location = new System.Drawing.Point(3, 16);
            this.shipper.Name = "shipper";
            this.shipper.Size = new System.Drawing.Size(234, 21);
            this.shipper.TabIndex = 3;
            this.shipper.SelectedIndexChanged += new System.EventHandler(this.shipper_SelectedIndexChanged_1);
            this.shipper.TextUpdate += new System.EventHandler(this.shipper_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.engineer);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(286, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 47);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Service Engineer";
            // 
            // engineer
            // 
            this.engineer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.engineer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.engineer.FormattingEnabled = true;
            this.engineer.Location = new System.Drawing.Point(3, 16);
            this.engineer.Name = "engineer";
            this.engineer.Size = new System.Drawing.Size(262, 21);
            this.engineer.TabIndex = 2;
            this.engineer.SelectedIndexChanged += new System.EventHandler(this.engineer_SelectedIndexChanged_1);
            this.engineer.TextUpdate += new System.EventHandler(this.engineer_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.shipTo);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(286, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 47);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ship To";
            // 
            // shipTo
            // 
            this.shipTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shipTo.FormattingEnabled = true;
            this.shipTo.Location = new System.Drawing.Point(3, 16);
            this.shipTo.Name = "shipTo";
            this.shipTo.Size = new System.Drawing.Size(262, 21);
            this.shipTo.TabIndex = 0;
            this.shipTo.SelectedIndexChanged += new System.EventHandler(this.shipTo_SelectedIndexChanged_1);
            this.shipTo.TextUpdate += new System.EventHandler(this.shipTo_SelectedIndexChanged);
            // 
            // removebtn
            // 
            this.removebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removebtn.Location = new System.Drawing.Point(704, 204);
            this.removebtn.Name = "removebtn";
            this.removebtn.Size = new System.Drawing.Size(96, 97);
            this.removebtn.TabIndex = 4;
            this.removebtn.Text = "Check Out";
            this.removebtn.UseVisualStyleBackColor = true;
            this.removebtn.Click += new System.EventHandler(this.removebtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.assetNo);
            this.groupBox1.Controls.Add(this.AssetName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 47);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asset";
            // 
            // assetNo
            // 
            this.assetNo.Location = new System.Drawing.Point(610, 21);
            this.assetNo.Name = "assetNo";
            this.assetNo.ReadOnly = true;
            this.assetNo.Size = new System.Drawing.Size(172, 20);
            this.assetNo.TabIndex = 20;
            this.assetNo.TextChanged += new System.EventHandler(this.assetNo_TextChanged);
            // 
            // AssetName
            // 
            this.AssetName.Location = new System.Drawing.Point(6, 21);
            this.AssetName.Name = "AssetName";
            this.AssetName.ReadOnly = true;
            this.AssetName.Size = new System.Drawing.Size(598, 20);
            this.AssetName.TabIndex = 60;
            this.AssetName.TextChanged += new System.EventHandler(this.AssetName_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(492, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 97);
            this.button1.TabIndex = 10;
            this.button1.Text = "Add Additional Kit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.kitbox);
            this.groupBox6.Location = new System.Drawing.Point(594, 204);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(104, 97);
            this.groupBox6.TabIndex = 29;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Kits";
            // 
            // kitbox
            // 
            this.kitbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kitbox.FormattingEnabled = true;
            this.kitbox.Location = new System.Drawing.Point(3, 16);
            this.kitbox.Name = "kitbox";
            this.kitbox.ScrollAlwaysVisible = true;
            this.kitbox.Size = new System.Drawing.Size(98, 78);
            this.kitbox.TabIndex = 100;
            // 
            // img
            // 
            this.img.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.img.Location = new System.Drawing.Point(12, 97);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(268, 204);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img.TabIndex = 26;
            this.img.TabStop = false;
            // 
            // Barcode
            // 
            this.Barcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Barcode.Location = new System.Drawing.Point(286, 204);
            this.Barcode.Name = "Barcode";
            this.Barcode.Size = new System.Drawing.Size(200, 97);
            this.Barcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Barcode.TabIndex = 26;
            this.Barcode.TabStop = false;
            // 
            // ScanRemove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 313);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.removebtn);
            this.Controls.Add(this.img);
            this.Controls.Add(this.Barcode);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ScanRemove";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Out";
            this.Load += new System.EventHandler(this.ScanRemove_Load);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderNumber)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Barcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox shipper;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox engineer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox shipTo;
        private System.Windows.Forms.PictureBox Barcode;
        private System.Windows.Forms.Button removebtn;
        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox assetNo;
        private System.Windows.Forms.TextBox AssetName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox kitbox;
        private System.Windows.Forms.NumericUpDown orderNumber;
    }
}