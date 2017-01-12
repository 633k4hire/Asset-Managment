namespace Asset_Managment
{
    partial class ScannerSettings
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.parityreplace = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.stopbits = new System.Windows.Forms.GroupBox();
            this.writebuffersize = new System.Windows.Forms.GroupBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.parity = new System.Windows.Forms.ComboBox();
            this.handshake = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.baud = new System.Windows.Forms.NumericUpDown();
            this.writetimeout = new System.Windows.Forms.NumericUpDown();
            this.readbuffer = new System.Windows.Forms.NumericUpDown();
            this.recievedbytethreshold = new System.Windows.Forms.NumericUpDown();
            this.readtimeout = new System.Windows.Forms.NumericUpDown();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.discardnull = new System.Windows.Forms.CheckBox();
            this.rtsenabled = new System.Windows.Forms.CheckBox();
            this.dtrenabled = new System.Windows.Forms.CheckBox();
            this.Databits = new System.Windows.Forms.NumericUpDown();
            this.portname = new System.Windows.Forms.ComboBox();
            this.writebuffer = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.stopbits.SuspendLayout();
            this.writebuffersize.SuspendLayout();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writetimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.readbuffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recievedbytethreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.readtimeout)).BeginInit();
            this.groupBox16.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Databits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writebuffer)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(552, 426);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(471, 426);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox16);
            this.groupBox1.Controls.Add(this.groupBox15);
            this.groupBox1.Controls.Add(this.writebuffersize);
            this.groupBox1.Controls.Add(this.stopbits);
            this.groupBox1.Controls.Add(this.groupBox12);
            this.groupBox1.Controls.Add(this.groupBox11);
            this.groupBox1.Controls.Add(this.groupBox10);
            this.groupBox1.Controls.Add(this.groupBox9);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 408);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.baud);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 42);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BaudRate";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Databits);
            this.groupBox3.Location = new System.Drawing.Point(6, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 42);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Bits";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.handshake);
            this.groupBox5.Location = new System.Drawing.Point(6, 163);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(257, 42);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Handhake";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.parity);
            this.groupBox6.Location = new System.Drawing.Point(6, 211);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(257, 42);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Parity";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.parityreplace);
            this.groupBox7.Location = new System.Drawing.Point(6, 259);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(257, 42);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Parity Replace";
            // 
            // parityreplace
            // 
            this.parityreplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parityreplace.Location = new System.Drawing.Point(3, 16);
            this.parityreplace.Name = "parityreplace";
            this.parityreplace.Size = new System.Drawing.Size(251, 20);
            this.parityreplace.TabIndex = 0;
            this.parityreplace.Text = "63";
            this.parityreplace.TextChanged += new System.EventHandler(this.parityreplace_TextChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.portname);
            this.groupBox8.Location = new System.Drawing.Point(6, 307);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(257, 42);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Port Name";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.readbuffer);
            this.groupBox9.Location = new System.Drawing.Point(6, 355);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(257, 42);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Read Buffer Size";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.readtimeout);
            this.groupBox10.Location = new System.Drawing.Point(269, 19);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(257, 42);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Read Timeout";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.recievedbytethreshold);
            this.groupBox11.Location = new System.Drawing.Point(269, 67);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(257, 42);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Recieved Bytes threshold";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.rtsenabled);
            this.groupBox12.Location = new System.Drawing.Point(269, 115);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(257, 42);
            this.groupBox12.TabIndex = 0;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "RTS Enabled";
            // 
            // stopbits
            // 
            this.stopbits.Controls.Add(this.comboBox3);
            this.stopbits.Location = new System.Drawing.Point(269, 163);
            this.stopbits.Name = "stopbits";
            this.stopbits.Size = new System.Drawing.Size(257, 42);
            this.stopbits.TabIndex = 0;
            this.stopbits.TabStop = false;
            this.stopbits.Text = "Stop Bits";
            // 
            // writebuffersize
            // 
            this.writebuffersize.Controls.Add(this.writebuffer);
            this.writebuffersize.Location = new System.Drawing.Point(269, 211);
            this.writebuffersize.Name = "writebuffersize";
            this.writebuffersize.Size = new System.Drawing.Size(257, 42);
            this.writebuffersize.TabIndex = 0;
            this.writebuffersize.TabStop = false;
            this.writebuffersize.Text = "Write Buffer Size";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.writetimeout);
            this.groupBox15.Location = new System.Drawing.Point(269, 259);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(257, 42);
            this.groupBox15.TabIndex = 0;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Write Timeout";
            // 
            // parity
            // 
            this.parity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parity.FormattingEnabled = true;
            this.parity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.parity.Location = new System.Drawing.Point(3, 16);
            this.parity.Name = "parity";
            this.parity.Size = new System.Drawing.Size(251, 21);
            this.parity.TabIndex = 0;
            this.parity.Text = "None";
            this.parity.SelectedIndexChanged += new System.EventHandler(this.parity_SelectedIndexChanged);
            // 
            // handshake
            // 
            this.handshake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.handshake.FormattingEnabled = true;
            this.handshake.Items.AddRange(new object[] {
            "None",
            "XOnXOff",
            "RequestToSend",
            "RequestToSendXOnXOff"});
            this.handshake.Location = new System.Drawing.Point(3, 16);
            this.handshake.Name = "handshake";
            this.handshake.Size = new System.Drawing.Size(251, 21);
            this.handshake.TabIndex = 1;
            this.handshake.Text = "None";
            this.handshake.SelectedIndexChanged += new System.EventHandler(this.handshake_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "None",
            "One",
            "Two",
            "OnePointFive"});
            this.comboBox3.Location = new System.Drawing.Point(3, 16);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(251, 21);
            this.comboBox3.TabIndex = 1;
            this.comboBox3.Text = "None";
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // baud
            // 
            this.baud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baud.Location = new System.Drawing.Point(3, 16);
            this.baud.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.baud.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.baud.Name = "baud";
            this.baud.Size = new System.Drawing.Size(251, 20);
            this.baud.TabIndex = 0;
            this.baud.Value = new decimal(new int[] {
            9600,
            0,
            0,
            0});
            this.baud.ValueChanged += new System.EventHandler(this.baud_ValueChanged);
            // 
            // writetimeout
            // 
            this.writetimeout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.writetimeout.Location = new System.Drawing.Point(3, 16);
            this.writetimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.writetimeout.Name = "writetimeout";
            this.writetimeout.Size = new System.Drawing.Size(251, 20);
            this.writetimeout.TabIndex = 1;
            this.writetimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.writetimeout.ValueChanged += new System.EventHandler(this.writetimeout_ValueChanged);
            // 
            // readbuffer
            // 
            this.readbuffer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.readbuffer.Location = new System.Drawing.Point(3, 16);
            this.readbuffer.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.readbuffer.Name = "readbuffer";
            this.readbuffer.Size = new System.Drawing.Size(251, 20);
            this.readbuffer.TabIndex = 1;
            this.readbuffer.Value = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.readbuffer.ValueChanged += new System.EventHandler(this.readbuffer_ValueChanged);
            // 
            // recievedbytethreshold
            // 
            this.recievedbytethreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recievedbytethreshold.Location = new System.Drawing.Point(3, 16);
            this.recievedbytethreshold.Name = "recievedbytethreshold";
            this.recievedbytethreshold.Size = new System.Drawing.Size(251, 20);
            this.recievedbytethreshold.TabIndex = 1;
            this.recievedbytethreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recievedbytethreshold.ValueChanged += new System.EventHandler(this.recievedbytethreshold_ValueChanged);
            // 
            // readtimeout
            // 
            this.readtimeout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.readtimeout.Location = new System.Drawing.Point(3, 16);
            this.readtimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.readtimeout.Name = "readtimeout";
            this.readtimeout.Size = new System.Drawing.Size(251, 20);
            this.readtimeout.TabIndex = 1;
            this.readtimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.readtimeout.ValueChanged += new System.EventHandler(this.readtimeout_ValueChanged);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.dtrenabled);
            this.groupBox16.Location = new System.Drawing.Point(269, 307);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(257, 42);
            this.groupBox16.TabIndex = 0;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "DTR Enabled";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.discardnull);
            this.groupBox4.Location = new System.Drawing.Point(6, 115);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(257, 42);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Discard Null";
            // 
            // discardnull
            // 
            this.discardnull.AutoSize = true;
            this.discardnull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.discardnull.Location = new System.Drawing.Point(3, 16);
            this.discardnull.Name = "discardnull";
            this.discardnull.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.discardnull.Size = new System.Drawing.Size(251, 23);
            this.discardnull.TabIndex = 0;
            this.discardnull.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.discardnull.UseVisualStyleBackColor = true;
            this.discardnull.CheckedChanged += new System.EventHandler(this.discardnull_CheckedChanged);
            // 
            // rtsenabled
            // 
            this.rtsenabled.AutoSize = true;
            this.rtsenabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtsenabled.Location = new System.Drawing.Point(3, 16);
            this.rtsenabled.Name = "rtsenabled";
            this.rtsenabled.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtsenabled.Size = new System.Drawing.Size(251, 23);
            this.rtsenabled.TabIndex = 1;
            this.rtsenabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rtsenabled.UseVisualStyleBackColor = true;
            this.rtsenabled.CheckedChanged += new System.EventHandler(this.rtsenabled_CheckedChanged);
            // 
            // dtrenabled
            // 
            this.dtrenabled.AutoSize = true;
            this.dtrenabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtrenabled.Location = new System.Drawing.Point(3, 16);
            this.dtrenabled.Name = "dtrenabled";
            this.dtrenabled.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtrenabled.Size = new System.Drawing.Size(251, 23);
            this.dtrenabled.TabIndex = 1;
            this.dtrenabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dtrenabled.UseVisualStyleBackColor = true;
            this.dtrenabled.CheckedChanged += new System.EventHandler(this.dtrenabled_CheckedChanged);
            // 
            // Databits
            // 
            this.Databits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Databits.Location = new System.Drawing.Point(3, 16);
            this.Databits.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Databits.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.Databits.Name = "Databits";
            this.Databits.Size = new System.Drawing.Size(251, 20);
            this.Databits.TabIndex = 1;
            this.Databits.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.Databits.ValueChanged += new System.EventHandler(this.Databits_ValueChanged);
            // 
            // portname
            // 
            this.portname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portname.FormattingEnabled = true;
            this.portname.Location = new System.Drawing.Point(3, 16);
            this.portname.Name = "portname";
            this.portname.Size = new System.Drawing.Size(251, 21);
            this.portname.TabIndex = 2;
            this.portname.SelectedIndexChanged += new System.EventHandler(this.portname_SelectedIndexChanged);
            // 
            // writebuffer
            // 
            this.writebuffer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.writebuffer.Location = new System.Drawing.Point(3, 16);
            this.writebuffer.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.writebuffer.Name = "writebuffer";
            this.writebuffer.Size = new System.Drawing.Size(251, 20);
            this.writebuffer.TabIndex = 2;
            this.writebuffer.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.writebuffer.ValueChanged += new System.EventHandler(this.writebuffer_ValueChanged);
            // 
            // ScannerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 461);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ScannerSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scanner Settings";
            this.Load += new System.EventHandler(this.ScannerSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.stopbits.ResumeLayout(false);
            this.writebuffersize.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.baud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writetimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.readbuffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recievedbytethreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.readtimeout)).EndInit();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Databits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writebuffer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.GroupBox writebuffersize;
        private System.Windows.Forms.GroupBox stopbits;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox parityreplace;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox parity;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox handshake;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.CheckBox dtrenabled;
        private System.Windows.Forms.NumericUpDown writetimeout;
        private System.Windows.Forms.CheckBox rtsenabled;
        private System.Windows.Forms.NumericUpDown recievedbytethreshold;
        private System.Windows.Forms.NumericUpDown readtimeout;
        private System.Windows.Forms.NumericUpDown readbuffer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox discardnull;
        private System.Windows.Forms.NumericUpDown baud;
        private System.Windows.Forms.NumericUpDown Databits;
        private System.Windows.Forms.ComboBox portname;
        private System.Windows.Forms.NumericUpDown writebuffer;
    }
}