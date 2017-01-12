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
    public partial class ScanAdd : Form
    {
        public delegate void updateList();
        public updateList Update;
        public Asset _asset;
        public ScanAdd()
        {
            InitializeComponent();
        }
        public ScanAdd(string barcode)
        {
            InitializeComponent();
            ServiceEngineerEmail = MainForm.StaticEmails.FirstOrDefault();
            foreach (var asset in MainForm.Library.Assets)
            {
                if (asset.AssetNumber.Equals(barcode))
                {

                    _asset = asset;
                    try
                    {
                        if (_asset.Images.Count > 0)
                            img.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(_asset.Images[0])));
                    }
                    catch { }
                    try
                    {
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
                    
                    foreach(var engi in MainForm._Settings.ServiceEngineers)
                    {
                        if (engi.Name==engineer.Text)
                        {
                            ServiceEngineerEmail = engi;
                        }
                    }
                    break;
                }

            }
            if (_asset == null)
            {
                MessageBox.Show("No Asset Found Matching Scanned Asset Number: " + barcode);
                this.Close();
            }
        }

        private void ScanAdd_Load(object sender, EventArgs e)
        {

        }
        public EmailAddress ServiceEngineerEmail = new EmailAddress();
        public ReceivingReport CreateReceivingReport()
        {

            ReceivingReport r = new ReceivingReport();
            try
            {
                r.OrderNumber.Text = orderNumber.Text;
                r.Date.Text = DateTime.Now.ToShortDateString();
                r.ShipperName.Text = shipper.Text;
                r.SenderName.Text = shipTo.Text;
                if (_asset.D == "true")
                {
                    r.IsBad.Text = "Bad";
                }
                else
                {
                    r.IsBad.Text = "Good";
                }
                r.textBox1.Text = _asset.AssetNumber;
                r.textBox2.Text = "1";
                r.textBox3.Text = _asset.ItemName;
                r.textBox4.Text = _asset.Description;
            }
            catch { }
            return r;
        }

        private void removebtn_Click(object sender, EventArgs e)
        {
            var report = CreateReceivingReport();
            PrintReceivingReport prp = new PrintReceivingReport(report);
            prp.ShowDialog();

            try
            {
                foreach (var email in MainForm.StaticEmails)
                {
                    _asset.OrderNumber = Convert.ToInt32(orderNumber.Text);
                    MainForm.SendEmailReport(_asset, email, "", MainForm.StandardCheckInMessage);
                }
            }
            catch { }
            try
            {
                _asset.OrderNumber = Convert.ToInt32(orderNumber.Text);
                MainForm.SendEmailReport(_asset, ServiceEngineerEmail, "", MainForm.StandardCheckInMessage);
            }
            catch { }
            var ass = new Asset();
            ass = (Asset)_asset.Clone();
            lock(MainForm._30DayLock)
            {
                try
                {
                    bool skip = false;
                    List<Notification> notices = new List<Notification>();
                    foreach (var notice in MainForm._Settings.Notifications_30_Day)
                    {
                        if (skip) break;
                        foreach (var asset in MainForm.Library.Assets)
                        {
                            if (asset.AssetNumber == notice.AssetNumber)
                            {
                                notices.Add(notice);
                                skip = true;
                                break;
                            }
                        }
                    }
                    foreach (var notice in notices)
                    {
                        MainForm._Settings.Notifications_30_Day.Remove(notice);
                    }
                }
                catch { }           
            }
            lock (MainForm._15DayLock)
            {
                bool skip = false;
                List<Notification> notices = new List<Notification>();
                foreach (var notice in MainForm._Settings.Notifications_15_Day)
                {
                    if (skip) break;
                    foreach (var asset in MainForm.Library.Assets)
                    {
                        if (asset.AssetNumber == notice.AssetNumber)
                        {
                            notices.Add(notice);
                            skip = true;
                            break;
                        }
                    }
                }
                foreach (var notice in notices)
                {
                    MainForm._Settings.Notifications_15_Day.Remove(notice);
                }
            }

            if (isDamaged.Checked)
            {
                _asset.D = "true";
            }
            else
            {
                _asset.D = "false";
            }
            ass.Images = null;
            ass.BarcodeImage = null;
            
            if (_asset.History.Count==10)
            {
                _asset.History.Remove(_asset.History.FirstOrDefault());
            }
            _asset.History.Add(ass);
            _asset.IsOut = false;
            _asset.DateRecieved = DateTime.Now;
            _asset.DateShipped = DateTime.Now;
            _asset.OrderNumber = -1;
            _asset.ShipTo = "";
            _asset.ServiceEngineer = "";
            _asset.PersonShipping = "";

            Update?.Invoke();
            foreach (var form in MainForm._instance.MdiChildren)
            {
                form.Close();
            }
            LOGO logo = new LOGO();
            logo.MdiParent = MainForm._instance;
            logo.Dock = DockStyle.Fill;
            logo.Show();
            logo.SendToBack();
            this.Close();
        }

        private void isDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if (isDamaged.Checked)
            {
                _asset.D = "true";
            }
            else
            {
                _asset.D = "false";
            }
        }
    }
}
