using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using Zen.Barcode;

namespace Asset_Managment
{
    public partial class MainForm : Form
    {
        //BARCODE
        public static Backup _Backup = new Backup();
        public static string StandardShipperNotification = "";
        public static  NotificationLibrary _Notices = new NotificationLibrary();
        public static bool _EDITMODE = false;
        public static BarcodeSymbology _symbology;
        public static Image _Bar;
        private int _maxBarHeight = 30;
        /// <summary>
		/// Gets or sets the maximum height of the rendered barcode.
		/// </summary>
		/// <value>The maximum height of a barcode bar in pixels.</value>
		[Category("Appearance")]
        [DefaultValue(30)]
        [Description("Gets/sets the maximum height of the rendered barcode bars.")]
        public int MaxBarHeight
        {
            get
            {
                return _maxBarHeight;
            }
            set
            {
                if (_maxBarHeight != value)
                {
                    _maxBarHeight = value;
                }
            }
        }

        public static  Image CreateBarcodeImage(string text, BarcodeSymbology symbology, int size=30)
        {
            // Allocate new barcode image as needed
            if (symbology != BarcodeSymbology.Unknown && !string.IsNullOrEmpty(text))
            {
                try
                {
                    _Bar = BarcodeDrawFactory.GetSymbology(symbology).Draw(text, size);
                    
                }
                catch
                {
                    _Bar = null;
                }
            }
            else
            {
                _Bar = null;
            }
            return _Bar;
            
        }

        //
        public static AssetLibrary Library = new AssetLibrary();
        public static Settings _Settings = new Settings();
        public static MainForm _instance;
        public static MainForm GetInstance
        {
            get { return _instance; }
        }
        public static List<EmailAddress> ShippingPersonnel = new List<EmailAddress>();
        public static readonly object _NotSentLock = new object();
        public static readonly object _15DayLock = new object();
        public static readonly object _30DayLock = new object();


        public static void updateSerialPort(System.IO.Ports.SerialPort port)

        { if (_instance != null)
            {
                _instance.Serial = port;
                try
                {
                    _instance.Serial.Open();
                    if (_instance.Serial.IsOpen)
                    {

                        _instance.ScannerConnectionStatus.Value = 100;

                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Error Updating Serial\r\n" + ee.ToString());
                }
            }
        }
        public static void SendUnsent(Email email)
        {
            if (_DisableEmail == false)
            {
                new System.Threading.Thread(() =>
            {
                try
                {
                    MailMessage msg = new MailMessage();
                    msg.Subject = email.Subject;
                    msg.IsBodyHtml = true;
                    msg.BodyEncoding = Encoding.ASCII;
                    msg.Body = email.Body;
                    try
                    {
                        if (email.Attachments is List<Attachment>)
                        {
                            foreach (var attach in (List<Attachment>)email.Attachments)
                            {

                                msg.Attachments.Add(attach);
                            }
                        }

                    }
                    catch { }
                    msg.From = new MailAddress("servicetools.starrag@gmail.com");
                    msg.To.Add(email.Address.Email);
                    string username = "servicetools.starrag@gmail.com";  //email address or domain user for exchange authentication
                    string password = "Remember1";  //password
                    SmtpClient mClient = new SmtpClient();
                    mClient.Host = "smtp.gmail.com";
                    mClient.Port = 587;
                    mClient.UseDefaultCredentials = false;
                    mClient.Credentials = new NetworkCredential(username, password);
                    mClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    mClient.Timeout = 100000;
                    mClient.EnableSsl = true;
                    try
                    {
                        mClient.Send(msg);
                    }
                    catch
                    {
                        email.Time = DateTime.Now;
                        lock (_NotSentLock)
                        {
                            _Settings.NotSentEmails.Add(email);
                        }
                    }
                }
                catch { }
            }).Start();
            }
        }

        public static void SendEmailReport(Asset asset, EmailAddress email, string subject = "",string Body="", List<Attachment> attachments = null)
        {
            if (_DisableEmail == false)
            {
                new System.Threading.Thread(() =>
                {
                    try
                    {
                        Body = Body.Replace("<name>", asset.ServiceEngineer);
                        Body = Body.Replace("<serviceTool>", asset.ItemName);
                        Body = Body.Replace("<serviceOrder>", asset.OrderNumber.ToString());
                        Body = Body.Replace("<dateAssigned>", asset.DateShipped.ToString());
                        Body = Body.Replace("<NL>", "<br />");
                        MailMessage msg = new MailMessage();
                        msg.Subject = "Asset Alert: " + asset.ItemName + ": " + subject + ": " + DateTime.Now.ToString();
                        msg.IsBodyHtml = true;
                        msg.BodyEncoding = Encoding.ASCII;
                        msg.Body = Body;
                        try
                        {
                            foreach (var attach in attachments)
                            {

                                msg.Attachments.Add(attach);
                            }
                        }
                        catch { }
                        msg.From = new MailAddress("servicetools.starrag@gmail.com");
                        msg.To.Add(email.Email);
                        string username = "servicetools.starrag@gmail.com";  //email address or domain user for exchange authentication
                    string password = "Remember1";  //password
                    SmtpClient mClient = new SmtpClient();
                        mClient.Host = "smtp.gmail.com";
                        mClient.Port = 587;
                        mClient.UseDefaultCredentials = false;
                        mClient.Credentials = new NetworkCredential(username, password);
                        mClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        mClient.Timeout = 100000;
                        mClient.EnableSsl = true;
                        try
                        {
                            mClient.Send(msg);
                        }
                        catch
                        {
                            lock (_NotSentLock)
                            {
                                var e = new Email();
                                e.Address = EmailAddress.Create(email.Email);
                                e.Time = DateTime.Now;
                                e.Body = Body;
                                e.Subject = msg.Subject;
                                _Settings.NotSentEmails.Add(e);
                            }
                        }
                    }
                    catch { }
                }).Start();
            }
        }
        public static void SendBackupReport(EmailAddress email, string subject = "", string Body = "", List<Attachment> attachments = null)
        {
            if (_DisableEmail == false)
            {
                new System.Threading.Thread(() =>
            {
                try
                {

                    MailMessage msg = new MailMessage();
                    msg.Subject = subject;
                    msg.IsBodyHtml = true;
                    msg.BodyEncoding = Encoding.ASCII;
                    msg.Body = Body;
                    try
                    {
                        foreach (var attach in attachments)
                        {

                            msg.Attachments.Add(attach);
                        }
                    }
                    catch { }
                    msg.From = new MailAddress("servicetools.starrag@gmail.com");
                    msg.To.Add(email.Email);
                    string username = "servicetools.starrag@gmail.com";  //email address or domain user for exchange authentication
                    string password = "Remember1";  //password
                    SmtpClient mClient = new SmtpClient();
                    mClient.Host = "smtp.gmail.com";
                    mClient.Port = 587;
                    mClient.UseDefaultCredentials = false;
                    mClient.Credentials = new NetworkCredential(username, password);
                    mClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    mClient.Timeout = 100000;
                    mClient.EnableSsl = true;
                    try
                    {
                        mClient.Send(msg);
                    }
                    catch
                    {
                        lock (_NotSentLock)
                        {
                            var e = new Email();
                            e.Address = EmailAddress.Create(email.Email);
                            e.Time = DateTime.Now;
                            e.Body = Body;
                            e.Subject = msg.Subject;
                            _Settings.NotSentEmails.Add(e);
                        }
                    }
                }
                catch { }
            }).Start();
            }
        }
        public static void SendEmailNotice(Notification notice, string subject = "", string Body = "")
        {
            Asset asset = new Asset();
            foreach (var a in Library.Assets)
            {
                if (a.AssetNumber == notice.AssetNumber)
                {
                    asset = a;
                }
            }
            foreach (var email in notice.Emails)
            {
                if (_DisableEmail == false)
                {
                    new System.Threading.Thread(() =>
                {

                    Body = Body.Replace("<name>", asset.ServiceEngineer);
                    Body = Body.Replace("<serviceTool>", asset.ItemName);
                    Body = Body.Replace("<serviceOrder>", asset.OrderNumber.ToString());
                    Body = Body.Replace("<dateAssigned>", asset.DateShipped.ToString());
                    Body = Body.Replace("<NL>", "<br />");
                    MailMessage msg = new MailMessage();
                    msg.Subject = "Asset Alert: " + asset.ItemName + ": " + subject + ": " + DateTime.Now.ToString();
                    msg.IsBodyHtml = true;
                    msg.BodyEncoding = Encoding.ASCII;
                    msg.Body = Body;
                    msg.From = new MailAddress("provider.service.secure@gmail.com");
                    msg.To.Add(email.Email);
                    string username = "provider.service.secure@gmail.com";  //email address or domain user for exchange authentication
                    string password = "@Service1";  //password
                    SmtpClient mClient = new SmtpClient();
                    mClient.Host = "smtp.gmail.com";
                    mClient.Port = 587;
                    mClient.UseDefaultCredentials = false;
                    mClient.Credentials = new NetworkCredential(username, password);
                    mClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    mClient.Timeout = 100000;
                    mClient.EnableSsl = true;
                    try
                    {
                        mClient.Send(msg);
                    }
                    catch
                    {
                        lock (_NotSentLock)
                        {
                            var e = new Email();
                            e.Address = EmailAddress.Create(email.Email);
                            e.Time = DateTime.Now;
                            e.Body = Body;
                            e.Subject = msg.Subject;
                            _Settings.NotSentEmails.Add(e);
                        }
                    }
                }).Start();
                }
            }
        }
        public static void Add30DayNotice(Notification notice)
        {
            lock(_30DayLock)
            {
                _Settings.Notifications_30_Day.Add(notice);
                _Notices.ThrityDayNotifications.Add(notice);
            }

        }
        public static void Add15DayNotice(Notification notice)
        {
            lock (_15DayLock)
            {
                _Settings.Notifications_15_Day.Add(notice);
                _Notices.FifteenDayNotifications.Add(notice);
            }
        }
        public static List<EmailAddress> StaticEmails = new List<EmailAddress>();
        public static string StandardCheckOutMessage = "";
        public static string StandardCheckInMessage = "";
        public static string StandardNotificationMessage = "";
       // public list
        private List<Asset> Assets = new List<Asset>();
        public MainForm()
        {
         //   Directory.SetCurrentDirectory(Path.Application.ExecutablePath());
            InitializeComponent();
            //var excelbook = ImportExcel("customers.xls");
            Serial.DataReceived += Serial_DataReceived;
            _instance = this;
            LOGO logo = new LOGO();
            logo.MdiParent = this;
            logo.Dock = DockStyle.Fill;
            logo.Show();
            logo.SendToBack();
            if (!Directory.Exists("Backup"))
            {
                Directory.CreateDirectory("Backup");
            }
            if (!File.Exists("Backup\\BackupSettings.bak"))
            {
                Backup b = new Backup();
                b.LastBackup = DateTime.Now;
                try
                {
                    string time = DateTime.Now.ToShortDateString();
                    time = time.Replace("/", "-");
                    File.Copy("Library.stal", "Backup\\Library-" + time + ".stal", true);
                    b.Write("Backup\\BackupSettings.bak");
                    _Backup = b;
                }
                catch { }
            }
            else
            {
                _Backup = Backup.Read("Backup\\BackupSettings.bak");
            }
            backupTimer.Enabled = true;
            if (!Directory.Exists("Images"))
            {
                Directory.CreateDirectory("Images");
            }
            if (!Directory.Exists("Labels"))
            {
                Directory.CreateDirectory("Labels");
            }
            if (!Directory.Exists("Barcodes"))
            {
                Directory.CreateDirectory("Barcodes");
            }
            if (!Directory.Exists("PackingLists"))
            {
                Directory.CreateDirectory("PackingLists");
            }
            if (File.Exists("StandardNotificationMessage.txt"))
            {
                StandardNotificationMessage = File.ReadAllText("StandardNotificationMessage.txt");
            }
            if (File.Exists("StandardShipperNotification.txt"))
            {
                StandardShipperNotification = File.ReadAllText("StandardShipperNotification.txt");
            }
            if (File.Exists("StandardCheckOutMessage.txt"))
            {
                StandardCheckOutMessage = File.ReadAllText("StandardCheckOutMessage.txt");
            }
            if (File.Exists("StandardCheckInMessage.txt"))
            {
                StandardCheckInMessage = File.ReadAllText("StandardCheckInMessage.txt");
            }
            if (File.Exists("Library.stal"))
            {
                Library = AssetLibrary.Read("Library.stal");
                updateStockLists();
                if (Library.Tag is Settings)
                {
                    _Settings = (Settings)Library.Tag;       

                    if (_Settings.LibraryPath==null)
                    {
                        _Settings.LibraryPath = DateTime.Now.ToShortDateString();
                    }
                    NotifiationViewer nv = new NotifiationViewer();
                    nv.clearAllNotificationsToolStripMenuItem.PerformClick();
                    nv.setNotificationsForAllToolStripMenuItem.PerformClick();
                }
            }
            else
            {
                Library.Tag = _Settings;
                Library.Write("Library.stal");
            }
            if (File.Exists("StaticEmails.txt"))
            {
                var lines = File.ReadLines("StaticEmails.txt");
                foreach(var line in lines)
                {
                    try {
                        var temp = line.Split(',');
                        EmailAddress ee = new EmailAddress();
                        ee.Name = temp[0];
                        ee.Email = temp[1];
                        StaticEmails.Add(ee);
                    } catch {
                    }
                }
                if (StaticEmails.Count==0)
                {
                    StaticEmails.Add(EmailAddress.Create("servicetools.starrag@gmail.com"));
                }
            }
            _Settings.ServiceEngineers = OpenEngineerFile("engineer.txt");
            _Settings.Customers = OpenCustomerFile("customers.csv");
            _Settings.ShippingPersons = OpenShippingPersonnelFile("shipping.txt").ToList();
            ShippingPersonnel = OpenEngineerFile("shipping.txt");

            NoticeTimer.Enabled = true;
        }
        private string[] OpenShippingPersonnelFile(string path)
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch { }
            return new string[] { "null"};
        }
        private List<EmailAddress> OpenEngineerFile(string path)
        {
            List<EmailAddress> addresses = new List<EmailAddress>();
            try
            {
                var lines = File.ReadAllLines(path);
                foreach(var line in lines)
                {
                    try
                    {
                        if (line.Contains(','))
                        {
                            string[] temp = line.Split(',');
                            var email = new EmailAddress();
                            email.Name = temp[0];
                            email.Email = temp[1];
                            addresses.Add(email);
                        }
                    }
                    catch { }
                }
            }
            catch { addresses.Add(EmailAddress.Create("null.null@null.com")); }
            return addresses;
        }
        private List<Customer> OpenCustomerFile(string path)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                var lines = File.ReadAllLines(path);
                int i = 0;
                foreach (var line in lines)
                {
                    if (i == 0) { } // skip header
                    else
                    {
                        try
                        {
                            if (line.Contains(','))
                            {
                                string[] temp = line.Split(',');
                                Customer customer = new Customer();                                
                                customer.CompanyName = temp[0];
                                customer.NickName= temp[1];
                                customer.Attn = temp[2];
                                customer.Address = temp[3];
                                customer.Address2 = temp[4];
                                customer.Address3 = temp[5];
                                customer.City = temp[6];
                                customer.State = temp[7];
                                customer.Postal = temp[8];
                                customer.Country = temp[9];
                                customer.Phone = temp[10];
                                //skip phone ext
                                customer.Email.Email = temp[12];
                                customer.Email.Name = customer.Attn;
                                //skip fax;
                                customer.ResInd = temp[14];
                                customer.LocID = temp[15];
                                customer.ConsInd = temp[16];
                                customer.AccountNumber = temp[17];
                                customer.AccPostalCd = temp[18];
                                customer.USPSPOBoxIND = temp[19];
                                customers.Add(customer);
                            }
                        }
                        catch { }
                        //Contact Fax,Res Ind,Loc ID,Cons Ind,Account Number,Acc Postal Cd,USPSPO Box IND

                    }
                    ++i;
                }
            }
            catch {
                var c = new Customer();
                c.CompanyName = "null";
                c.Address = "null";
                c.Attn = "null";
                customers.Add(c);
            }
            return customers;
        }
        private DataTable makeDataTableFromSheetName(string filename, string sheetName)
        {
            System.Data.OleDb.OleDbConnection myConnection = new System.Data.OleDb.OleDbConnection(
            "Provider=Microsoft.ACE.OLEDB.12.0; " +
            "data source='" + filename + "';" +
            "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\" ");

            DataTable dtImport = new DataTable();
            System.Data.OleDb.OleDbDataAdapter myImportCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + sheetName + "$]", myConnection);
            myImportCommand.Fill(dtImport);
            return dtImport;
        }
        public DataSet ImportExcel(string filename)
        {            
            System.Data.OleDb.OleDbConnection myConnection = new System.Data.OleDb.OleDbConnection(
                        "Provider=Microsoft.ACE.OLEDB.12.0; " +
                         "data source='" + filename + "';" +
                            "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\" ");
            myConnection.Open();
            DataTable mySheets = myConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            DataSet ds = new DataSet();
            DataTable dt;
            for (int i = 0; i <= mySheets.Rows.Count; i++)
            {
                dt = makeDataTableFromSheetName(filename, mySheets.Rows[i]["TABLE_NAME"].ToString());
                ds.Tables.Add(dt);
            }
            return ds;
        }
        public DataGridView CreateDataGridView(DataSet dataset, string tableName)
        {
            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.DataSource = dataset;
            dgv.DataMember = tableName;
            return dgv;
        }
        public void Serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            ScanAction sa = new ScanAction(Serial.ReadExisting());
            sa.Update = updateStockLists;
            sa.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AddAsset asa = new AddAsset();
            asa.ShowDialog();
            if (asa.Cancelled==false)
            {
                Asset asset = new Asset();
                asset = asa._asset;
                asset.IsOut = false;
                asset.ListItem = new ListViewItem();
                asset.ListItem.ImageIndex = 0;
                asset.ListItem.Text = asset.ListItem.Name = asset.ItemName+ ": ";
                asset.ListItem.Tag = asset;
                asset.ListItem.ToolTipText = asset.AssetNumber.ToString();
                var ON = new ListViewItem.ListViewSubItem(asset.ListItem, asset.AssetNumber.ToString());
                asset.ListItem.SubItems.Add(ON);
                var st = new ListViewItem.ListViewSubItem(asset.ListItem, asset.ShipTo);
                asset.ListItem.SubItems.Add(st);
                var de = new ListViewItem.ListViewSubItem(asset.ListItem, asset.Description);
                asset.ListItem.SubItems.Add(de);
                var ds = new ListViewItem.ListViewSubItem(asset.ListItem, asset.DateShipped.ToString());
                asset.ListItem.SubItems.Add(ds);
                var dr = new ListViewItem.ListViewSubItem(asset.ListItem, asset.DateRecieved.ToString());
                asset.ListItem.SubItems.Add(dr);
                var se = new ListViewItem.ListViewSubItem(asset.ListItem, asset.ServiceEngineer);
                asset.ListItem.SubItems.Add(se);
                var ps = new ListViewItem.ListViewSubItem(asset.ListItem, asset.PersonShipping);
                asset.ListItem.SubItems.Add(ps);

                //Library.InStock.Add(asset.ListItem);
                Library.Assets.Add(asset);
                updateStockLists();
            }
            asa.Close();
            
        }
        public void updateStockLists()
        {
            List<ListViewItem> checkedin = new List<ListViewItem>();
            List<ListViewItem> checkedout = new List<ListViewItem>();

            foreach(var asset in Library.Assets)
            {
                if (!asset.IsOut)
                {                    
                    asset.ListItem = new ListViewItem();
                    asset.ListItem.ImageIndex = 0;
                    asset.ListItem.Text = asset.AssetNumber.ToString() ;
                    asset.ListItem.Tag = asset;
                    asset.ListItem.ToolTipText = asset.AssetNumber.ToString();
                    var ON = new ListViewItem.ListViewSubItem(asset.ListItem, asset.ListItem.Name = asset.ItemName + ": ");
                    asset.ListItem.SubItems.Add(ON);
                    var st = new ListViewItem.ListViewSubItem(asset.ListItem, asset.ShipTo);
                    asset.ListItem.SubItems.Add(st);
                    var de = new ListViewItem.ListViewSubItem(asset.ListItem, asset.Description);
                    asset.ListItem.SubItems.Add(de);
                    var ds = new ListViewItem.ListViewSubItem(asset.ListItem, asset.DateShipped.ToString());
                    asset.ListItem.SubItems.Add(ds);
                    var dr = new ListViewItem.ListViewSubItem(asset.ListItem, asset.DateRecieved.ToString());
                    asset.ListItem.SubItems.Add(dr);
                    var se = new ListViewItem.ListViewSubItem(asset.ListItem, asset.ServiceEngineer);
                    asset.ListItem.SubItems.Add(se);
                    var ps = new ListViewItem.ListViewSubItem(asset.ListItem, asset.PersonShipping);
                    asset.ListItem.SubItems.Add(ps);
                    checkedin.Add(asset.ListItem);
                }
                else
                {
                    asset.ListItem = new ListViewItem();
                    asset.ListItem.ImageIndex = 0;
                    asset.ListItem.Text = asset.AssetNumber.ToString();
                    asset.ListItem.Tag = asset;
                    asset.ListItem.ToolTipText = asset.AssetNumber.ToString();
                    var ON = new ListViewItem.ListViewSubItem(asset.ListItem, asset.ListItem.Name = asset.ItemName + ": ");
                    asset.ListItem.SubItems.Add(ON);
                    var st = new ListViewItem.ListViewSubItem(asset.ListItem, asset.ShipTo);
                    asset.ListItem.SubItems.Add(st);
                    var de = new ListViewItem.ListViewSubItem(asset.ListItem, asset.Description);
                    asset.ListItem.SubItems.Add(de);
                    var ds = new ListViewItem.ListViewSubItem(asset.ListItem, asset.DateShipped.ToString());
                    asset.ListItem.SubItems.Add(ds);
                    var dr = new ListViewItem.ListViewSubItem(asset.ListItem, asset.DateRecieved.ToString());
                    asset.ListItem.SubItems.Add(dr);
                    var se = new ListViewItem.ListViewSubItem(asset.ListItem, asset.ServiceEngineer);
                    asset.ListItem.SubItems.Add(se);
                    var ps = new ListViewItem.ListViewSubItem(asset.ListItem, asset.PersonShipping);
                    asset.ListItem.SubItems.Add(ps);
                    checkedout.Add(asset.ListItem);
                }
            }
            InList.Items.Clear();
            InList.Sorting = SortOrder.Ascending;
            InList.Items.AddRange(checkedin.ToArray());
            OutList.Items.Clear();
            OutList.Sorting = SortOrder.Ascending;
            OutList.Items.AddRange(checkedout.ToArray());
        }
        private void assetList_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
        }

        private void assetList_ItemActivate(object sender, EventArgs e)
        {
            foreach(ListViewItem item in InList.SelectedItems)
            {
                if (item.Tag is Asset)
                {
                    foreach (var child in this.MdiChildren)
                    {
                        child.Close();
                    }
                    LOGO logo = new LOGO();
                    logo.MdiParent = this;
                    logo.Dock = DockStyle.Fill;
                    logo.Show();
                    logo.SendToBack();
                    AssetView av = new AssetView((Asset)item.Tag);
                    av.Dock = DockStyle.Fill;
                    av.MdiParent = this;
                    av.Show();
                }
            }
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void saveAssetLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Asset Library|*.stal";
            sfd.FileName = "Library.stal";
            sfd.ShowDialog();
            if (sfd.FileName!="")
            {
                try
                {
                    Library.Write(sfd.FileName);
                }catch(Exception ee)
                {
                    MessageBox.Show("Error Saving Asset Library\r\n" + ee.ToString());
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ScanAction sa = new ScanAction("0001");
            sa.Update = updateStockLists;
            sa.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void connectScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Serial.Open();
                if (Serial.IsOpen)
                {
                    ScannerConnectionStatus.Value = 100;
                }
            }
            catch { }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in InList.SelectedItems)
            {
                if (item.Tag is Asset)
                {
                    AssetView av = new AssetView((Asset)item.Tag);
                    av.MdiParent = this;
                    av.Show();
                    this.LayoutMdi(MdiLayout.TileHorizontal);
                    return;
                }
            }
            
        }

        private void removeFromStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in InList.SelectedItems)
            {
                if (item.Tag is Asset)
                {
                    ScanRemove av = new ScanRemove(((Asset)item.Tag).AssetNumber.ToString());
                    
                    av.ShowDialog();
                    //PARSE IT
                    return;
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in OutStockAssetList.SelectedItems)
            {
                if (item.Tag is Asset)
                {
                    AssetView av = new AssetView((Asset)item.Tag);
                    av.MdiParent = this;
                    av.Show();
                    this.LayoutMdi(MdiLayout.TileHorizontal);
                    return;
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in OutStockAssetList.SelectedItems)
            {
                if (item.Tag is Asset)
                {
                    ScanAdd av = new ScanAdd(((Asset)item.Tag).AssetNumber.ToString());
                    
                    av.ShowDialog();
                    //PARSE IT
                    return;
                }
            }
        }

        private void saveAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            foreach (ListViewItem item in InList.SelectedItems)
            {

                if (item.Tag is Asset)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Asset|*.staa";
                    sfd.FileName = ((Asset)item.Tag).ItemName+".staa";
                    sfd.ShowDialog();
                    try
                    {
                        ((Asset)item.Tag).Write(sfd.FileName);
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("Error Saving Asset File\r\n" + ee.ToString());
                    }
                    return;
                }
            }
        }

        private void openAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Assets|*.staa";
            ofd.ShowDialog();
            if (ofd.FileName!="")
            {
                try
                {

                    Asset asset = Asset.Read(ofd.FileName);
                    asset.ListItem = new ListViewItem();
                    asset.ListItem.ImageIndex = 0;
                    asset.ListItem.Text = asset.ListItem.Name = asset.ItemName + ": ";
                    asset.ListItem.Tag = asset;
                    asset.ListItem.ToolTipText = asset.AssetNumber.ToString();
                    var ON = new ListViewItem.ListViewSubItem(asset.ListItem, asset.AssetNumber.ToString());
                    asset.ListItem.SubItems.Add(ON);
                    var st = new ListViewItem.ListViewSubItem(asset.ListItem, asset.ShipTo);
                    asset.ListItem.SubItems.Add(st);
                    var de = new ListViewItem.ListViewSubItem(asset.ListItem, asset.Description);
                    asset.ListItem.SubItems.Add(de);
                    var ds = new ListViewItem.ListViewSubItem(asset.ListItem, asset.DateShipped.ToString());
                    asset.ListItem.SubItems.Add(ds);
                    var dr = new ListViewItem.ListViewSubItem(asset.ListItem, asset.DateRecieved.ToString());
                    asset.ListItem.SubItems.Add(dr);
                    var se = new ListViewItem.ListViewSubItem(asset.ListItem, asset.ServiceEngineer);
                    asset.ListItem.SubItems.Add(se);
                    var ps = new ListViewItem.ListViewSubItem(asset.ListItem, asset.PersonShipping);
                    asset.ListItem.SubItems.Add(ps);
                    Library.InStock.Add(asset.ListItem);
                    Library.Assets.Add(asset);
                    updateStockLists();
                }catch( Exception ee)
                {
                    MessageBox.Show("Error Loading Asset File\r\n"+ee.ToString());
                }
            }
        }

        private void newAssetLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reply = MessageBox.Show("Create A New Library?","", MessageBoxButtons.YesNo);
            if (reply == DialogResult.Yes)
            {
                Library = new AssetLibrary();
                updateStockLists();
            }
        }

        private void openAssetLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Asset Library|*.stal";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                try
                {
                    Library = AssetLibrary.Read(ofd.FileName);
                    foreach(var child in this.MdiChildren)
                    {
                        child.Close();
                    }
                    
                    updateStockLists();
                }
                catch { }
            }
        }

        private void OutList_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                MenuAsset = (Asset)((Asset)OutList.SelectedItems[0].Tag).Clone();
            }
            catch { }
            foreach (ListViewItem item in OutList.SelectedItems)
            {
                if (item.Tag is Asset)
                {
                    foreach (var child in this.MdiChildren)
                    {
                        child.Close();
                    }
                    LOGO logo = new LOGO();
                    logo.MdiParent = this;
                    logo.Dock = DockStyle.Fill;
                    logo.Show();
                    logo.SendToBack();
                    AssetView av = new AssetView((Asset)item.Tag);
                    av.Dock = DockStyle.Fill;
                    av.MdiParent = this;
                    av.Show();
                }
            }
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Directory.Exists("Assets"))
            {
                Directory.CreateDirectory("Assets");
            }
            foreach(var asseta in Library.Assets)
            {
                try
                {
                    if (File.Exists("Assets\\" + asseta.AssetNumber))
                    {
                        File.Delete("Assets\\" + asseta.AssetNumber);
                    }
                    asseta.Write("Assets\\" + asseta.AssetNumber);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
            }
            Library.Tag = _Settings;
            Library.Write("Library.stal");
        }

        private void scannerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScannerSettings ss = new ScannerSettings(Serial);
            ss.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in InList.SelectedItems)
            {
                if (item.Tag is Asset)
                {
                    Library.Assets.Remove(((Asset)item.Tag));
                    updateStockLists();
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in InList.SelectedItems)
            {
                if (item.Tag is Asset)
                {
                    Library.Assets.Remove(((Asset)item.Tag));
                    updateStockLists();
                }
            }
        }

        private void saveAssetToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            foreach (ListViewItem item in OutList.SelectedItems)
            {

                if (item.Tag is Asset)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Asset|*.staa";
                    sfd.FileName = ((Asset)item.Tag).ItemName + ".staa";
                    sfd.ShowDialog();
                    try
                    {
                        ((Asset)item.Tag).Write(sfd.FileName);
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("Error Saving Asset File\r\n" + ee.ToString());
                    }
                    return;
                }
            }
        }

        private void searchBtn_click(object sender, EventArgs e)
        {
            //search
            SearchResults sr = new SearchResults(searchBox.Text);
            
            
            foreach(var form in MdiChildren)
            {
                form.Close();
            }
            sr.MdiParent = this;
            sr.Dock = DockStyle.Fill;
            sr.Show();
        }
        
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.F8)
            HiddenScanField.Focus();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
           // this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar=='0')
            {
                HiddenScanField.Focus();
            }
        }
        private bool scanStart = false;
        private string tempbarcode = "";
        private int barcodecount = 0;
        public static string _Barcode = "";
        private void HiddenScanField_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void HiddenScanField_TextChanged(object sender, EventArgs e)
        {
            if (HiddenScanField.TextLength == 4)
            {
                barcodecount = 0;
                _Barcode = HiddenScanField.Text;
                HiddenScanField.Text = "";
                // ScanAction sa = new ScanAction(_Barcode);
                //sa.Update = updateStockLists;
                //if (!sa.IsDisposed)
                //sa.ShowDialog();
                bool isBadAssetNumber = true;
                bool isOut = false;
                foreach (var ass in MainForm.Library.Assets)
                {
                    if (ass.AssetNumber == _Barcode)
                    {                        
                        isBadAssetNumber = false;
                        isOut = ass.IsOut;
                    }
                }
                if (isBadAssetNumber)
                {
                    MessageBox.Show("Invalid asset number scanned");
                }else
                {
                    if (isOut)
                    {
                        ScanAdd sa = new ScanAdd(_Barcode);
                        sa.Update = updateStockLists;
                        sa.ShowDialog();
                    }
                    else
                    {
                        ScanRemove sa = new ScanRemove(_Barcode);
                        sa.Update = updateStockLists;
                        sa.ShowDialog();
                    }
                }
            }
        }

        private void OutList_ControlAdded(object sender, ControlEventArgs e)
        {
            //create notification
        }

        private void NoticeTimer_Tick(object sender, EventArgs e)
        {
            lock(_30DayLock)
            {
                List<Notification> noticesToRemove = new List<Notification>();
                foreach(var notice in _Settings.Notifications_30_Day)
                {
                    var aa = (DateTime.Now - notice.Time).TotalDays;
                        if (aa>=30)
                        {
                            var note = Notification.Create(notice.AssetNumber,notice.Emails);
                            note.LastNotified = DateTime.Now;
                            _Settings.Notifications_15_Day.Add(note);

                            SendEmailNotice(notice, "", StandardNotificationMessage);

                            noticesToRemove.Add(notice);                            
                        }                        
                    
                }
                foreach(var n in noticesToRemove)
                {
                    _Settings.Notifications_30_Day.Remove(n);
                }
            }//end 30 day lock
            lock (_15DayLock)
            {
                List<Notification> noticesToRemove = new List<Notification>();
                foreach (var notice in _Settings.Notifications_15_Day)
                {
                    var aa = (DateTime.Now - notice.LastNotified).TotalDays;
                    if (aa>= 15)
                    {
                        var note = Notification.Create(notice.AssetNumber, notice.Emails);
                        note.LastNotified = DateTime.Now;
                        note.IsNotified = notice.IsNotified;
                        _Settings.Notifications_15_Day.Add(note);
                        if (notice.IsNotified)
                            SendEmailNotice(notice, "", StandardNotificationMessage);
                        noticesToRemove.Add(notice);
                    }
                }
                foreach (var n in noticesToRemove)
                {
                    _Settings.Notifications_15_Day.Remove(n);
                }
            }//end 15 day lock
            lock(_NotSentLock)
            {
                List<Email> removals = new List<Email>();
                foreach(var msg in _Settings.NotSentEmails)
                {
                    SendUnsent(msg);
                    removals.Add(msg);                    
                }
                foreach(var rem in removals)
                {
                    _Settings.NotSentEmails.Remove(rem);
                }
            }
        }

        private void showNotificationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotifiationViewer nv = new NotifiationViewer(_Settings.Notifications_30_Day,_Settings.Notifications_15_Day);
            nv.ShowDialog();
        }

        private void generalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralSettings gs = new GeneralSettings();
            gs.ShowDialog();
        }

        private void printerSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            Print.OnFilePageSetup(this, new EventArgs());
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Print().printImg(icons.Images[0]);
           //Print.OnFilePrint(this, new EventArgs(), "printed page\r\nline2", InList.Font);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HiddenScanField.Focus();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created By Matthew Metzger \r\nMetzger.Matthew@gmail.com\r\nContact For Help and Development or Source\r\nMulti License, This Version, Use By Starrag Group, Inc Only") ;
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //change ownership

        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InList.View = View.Details;
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InList.View = View.List;
        }

        private void iconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InList.View = View.LargeIcon;
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InList.View = View.SmallIcon;
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InList.View = View.Tile;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            OutList.View = View.Details;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            OutList.View = View.List;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            OutList.View = View.LargeIcon;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            OutList.View = View.SmallIcon;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            OutList.View = View.Tile;
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            
        }
        public bool spliterDown = false;
        private void splitter1_MouseDown(object sender, MouseEventArgs e)
        {
            spliterDown = true;
        }

        private void splitter1_MouseUp(object sender, MouseEventArgs e)
        {
            spliterDown = false;
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void splitter1_MouseMove(object sender, MouseEventArgs e)
        {
            if (spliterDown)
            {
                panel1.Width = panel1.Width + e.X;
            }
        }

        private void editModeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (editPassword.Text=="StarragUS")
            {
                addAssetBtn.Visible = true;
                openassetfilebtn.Visible = true;
                disableEmailToolStripMenuItem.Visible = true;
                _EDITMODE = true;
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }

        private void pauseScannerFocasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pauseScannerFocasToolStripMenuItem.Checked)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void addToNotficationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (MenuAsset!=null)
            {
                if (MenuAsset.AssetNumber != "")
                {
                    Notification notice = Notification.Create(MenuAsset.AssetNumber, MainForm.StaticEmails);
                    foreach (var email in MainForm._Settings.ServiceEngineers)
                    {
                        if (email.Name == MenuAsset.ServiceEngineer)
                        {
                            notice.Emails.Add(email);
                        }
                    }
                    notice.IsNotified = true;
                    MainForm.Add30DayNotice(notice);
                }
                else
                {
                    MessageBox.Show("Please Hover Over Asset Then Right Click");
                }
            }
            
            
        }

        private void backupTimer_Tick(object sender, EventArgs e)
        {
            var days = (DateTime.Now - _Backup.LastBackup).TotalDays;
            if (days>=30)
            {
                //EMAIL BACKUP FILE
                Backup b = new Backup();
                b.LastBackup = DateTime.Now;
                try
                {
                    string date = DateTime.Now.ToShortDateString();
                    date = date.Replace("/", "-");
                    File.Copy("Library.stal", "Backup\\Library-" + date + ".stal", true);
                    b.Write("Backup\\BackupSettings.bak");
                    _Backup = b;
                    List<Attachment> attachments = new List<Attachment>();
                    Attachment backup = new Attachment("Library.stal", "Backup\\Library-" + date + ".stal");
                    SendBackupReport(EmailAddress.Create("servicetools.starrag@gmail.com"), "***Backup " + DateTime.Now.ToShortDateString(), "Library Backup " + DateTime.Now.ToShortDateString(), attachments);
                }
                catch { }
            }
        }
        public Asset MenuAsset = new Asset();
        private void OutList_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            if (e.Item.Tag is Asset)
            {
                MenuAsset = (Asset)((Asset)e.Item.Tag).Clone();
            }
        }

        private void InList_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            if (e.Item.Tag is Asset)
            {
                MenuAsset = (Asset)((Asset)e.Item.Tag).Clone();
            }
        }
        private static void PrintLabelImage(Image img, bool print = true, bool previewPrints=false)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.Landscape = false; //or false!
                Margins margins = new Margins(25, 25, 35, 25);
                pd.DefaultPageSettings.Margins = margins;
                pd.PrintPage += (s, args) =>
                {
                    Image i = img;
                    Rectangle m = args.MarginBounds;

                    if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width); //devide by 2 to get half page if is label
                    }
                    else
                    {
                        m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                    }
                    args.Graphics.DrawImage(i, m);
                };
                if (previewPrints)
                {
                    PrintPreviewDialog ppd = new PrintPreviewDialog();
                    ppd.Document = pd;
                    ppd.ShowDialog();
                }

                if (print)
                {

                    PrintDialog pdiag = new PrintDialog();
                    pdiag.Document = pd;
                    var result = pdiag.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        pdiag.Document.Print();
                    }
                }
                else
                {

                }
            }
            catch { }
        }
        public static List<Image> PrintAssetLabels(bool print=true,bool preview=true)
        {
            //Print asset Labels
            List<Image> IL = new List<Image>();
            List<Avery5160StickerTemplate> pages = new List<Avery5160StickerTemplate>();
            List<List<Asset>> AssetList = new List<List<Asset>>();
            int idx = 0;
            List<Asset> assets = new List<Asset>();
            for (int x = 0; x < Library.Assets.Count; ++x)
            {
                if (idx == 30)
                {
                    AssetList.Add(assets);
                    assets = new List<Asset>();
                    idx = 0;
                }
                assets.Add(Library.Assets[x]);
                ++idx;
            }
            if (assets.Count < 30)
                AssetList.Add(assets);
            foreach (var list in AssetList)
            {
                Avery5160StickerTemplate labels = new Avery5160StickerTemplate(list);
                pages.Add(labels);
                labels.Show();
                labels.tableLayoutPanel1.Focus();
                labels.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
                Bitmap img = new Bitmap(labels.tableLayoutPanel1.Width, labels.tableLayoutPanel1.Height);
                img.SetResolution(60.0f, 60.0f);
                labels.tableLayoutPanel1.DrawToBitmap(img, labels.tableLayoutPanel1.ClientRectangle);
                labels.Close();
                IL.Add(img);
            }
            foreach (var img in IL)
            {
                PrintLabelImage(img, print, preview);
            }
            return IL;
        }
        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintAssetLabels(true,false);
            
        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintAssetLabels(false, true);
        }

        private void selectLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DescriptionLabelPrinterForm dlf = new DescriptionLabelPrinterForm();
            dlf.ShowDialog();
        }

        private void editPassword_Enter(object sender, EventArgs e)
        {
           
             
        }

        private void editPassword_Leave(object sender, EventArgs e)
        {
            
                //timer1.Enabled = true;
           
        }

        private void editPassword_Click(object sender, EventArgs e)
        {
            //timer1.Enabled = false;

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRateForm grf = new GetRateForm();
            grf.ShowDialog();
        }
        private static bool _DisableEmail = false;
        private void disableEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DisableEmail = disableEmailToolStripMenuItem.Checked;
            if (_DisableEmail)
            {
                disableEmailToolStripMenuItem.BackColor = Color.Red;
            }
            else
            {
                disableEmailToolStripMenuItem.BackColor = Color.Lime;
            }
        }

        private void printBarcodeLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintBarcodes pb = new PrintBarcodes();
            pb.ShowDialog();
        }
    }
    public class Print
    {
        public static  Image img;
        public  PrintDocument printImg(Image obj)
        {
            PrintDocument document = new PrintDocument();
            using (Bitmap printImage = new Bitmap(obj.Width, obj.Height))
            {
                //Draw the TableLayoutPanel control to the temporary bitmap image
               // obj.DrawToBitmap(printImage, new Rectangle(0, 0, printImage.Width, printImage.Height));
                img = obj;
                //(...your code continues here, except that now you
                // will print the temporary image you just created)
                PrintPreviewDialog ppd = new PrintPreviewDialog();
                document.PrintPage += Document_PrintPage;
                ppd.Document = document;
                ppd.ShowDialog();
                //ppd.Document.Print();
                return ppd.Document;
            }
        }

        private void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(img, new PointF(0, 0));
    }

        public class Document : PrintDocument
        {
            String _text = "";
            Font _font = null;
            Int32 _offset = 0;
            Int32 _pageno = 0;

            public Document()
            {
            }

            public String Text
            {
                get { return _text; }
                set { _text = value; }
            }

            public Font Font
            {
                get { return _font; }
                set { _font = value; }
            }

            protected override void OnBeginPrint(PrintEventArgs e)
            {
                _offset = 0;
                _pageno = 1;

                base.OnBeginPrint(e);
            }

            Boolean NextCharIsNewLine()
            {
                Int32 nl = Environment.NewLine.Length;
                Int32 tl = _text.Length - _offset;

                if (tl < nl) return false;

                String newline = Environment.NewLine;

                for (Int32 i = 0; i < nl; i++)
                {
                    if (_text[_offset + i] != newline[i])
                        return false;
                }

                return true;
            }

            const Int32 Eos = -1;
            const Int32 NewLine = -2;

            Int32 NextChar()
            {
                if (_offset >= this._text.Length)
                    return -1;

                if (NextCharIsNewLine())
                {
                    _offset += Environment.NewLine.Length;
                    return -2;
                }

                return (Int32)_text[_offset++];
            }

            protected override void OnPrintPage(PrintPageEventArgs e)
            {
                base.OnPrintPage(e);

                Single pagewidth = e.MarginBounds.Width * 3.0f;
                Single pageheight = e.MarginBounds.Height * 3.0f;

                Single textwidth = 0.0f;
                Single textheight = 0.0f;

                Single offsetx = e.MarginBounds.Left * 3.0f;
                Single offsety = e.MarginBounds.Top * 3.0f;

                Single x = offsetx;
                Single y = offsety;

                StringBuilder line = new StringBuilder(256);
                StringFormat sf = StringFormat.GenericTypographic;
                sf.FormatFlags = StringFormatFlags.DisplayFormatControl;
                sf.SetTabStops(0.0f, new Single[] { 300.0f });

                RectangleF r;

                Graphics g = e.Graphics;
                g.PageUnit = GraphicsUnit.Document;

                SizeF size = g.MeasureString("X", _font, 1, sf);
                Single lineheight = size.Height;

                // make sure we can print at least 1 line (font too big?)
                if (lineheight + (lineheight * 3) > pageheight)
                {

                    // cannot print at least 1 line and footer
                    g.Dispose();

                    e.HasMorePages = false;

                    return;
                }

                // don't include footer
                pageheight -= lineheight * 3;

                // last whitespace in line buffer
                Int32 lastws = -1;

                // next character
                Int32 c = Eos;

                for (;;)
                {

                    // get next character
                    c = NextChar();

                    // append c to line if not NewLine or Eos
                    if ((c != NewLine) && (c != Eos))
                    {
                        Char ch = Convert.ToChar(c);
                        line.Append(ch);

                        // if ch is whitespace, remember pos and continue
                        if (ch == ' ' || ch == '\t')
                        {
                            lastws = line.Length - 1;
                            continue;
                        }
                    }

                    // measure string if line is not empty
                    if (line.Length > 0)
                    {
                        size = g.MeasureString(line.ToString(), _font, Int32.MaxValue,
                            StringFormat.GenericTypographic);
                        textwidth = size.Width;
                    }

                    // draw line if line is full, if NewLine or if last line
                    if (c == Eos || (textwidth > pagewidth) || (c == NewLine))
                    {
                        if (textwidth > pagewidth)
                        {
                            if (lastws != -1)
                            {
                                _offset -= line.Length - lastws - 1;
                                line.Length = lastws + 1;
                            }
                            else
                            {
                                line.Length--;
                                _offset--;
                            }
                        }

                        // there's something to draw
                        if (line.Length > 0)
                        {
                            r = new RectangleF(x, y, pagewidth, lineheight);
                            sf.Alignment = StringAlignment.Near;
                            g.DrawString(line.ToString(), _font, Brushes.Black, r, sf);
                        }

                        // increase ypos
                        y += lineheight;
                        textheight += lineheight;

                        // empty line buffer
                        line.Length = 0;
                        textwidth = 0.0f;
                        lastws = -1;
                    }

                    // if next line doesn't fit on page anymore, exit loop
                    if (textheight > (pageheight - lineheight))
                        break;

                    if (c == Eos)
                        break;
                }

                // print footer
                x = offsetx;
                y = offsety + pageheight + (lineheight * 2);
                r = new RectangleF(x, y, pagewidth, lineheight);
                sf.Alignment = StringAlignment.Center;
                g.DrawString(_pageno.ToString(), _font, Brushes.Black, r, sf);

                g.Dispose();

                _pageno++;

                e.HasMorePages = (c != Eos);
            }

            protected override void OnEndPrint(PrintEventArgs e)
            {
                base.OnEndPrint(e);
            }

        }
        public static Document _Document = new Document();
        public static void OnFilePrint(Object sender, EventArgs e, string text, Font font)
        {
            PrintDialog pd = new PrintDialog();
            _Document.Text = text;
            _Document.Font = font;
            pd.Document = _Document;
            pd.ShowDialog();
            pd.Document.Print();
        }

        public static void OnFilePrintPreview(Object sender, EventArgs e,string text, Font font)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            _Document.Text = text;
            _Document.Font = font;
            ppd.Document = _Document;
            ppd.ShowDialog();
        }

        public static void OnFilePageSetup(Object sender, EventArgs e)
        {
            PageSetupDialog psd = new PageSetupDialog();
            psd.Document = _Document;
            psd.ShowDialog();
        }
    }
    [Serializable]
    public struct Email
    {
        public EmailAddress Address;
        public string Subject;
        public string Body;
        public object Attachments;
        public DateTime Time;
    }
    [Serializable]
    public struct EmailAddress
    {
        public static EmailAddress Create(string email)
        {

            EmailAddress e = new EmailAddress();
            e.Email = email;
            if (!e.Email.Contains("@"))
            {
                e.Email = "servicetools.starrag@gmail.com";
            }
            try
            {
                if (email.Contains("@"))
                {
                    var temp = email.Split('@');
                    e.Name = temp[0];
                    if (temp[0].Contains("."))
                    {
                        e.Name = temp[0].Replace(".", " ");
                    }
                }
            }
            catch
            {
                e.Name = e.Email;
            }
            
            return e;
        }
        public string Name;
        public string Email;
    }
    [Serializable]
    public class Customer
    {
        public Customer()
        {
        }
        public static Customer Create(string coName, string attn,string address, string phone, string fax,EmailAddress email)
        {
            Customer c = new Customer();
            c.CompanyName = coName;
            c.Attn = attn;
            c.Address = address;
            c.Phone = phone;
            c.Fax = fax;
            c.Email = email;
            return c;
        }
        public string CompanyName="";
        public string Attn = "";
        public string Address = "";
        public string Address2 = "";
        public string Address3 = "";
        public string City = "";
        public string State = "";
        public string NickName;
        public string ResInd;
        public string LocID;
        public string ConsInd;
        public string AccountNumber;
        public string AccPostalCd;
        public string USPSPOBoxIND;
        public string Postal = "";
        public string Country = "";
        public string PackageWeight = "";
        public string Phone="";
        public string Fax="";
        public EmailAddress Email = new EmailAddress();
        public List<string> OrderNumbers = new List<string>();
        public string OrderNumber = "";
        public List<string> CurrentAssignedAssets = new List<string>();
        public object Tag=null;
    }
    [Serializable]
    public class Engineer
    {
        public Engineer()
        { }
        public static Engineer Create(string name, string address, string phone,EmailAddress email)
        {
            Engineer e = new Engineer();
            e.Name = name;
            e.Address = address;
            e.Phone = phone;
            e.Email = email;
            return e;
        }
        public string Name = "";
        public string Address = "";
        public string Phone = "";
        public EmailAddress Email = new EmailAddress();
        public object Tag = null;
    }
    [Serializable]
    public class NotificationLibrary
    {
        public void Write(string path)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, this);
                }
            }
            catch { }
        }
        public static NotificationLibrary Read(string path)
        {
            NotificationLibrary obj = new NotificationLibrary();
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path,
                                          FileMode.Open,
                                          FileAccess.Read,
                                          FileShare.Read);
                obj = (NotificationLibrary)formatter.Deserialize(stream);
                stream.Close();
            }
            catch { }
            return obj;
        }
        public NotificationLibrary()
        {

        }
        public List<Notification> ThrityDayNotifications = new List<Notification>();
        public List<Notification> FifteenDayNotifications = new List<Notification>();
    }
    [Serializable]
    public class Backup
    {
        public void Write(string path)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, this);
                }
            }
            catch { }
        }
        public static Backup Read(string path)
        {
            Backup obj = new Backup();
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path,
                                          FileMode.Open,
                                          FileAccess.Read,
                                          FileShare.Read);
                obj = (Backup)formatter.Deserialize(stream);
                stream.Close();
            }
            catch { }
            return obj;
        }
        public Backup()
        {

        }
        public DateTime LastBackup;
        public object Tag;
        public object Tag2;
    }
    [Serializable]
    public struct Notification
    {
        public static Notification Create(string assetNumber, List<EmailAddress> emails, bool isNotified=false)
        {
            Notification n = new Notification();
            n.Emails = new List<EmailAddress>();
            n.Emails.AddRange(emails);
            n.AssetNumber = assetNumber;
            n.Time = DateTime.Now;
            n.LastNotified = DateTime.Now;
            n.IsNotified = isNotified;
            return n;
        } 
        public List<EmailAddress> Emails;
        public string AssetNumber;
        public DateTime Time;
        public DateTime LastNotified;
        public bool IsNotified;
        public object Tag;

    }
    [Serializable]
    public class Settings
    {
        public static Settings GetInstance()
        {
            return new Settings();
        }
        public Settings()
        {

        }
        public void Write(string path)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, this);
                }
            }
            catch { }
        }
        public static Settings Read(string path)
        {
            Settings obj = new Settings();
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path,
                                          FileMode.Open,
                                          FileAccess.Read,
                                          FileShare.Read);
                obj = (Settings)formatter.Deserialize(stream);
                stream.Close();
            }
            catch { }
            return obj;
        }
        public string LibraryPath;
        public string AssetsPath;
        public List<Notification> Notifications_30_Day = new List<Notification>();
        public List<Notification> Notifications_15_Day = new List<Notification>();
        public List<Email> NotSentEmails = new List<Email>();
        public List<Email> d = new List<Email>();
        public List<EmailAddress> ServiceEngineers = new List<EmailAddress>();
        public List<Customer> Customers;
        public List<EmailAddress> StaticEmails;
        public List<string> ShippingPersons;

    }
    [Serializable]
    public class Asset: ICloneable
    {
        public void Write(string path)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, this);
                }
            }
            catch { }
        }
        public static Asset Read(string path)
        {
            Asset obj = new Asset();
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path,
                                          FileMode.Open,
                                          FileAccess.Read,
                                          FileShare.Read);
                obj = (Asset)formatter.Deserialize(stream);
                stream.Close();
            }
            catch { }            
            return obj;
        }
        public static Asset Create(string assetName = "", string assetNumber = "")
        {
            Asset ass = new Asset();
            ass.ItemName = assetName;
            ass.AssetNumber = assetNumber;
            return ass;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public Asset()
        {

        }
        public List<string> Images = new List<string>();
        public string ItemName = "";
        public int OrderNumber = 0;
        public string ShipTo = "";
        public DateTime DateShipped;
        public DateTime DateRecieved;
        public string ServiceEngineer = "";
        public string PersonShipping = "";
        public string Barcode = "";
        public string AssetNumber = "0000";
        public string Description;
        public object Tag = null;
        public object Tag2 = null;
        public object Tag3 = null;
        public object Tag4 = null;
        public string BarcodeImage;
        public bool IsOut = false;
        public decimal weight = 0;
        public string A = "";
        public string B = "";
        public string C = "";
        public string D = "false";
        public string E = "";
        public string F = "";
       
        public List<Asset> History = new List<Asset>();
        [NonSerialized]
        public ListViewItem ListItem = new ListViewItem("Asset");
    }
    [Serializable]
    public class AssetLibrary
    {
        public void Write(string path)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, this);
                }
            }
            catch { }            
        }
        public static AssetLibrary Read(string path)
        {
            AssetLibrary obj = new AssetLibrary();
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path,
                                          FileMode.Open,
                                          FileAccess.Read,
                                          FileShare.Read);
                obj = (AssetLibrary)formatter.Deserialize(stream);
                stream.Close();
            }
            catch { }
            return obj;
        }

        public List<Asset> Assets = new List<Asset>();
        public List<ListViewItem> InStock = new List<ListViewItem>();
        public List<ListViewItem> OutStock = new List<ListViewItem>();
        public string Name;
        public string Filename;
        public object Tag;
        public AssetLibrary()
        {

        }

    }
}
