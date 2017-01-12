namespace Asset_Managment
{
    partial class GeneralSettings
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.Customers = new System.Windows.Forms.TreeView();
            this.customermenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.shippingPersonnel = new System.Windows.Forms.TreeView();
            this.shippingmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.serviceEngineers = new System.Windows.Forms.TreeView();
            this.engineermenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.libraryPath = new System.Windows.Forms.TextBox();
            this.selectLibrarybtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.staticEmails = new System.Windows.Forms.TreeView();
            this.staticmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.unsentemails = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reoccuringnoticedays = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.initialnoticedays = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sendunsentemailbtn = new System.Windows.Forms.Button();
            this.clearunsentemailbtn = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.checkinmessage = new System.Windows.Forms.RichTextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.notificationmessage = new System.Windows.Forms.RichTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.checkoutmessage = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.customermenu.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.shippingmenu.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.engineermenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.staticmenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(811, 643);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(803, 617);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.Customers);
            this.groupBox6.Location = new System.Drawing.Point(456, 68);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(339, 541);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Customers";
            // 
            // Customers
            // 
            this.Customers.ContextMenuStrip = this.customermenu;
            this.Customers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Customers.Location = new System.Drawing.Point(3, 16);
            this.Customers.Name = "Customers";
            this.Customers.Size = new System.Drawing.Size(333, 522);
            this.Customers.TabIndex = 0;
            // 
            // customermenu
            // 
            this.customermenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.customermenu.Name = "engineermenu";
            this.customermenu.Size = new System.Drawing.Size(118, 48);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem3.Text = "Add";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem4.Text = "Remove";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.shippingPersonnel);
            this.groupBox5.Location = new System.Drawing.Point(227, 68);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(226, 541);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Shipping Personnel";
            // 
            // shippingPersonnel
            // 
            this.shippingPersonnel.ContextMenuStrip = this.shippingmenu;
            this.shippingPersonnel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shippingPersonnel.Location = new System.Drawing.Point(3, 16);
            this.shippingPersonnel.Name = "shippingPersonnel";
            this.shippingPersonnel.Size = new System.Drawing.Size(220, 522);
            this.shippingPersonnel.TabIndex = 0;
            // 
            // shippingmenu
            // 
            this.shippingmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.shippingmenu.Name = "engineermenu";
            this.shippingmenu.Size = new System.Drawing.Size(118, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem1.Text = "Add";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem2.Text = "Remove";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.serviceEngineers);
            this.groupBox4.Location = new System.Drawing.Point(8, 68);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(213, 541);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Service Engineers";
            // 
            // serviceEngineers
            // 
            this.serviceEngineers.ContextMenuStrip = this.engineermenu;
            this.serviceEngineers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serviceEngineers.Location = new System.Drawing.Point(3, 16);
            this.serviceEngineers.Name = "serviceEngineers";
            this.serviceEngineers.Size = new System.Drawing.Size(207, 522);
            this.serviceEngineers.TabIndex = 0;
            // 
            // engineermenu
            // 
            this.engineermenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.engineermenu.Name = "engineermenu";
            this.engineermenu.Size = new System.Drawing.Size(118, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Enabled = false;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.libraryPath);
            this.groupBox2.Controls.Add(this.selectLibrarybtn);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(787, 56);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Library File";
            // 
            // libraryPath
            // 
            this.libraryPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.libraryPath.Enabled = false;
            this.libraryPath.Location = new System.Drawing.Point(87, 22);
            this.libraryPath.Name = "libraryPath";
            this.libraryPath.Size = new System.Drawing.Size(694, 20);
            this.libraryPath.TabIndex = 1;
            this.libraryPath.Text = "Library.stal";
            // 
            // selectLibrarybtn
            // 
            this.selectLibrarybtn.Enabled = false;
            this.selectLibrarybtn.Location = new System.Drawing.Point(6, 20);
            this.selectLibrarybtn.Name = "selectLibrarybtn";
            this.selectLibrarybtn.Size = new System.Drawing.Size(75, 23);
            this.selectLibrarybtn.TabIndex = 0;
            this.selectLibrarybtn.Text = "Select";
            this.selectLibrarybtn.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(803, 617);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notification Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.staticEmails);
            this.groupBox3.Location = new System.Drawing.Point(187, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(608, 603);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Static Notification Emails";
            // 
            // staticEmails
            // 
            this.staticEmails.ContextMenuStrip = this.staticmenu;
            this.staticEmails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.staticEmails.Location = new System.Drawing.Point(3, 16);
            this.staticEmails.Name = "staticEmails";
            this.staticEmails.Size = new System.Drawing.Size(602, 584);
            this.staticEmails.TabIndex = 0;
            // 
            // staticmenu
            // 
            this.staticmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.staticmenu.Name = "engineermenu";
            this.staticmenu.Size = new System.Drawing.Size(153, 70);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem5.Text = "Add";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Enabled = false;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem6.Text = "Remove";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.unsentemails);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.reoccuringnoticedays);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.initialnoticedays);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sendunsentemailbtn);
            this.groupBox1.Controls.Add(this.clearunsentemailbtn);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 603);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notification Settings";
            // 
            // unsentemails
            // 
            this.unsentemails.Location = new System.Drawing.Point(111, 13);
            this.unsentemails.Name = "unsentemails";
            this.unsentemails.ReadOnly = true;
            this.unsentemails.Size = new System.Drawing.Size(54, 20);
            this.unsentemails.TabIndex = 4;
            this.unsentemails.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Unsent Emails";
            // 
            // reoccuringnoticedays
            // 
            this.reoccuringnoticedays.Location = new System.Drawing.Point(111, 123);
            this.reoccuringnoticedays.Name = "reoccuringnoticedays";
            this.reoccuringnoticedays.ReadOnly = true;
            this.reoccuringnoticedays.Size = new System.Drawing.Size(54, 20);
            this.reoccuringnoticedays.TabIndex = 2;
            this.reoccuringnoticedays.Text = "15";
            this.reoccuringnoticedays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reoccuring Notice";
            // 
            // initialnoticedays
            // 
            this.initialnoticedays.Location = new System.Drawing.Point(80, 97);
            this.initialnoticedays.Name = "initialnoticedays";
            this.initialnoticedays.ReadOnly = true;
            this.initialnoticedays.Size = new System.Drawing.Size(85, 20);
            this.initialnoticedays.TabIndex = 2;
            this.initialnoticedays.Text = "30";
            this.initialnoticedays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Initial Notice";
            // 
            // sendunsentemailbtn
            // 
            this.sendunsentemailbtn.Location = new System.Drawing.Point(6, 68);
            this.sendunsentemailbtn.Name = "sendunsentemailbtn";
            this.sendunsentemailbtn.Size = new System.Drawing.Size(159, 23);
            this.sendunsentemailbtn.TabIndex = 0;
            this.sendunsentemailbtn.Text = "Send Unsent Emails";
            this.sendunsentemailbtn.UseVisualStyleBackColor = true;
            this.sendunsentemailbtn.Click += new System.EventHandler(this.sendunsentemailbtn_Click);
            // 
            // clearunsentemailbtn
            // 
            this.clearunsentemailbtn.Location = new System.Drawing.Point(6, 39);
            this.clearunsentemailbtn.Name = "clearunsentemailbtn";
            this.clearunsentemailbtn.Size = new System.Drawing.Size(159, 23);
            this.clearunsentemailbtn.TabIndex = 0;
            this.clearunsentemailbtn.Text = "Clear Unsent Emails";
            this.clearunsentemailbtn.UseVisualStyleBackColor = true;
            this.clearunsentemailbtn.Click += new System.EventHandler(this.clearunsentemailbtn_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox9);
            this.tabPage3.Controls.Add(this.groupBox8);
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(803, 617);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Standard Notifications";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.checkinmessage);
            this.groupBox9.Location = new System.Drawing.Point(8, 381);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(787, 228);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Check In Message";
            // 
            // checkinmessage
            // 
            this.checkinmessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkinmessage.Location = new System.Drawing.Point(3, 16);
            this.checkinmessage.Name = "checkinmessage";
            this.checkinmessage.ReadOnly = true;
            this.checkinmessage.Size = new System.Drawing.Size(781, 209);
            this.checkinmessage.TabIndex = 0;
            this.checkinmessage.Text = "";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.notificationmessage);
            this.groupBox8.Location = new System.Drawing.Point(8, 192);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(787, 183);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Notification Message";
            // 
            // notificationmessage
            // 
            this.notificationmessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notificationmessage.Location = new System.Drawing.Point(3, 16);
            this.notificationmessage.Name = "notificationmessage";
            this.notificationmessage.ReadOnly = true;
            this.notificationmessage.Size = new System.Drawing.Size(781, 164);
            this.notificationmessage.TabIndex = 0;
            this.notificationmessage.Text = "";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkoutmessage);
            this.groupBox7.Location = new System.Drawing.Point(8, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(787, 186);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Check Out Message";
            // 
            // checkoutmessage
            // 
            this.checkoutmessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkoutmessage.Location = new System.Drawing.Point(3, 16);
            this.checkoutmessage.Name = "checkoutmessage";
            this.checkoutmessage.ReadOnly = true;
            this.checkoutmessage.Size = new System.Drawing.Size(781, 167);
            this.checkoutmessage.TabIndex = 0;
            this.checkoutmessage.Text = "";
            // 
            // GeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 643);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GeneralSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.GeneralSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.customermenu.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.shippingmenu.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.engineermenu.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.staticmenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox libraryPath;
        private System.Windows.Forms.Button selectLibrarybtn;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox unsentemails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox reoccuringnoticedays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox initialnoticedays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendunsentemailbtn;
        private System.Windows.Forms.Button clearunsentemailbtn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TreeView shippingPersonnel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TreeView serviceEngineers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView staticEmails;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TreeView Customers;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RichTextBox notificationmessage;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox checkoutmessage;
        private System.Windows.Forms.ContextMenuStrip engineermenu;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RichTextBox checkinmessage;
        private System.Windows.Forms.ContextMenuStrip customermenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ContextMenuStrip shippingmenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip staticmenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
    }
}