using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Asset_Managment
{
    public partial class ScanRemove : Form
    {
        public delegate void updateList();
        public updateList Update;
        public Asset _asset;
        public List<string> Barcodes = new List<string>();
        public ScanRemove()
        {
            InitializeComponent();
        }
        public ScanRemove(string barcode)
        {
            InitializeComponent();
            ServiceEngineerEmail = MainForm.StaticEmails.FirstOrDefault();
            foreach (var asset in MainForm.Library.Assets)
            {
                if (asset.AssetNumber.Equals(barcode))
                {
                   
                        _asset = asset;
                    try { 
                        if (_asset.Images.Count > 0)
                            img.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(_asset.Images[0])));
                    
                        var image = MainForm.CreateBarcodeImage(_asset.AssetNumber, Zen.Barcode.BarcodeSymbology.Code39NC);
                        Barcode.Image = image;
                    }
                    catch { }
                    AssetName.Text = _asset.ItemName;
                        assetNo.Text = _asset.AssetNumber.ToString();
                        shipTo.Text = _asset.ShipTo;
                        engineer.Text = _asset.ServiceEngineer;
                        shipper.Text = _asset.PersonShipping;
                        orderNumber.Text = _asset.OrderNumber.ToString();                    
                    break;
                }
                
            }
            if (_asset==null)
            {
                MessageBox.Show("No Asset Found Matching Scanned Asset Number: " + barcode);
                this.Close();
            }
           // kitbox.Items.Add(barcode);

        }
        private void ScanRemove_Load(object sender, EventArgs e)
        {
            List<string> Items = new List<string>();
            foreach(var customer in MainForm._Settings.Customers)
            {
                shipTo.Items.Add(customer.CompanyName);
                Items.Add(customer.CompanyName);
            }
            shipTo.Focus();
            shipTo.Sorted = true;
            shipTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            shipTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            shipTo.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            shipTo.AutoCompleteCustomSource.AddRange(Items.ToArray());
            
            foreach (var ee in MainForm._Settings.ServiceEngineers)
            {
                engineer.Items.Add(ee.Name);
            }
            foreach(var sh in MainForm.ShippingPersonnel)
            {
                shipper.Items.Add(sh.Name);
            }
        }

        private void AssetName_TextChanged(object sender, EventArgs e)
        {

        }

        private void assetNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void shipTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _asset.ShipTo = shipTo.Text;
        }

        private void orderNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _asset.OrderNumber = Convert.ToInt32(orderNumber.Value);
            }
            catch
            {
                MessageBox.Show("Numbers Only");
            }
        }

        private void engineer_SelectedIndexChanged(object sender, EventArgs e)
        {
            _asset.ServiceEngineer = engineer.Text;
            foreach(var ee in MainForm._Settings.ServiceEngineers)
            {
                if (ee.Name== _asset.ServiceEngineer)
                {
                    ServiceEngineerEmail = ee;
                }
            }
        }

        private void shipper_SelectedIndexChanged(object sender, EventArgs e)
        {
            _asset.PersonShipping = shipper.Text;
        }
        public EmailAddress ServiceEngineerEmail = new EmailAddress();
        private void removebtn_Click(object sender, EventArgs e)
        {
            List<Asset> CheckoutList = new List<Asset>();
            if (_asset.ShipTo != "" && _asset.ServiceEngineer != "" && _asset.PersonShipping != "" && _asset.OrderNumber!=-1)
            {
                CheckoutList.Add(_asset);
                _asset.IsOut = true;
                _asset.DateShipped = DateTime.Now;
                foreach(var email in MainForm.StaticEmails) // send to static group
                {
                    MainForm.SendEmailReport(_asset, email,"", MainForm.StandardCheckOutMessage);
                }
                //send to service engineer
                try
                {
                    MainForm.SendEmailReport(_asset, ServiceEngineerEmail, "", MainForm.StandardCheckOutMessage);
                }
                catch { }
                
                Notification notice = Notification.Create(_asset.AssetNumber, MainForm.StaticEmails);
                notice.Emails.Add(ServiceEngineerEmail);
                notice.IsNotified = true;
                MainForm.Add30DayNotice(notice);
                foreach(var code in Barcodes)
                {
                    foreach(var asset in MainForm.Library.Assets)
                    {
                        if (asset.AssetNumber==code)
                        {
                            asset.IsOut = true;
                            asset.DateShipped = DateTime.Now;
                            asset.ShipTo = _asset.ShipTo;
                            asset.PersonShipping = _asset.PersonShipping;
                            asset.ServiceEngineer = _asset.ServiceEngineer;
                            asset.OrderNumber = _asset.OrderNumber;
                            CheckoutList.Add(asset);

                            Notification note = Notification.Create(asset.AssetNumber, MainForm.StaticEmails);
                            note.Emails.Add(ServiceEngineerEmail);
                            note.IsNotified = true;
                            MainForm.Add30DayNotice(note);
                            try
                            {
                                foreach (var email in MainForm.StaticEmails)
                                {
                                    MainForm.SendEmailReport(asset, email, "", MainForm.StandardCheckOutMessage);
                                }
                            }
                            catch { }
                            try
                            {
                                MainForm.SendEmailReport(asset, ServiceEngineerEmail, "", MainForm.StandardCheckOutMessage);
                            }
                            catch { }
                            try
                            {
                                foreach(var shippr in MainForm.ShippingPersonnel)
                                {
                                    if (shippr.Name== shipper.Text)
                                    {
                                        MainForm.SendEmailReport(asset, shippr,"", MainForm.StandardShipperNotification);
                                    }
                                }
                                
                            }
                            catch { }
                        }
                    }
                }
                foreach (var form in MainForm._instance.MdiChildren)
                {
                    form.Close();
                }
                LOGO logo = new LOGO();
                logo.MdiParent = MainForm._instance;
                logo.Dock = DockStyle.Fill;
                logo.Show();
                logo.SendToBack();
                Update?.Invoke();
                //CREATE LABELS FOR SHIPPING HERE
                Customer customer = null;
                
                foreach(var cust in MainForm._Settings.Customers)
                {
                    if (cust.CompanyName==shipTo.Text)
                    {
                        customer = cust;
                    }
                }
                if (customer != null)
                {
                    Barcodes.Add(_asset.AssetNumber);
                    customer.NickName = shipper.Text;
                    shippingForm sf = new shippingForm( Barcodes,customer);
                    sf.ShowDialog();
                }
                else
                {
                    //new customer
                    Customer nc = new Customer();
                    nc.CompanyName = shipTo.Text;
                    Barcodes.Add(_asset.AssetNumber);
                    shippingForm sf = new shippingForm(Barcodes, nc);
                    sf.ShowDialog();
                    
                }
                this.Close();
            }
            else
            { MessageBox.Show("Please Fill Out All Forms\r\nNote* Order Number Must be Real Value");}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddAdditionalKit add = new AddAdditionalKit(_asset.AssetNumber);
            add.ShowDialog();
            if (add.Barcodes.Count>0)
            {
                foreach(var code in add.Barcodes)
                {
                    kitbox.Items.Add(code);
                    Barcodes.Add(code);
                }
            }

        }

        private void orderNumber_Click(object sender, EventArgs e)
        {
            orderNumber.Select(0,2);
        }

        private void shipTo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _asset.ShipTo = shipTo.Text;
        }

        private void engineer_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _asset.ServiceEngineer = engineer.Text;
            foreach (var ee in MainForm._Settings.ServiceEngineers)
            {
                if (ee.Name == _asset.ServiceEngineer)
                {
                    ServiceEngineerEmail = ee;
                }
            }
        }

        private void shipper_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _asset.PersonShipping = shipper.Text;
        }
    }
}
