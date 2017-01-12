namespace Asset_Managment
{
    partial class ScanAdd
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.assetNo = new System.Windows.Forms.TextBox();
            this.AssetName = new System.Windows.Forms.TextBox();
            this.removebtn = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.orderNumber = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.shipper = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.engineer = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.shipTo = new System.Windows.Forms.ComboBox();
            this.isDamaged = new System.Windows.Forms.CheckBox();
            this.img = new System.Windows.Forms.PictureBox();
            this.Barcode = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Barcode)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.assetNo);
            this.groupBox1.Controls.Add(this.AssetName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 47);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asset";
            // 
            // assetNo
            // 
            this.assetNo.Location = new System.Drawing.Point(502, 21);
            this.assetNo.Name = "assetNo";
            this.assetNo.ReadOnly = true;
            this.assetNo.Size = new System.Drawing.Size(172, 20);
            this.assetNo.TabIndex = 1;
            // 
            // AssetName
            // 
            this.AssetName.Location = new System.Drawing.Point(6, 21);
            this.AssetName.Name = "AssetName";
            this.AssetName.ReadOnly = true;
            this.AssetName.Size = new System.Drawing.Size(490, 20);
            this.AssetName.TabIndex = 0;
            // 
            // removebtn
            // 
            this.removebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removebtn.Location = new System.Drawing.Point(483, 202);
            this.removebtn.Name = "removebtn";
            this.removebtn.Size = new System.Drawing.Size(200, 77);
            this.removebtn.TabIndex = 30;
            this.removebtn.Text = "Check In";
            this.removebtn.UseVisualStyleBackColor = true;
            this.removebtn.Click += new System.EventHandler(this.removebtn_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.orderNumber);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(483, 95);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 47);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Service Order";
            // 
            // orderNumber
            // 
            this.orderNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderNumber.Enabled = false;
            this.orderNumber.FormattingEnabled = true;
            this.orderNumber.Location = new System.Drawing.Point(3, 16);
            this.orderNumber.Name = "orderNumber";
            this.orderNumber.Size = new System.Drawing.Size(194, 21);
            this.orderNumber.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.shipper);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(483, 149);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 47);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Person Shipping";
            // 
            // shipper
            // 
            this.shipper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shipper.Enabled = false;
            this.shipper.FormattingEnabled = true;
            this.shipper.Location = new System.Drawing.Point(3, 16);
            this.shipper.Name = "shipper";
            this.shipper.Size = new System.Drawing.Size(194, 21);
            this.shipper.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.engineer);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(277, 148);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 47);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Service Engineer";
            // 
            // engineer
            // 
            this.engineer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.engineer.Enabled = false;
            this.engineer.FormattingEnabled = true;
            this.engineer.Location = new System.Drawing.Point(3, 16);
            this.engineer.Name = "engineer";
            this.engineer.Size = new System.Drawing.Size(194, 21);
            this.engineer.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.shipTo);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(277, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 47);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ship To";
            // 
            // shipTo
            // 
            this.shipTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shipTo.Enabled = false;
            this.shipTo.FormattingEnabled = true;
            this.shipTo.Location = new System.Drawing.Point(3, 16);
            this.shipTo.Name = "shipTo";
            this.shipTo.Size = new System.Drawing.Size(194, 21);
            this.shipTo.TabIndex = 2;
            // 
            // isDamaged
            // 
            this.isDamaged.AutoSize = true;
            this.isDamaged.Location = new System.Drawing.Point(483, 285);
            this.isDamaged.Name = "isDamaged";
            this.isDamaged.Size = new System.Drawing.Size(146, 17);
            this.isDamaged.TabIndex = 38;
            this.isDamaged.Text = "Service Tool Is Damaged";
            this.isDamaged.UseVisualStyleBackColor = true;
            this.isDamaged.CheckedChanged += new System.EventHandler(this.isDamaged_CheckedChanged);
            // 
            // img
            // 
            this.img.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.img.Location = new System.Drawing.Point(3, 95);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(268, 204);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img.TabIndex = 35;
            this.img.TabStop = false;
            // 
            // Barcode
            // 
            this.Barcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Barcode.Location = new System.Drawing.Point(277, 202);
            this.Barcode.Name = "Barcode";
            this.Barcode.Size = new System.Drawing.Size(200, 97);
            this.Barcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Barcode.TabIndex = 36;
            this.Barcode.TabStop = false;
            // 
            // ScanAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 309);
            this.Controls.Add(this.isDamaged);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.removebtn);
            this.Controls.Add(this.img);
            this.Controls.Add(this.Barcode);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "ScanAdd";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check In";
            this.Load += new System.EventHandler(this.ScanAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Barcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox assetNo;
        private System.Windows.Forms.TextBox AssetName;
        private System.Windows.Forms.Button removebtn;
        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.PictureBox Barcode;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox orderNumber;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox shipper;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox engineer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox shipTo;
        private System.Windows.Forms.CheckBox isDamaged;
    }
}