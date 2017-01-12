using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMXShipping;
using System.Drawing.Printing;
using System.IO;
using ShippingAPI;
using System.Net.Mail;

namespace Asset_Managment
{
    public partial class shippingForm : Form
    {

        public List<string> _Barcodes = new List<string>();
        public Asset _asset = new Asset();
        public Customer _customer = Customer.Create("", "", "", "", "", MainForm.StaticEmails.FirstOrDefault());
        public List<Asset> _assets = new List<Asset>();
        public Image _ShippingLabel;
        public Image _PackingList;
        public EmailAddress ShipperEmail = EmailAddress.Create("null.null@null.com");
        public shippingForm()
        {
            InitializeComponent();
        }
        public shippingForm(Asset asset, List<string> barcodes)
        {
            _asset = asset;
            _Barcodes = barcodes;
            InitializeComponent();
        }
        public string PackageWeight = "0";
        public shippingForm(List<string> barcodes, Customer customer)
        {
            _customer = customer;
            _Barcodes = barcodes;
            InitializeComponent();
            decimal w = 0;
            foreach(var code in _Barcodes)
            {
                foreach(var asset in MainForm.Library.Assets)
                {
                    if (asset.AssetNumber==code)
                    {
                        _assets.Add(asset);
                        w += asset.weight;
                    }
                }
            }
            PackageWeight = w.ToString();
        }
        private void SetDefaultShipper()
        {
            Shipper_Company.Text = "Starrag US";
            Shipper_Phone.Text = "+1 859-534-5201";
            Shipper_Addressline1.Text = "2379 Progress Drive";
            Shipper_Addressline2.Text = "";
            Shipper_City.Text = "Hebron";
            Shipper_State.Text = "KY";
            Shipper_Postalcode.Text = "41048";
            Shipper_CountryCode.Text = "US";
            Shipper_Name.Text = "Starrag US";
        }public Image I;
        private void shippingForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (_customer.NickName!="")
                {
                    
                    foreach(var m in MainForm.ShippingPersonnel)
                    {
                        if (m.Name== _customer.NickName)
                        {
                            ShipperEmail = m;
                        }
                    }
                }
            }
            catch { }
            AccessLicenseNumber.Text = "6D1E455E9EE5C60E";
            UserId.Text = "jnoble21";
            Password.Text = "SUS12qaz";
            ShipperNumber.Text = "9A14T7";
            SetDefaultShipper();

            ShipTo_Company.Text = _customer.CompanyName;
            ShipTo_AttentionName.Text = _customer.Attn;
            ShipTo_Addressline1.Text = _customer.Address;
            ShipTo_Addressline2.Text = _customer.Address2;
            ShipTo_City.Text = _customer.City;
            ShipTo_State.Text = _customer.State;
            ShipTo_Postalcode.Text = _customer.Postal;
            ShipTo_CountryCode.Text = _customer.Country;

            Package1_Weight.Text = PackageWeight;
            Package1_ReferenceNo.Text = _assets.FirstOrDefault().OrderNumber.ToString();
            Package1_InsuredValue.Text = "";
            serviceCode.Text = "03-Ground";
            ShippingOption.Text = "UPS";

            //create Packing list
            var plf = CreatePackingList();
            plf.Show();
            Bitmap img = new Bitmap(plf.tableLayoutPanel1.Width, plf.tableLayoutPanel1.Height);
            img.SetResolution(60.0f, 60.0f);
            plf.tableLayoutPanel1.DrawToBitmap(img, plf.tableLayoutPanel1.ClientRectangle);
            plf.Close();
            I = (Image)img.Clone();
            PackingListImg.Image = I;
            RefreshEstimateBtn.PerformClick();
            string n = DateTime.Now.ToString().Replace("/", "-");
            n = n.Replace(":", "-");
            string tempName = "PackingLists\\" + _customer.CompanyName + " " + n +" "+ _customer.OrderNumber + ".png";            
            if (File.Exists(tempName))
                File.Delete(tempName);

            I.Save(tempName, System.Drawing.Imaging.ImageFormat.Png);
            try
            {
                Attachment attach = new Attachment(tempName);
                MainForm.SendBackupReport(ShipperEmail, "Packing list for Job "+_customer.OrderNumber+" "+DateTime.Now.ToShortDateString(), "Here is the packing list for item you just shipped", new List<Attachment>() { attach});
               
            }
            catch { 
}
           
        }
        public  PackingListForm CreatePackingList()
        {
            PackingListForm plf = new PackingListForm();
            plf.OrderNumber.Text = "ORDER #: " + _assets.FirstOrDefault().OrderNumber.ToString() ;
            plf.from.Text = Shipper_Company.Text + "\r\n" + Shipper_Addressline1.Text + "\r\n" + Shipper_City.Text + ", " + Shipper_State.Text + " " + Shipper_Postalcode.Text + "\r\n" + Shipper_Phone.Text;
            plf.to.Text = _customer.CompanyName + "\r\n" + _customer.Address + "\r\n" + _customer.Address2 + "\r\n" + _customer.City + "\r\n" + _customer.State + "\r\n" + _customer.Postal + "\r\n" + _customer.Country + "\r\n" + _customer.Phone;
            plf.attn.Text = _customer.Attn;
            plf.signature.Text = _customer.NickName;
            plf.Weight.Text ="Weight: "+ Package1_Weight.Text+ "lbs";
            plf.po.Text = Package1_ReferenceNo2.Text;
            int idx = 1;
            foreach(var asset in _assets)
            {
                if (idx == 12) { break; }
                try
                {
                    Label desc = (Label)plf.Controls.Find(("d" + idx), true)[0];
                    Label part = (Label)plf.Controls.Find(("p" + idx), true)[0];
                    Label qty = (Label)plf.Controls.Find(("q" + idx), true)[0];
                    desc.Text = asset.ItemName;
                    part.Text = asset.AssetNumber;
                    qty.Text = "Kit";

                }
                catch {
                }

                ++idx;
            }
            plf.tracking.Text = LabelShipmentIdentificationNumber.Text;
            plf.shippingbottom.Text = DateTime.Now.ToString();
            //plf.ShowDialog();
            return plf;
        }
        private void escbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SubmitUPSLabelREquest()
        {

            EMXShip my_label = new EMXShip();
            my_label.AccessLicenseNumber = AccessLicenseNumber.Text;
            my_label.UserId = UserId.Text;
            my_label.Password = Password.Text;
            my_label.ShipperNumber = ShipperNumber.Text;
            my_label.AccountNumber = ShipperNumber.Text;
            my_label.NegotiatedRatesIndicator = negotiatedRatesCheckBox.Checked;
            var tmp = serviceCode.Text.Split('-');
            my_label.ServiceCode = tmp[0];

            my_label.ShipperName = Shipper_Name.Text;
            my_label.ShipperAddressLine1 = Shipper_Addressline1.Text;
            my_label.ShipperAddressLine2 = Shipper_Addressline2.Text;
            my_label.ShipperCity = Shipper_City.Text;
            my_label.ShipperStateProvinceCode = Shipper_State.Text;
            my_label.ShipperPostalCode = Shipper_Postalcode.Text;
            my_label.ShipperCountryCode = Shipper_CountryCode.Text;
            my_label.Shipper_EmailAddress = Shipper_Email.Text;

            my_label.ShipToCompanyName = ShipTo_Company.Text;
            my_label.ShipToPhoneNumber = ShipTo_Phone.Text;
            my_label.ShipToAttentionName = ShipTo_AttentionName.Text;
            my_label.ShipToAddressLine1 = ShipTo_Addressline1.Text;
            my_label.ShipToAddressLine2 = ShipTo_Addressline2.Text;
            my_label.ShipToCity = ShipTo_City.Text;
            my_label.ShipToStateProvinceCode = ShipTo_State.Text;
            my_label.ShipToPostalCode = ShipTo_Postalcode.Text;
            my_label.ShipToCountryCode = ShipTo_CountryCode.Text;

            // Subfolder where you want to save your label files.
            my_label.LabelImage_Path = "./Labels/";

            my_label.ReturnServiceCode = "";
            my_label.WillCreateLabelImageFile = true;
            my_label.WillCreateLabelHtmlFile = false;
            my_label.WillCreateHighValueReport = true;
            my_label.LabelImageFormatCode = "GIF";
            my_label.LabelPrintMethodCode = "GIF";

            // ========================================              
            // To do a RETURN LABEL, JUST UNCOMMENT THIS BLOCK OF CODES
            // When doing a return label, only one PACKAGE at a time can be processed.
            // ========================================
            //my_label.ShipFromAttentionName = "";
            //my_label.ShipFromCompanyName = "";
            //my_label.ShipFromAddressLine1 = "";
            //my_label.ShipFromAddressLine2 = "";
            //my_label.ShipFromCity = "";
            //my_label.ShipFromStateProvinceCode = "";
            //my_label.ShipFromPostalCode = "";
            //my_label.ShipFromCountryCode = "";
            //my_label.ShipFromEmailAddress = "";
            //my_label.ReturnServiceCode = "9";
            //my_label.WillCreateLabelImageFile = true;
            //my_label.WillCreateLabelHtmlFile = true;
            //my_label.WillCreateHighValueReport = false;

            // RETURN LABEL SAMPLE - End Block


            /* ========================================
             * Set LIVE_mode property to True if you want to make the requests live. 
             * It's on Customer Integration Environment (CIE) by default. You can directly assign a "True" value to it,
             * or in this case, it pulls the settings from web.config file.
             * ========================================
             * */

            my_label.LIVE_mode = true;


            // Now add your package(s)
            UPackage my_pkg1 = new UPackage();
            my_pkg1.PackageWeight = Package1_Weight.Text.Trim();
            my_pkg1.PackageDimensionsUnitOfMeasurementCode = "LBS";
            if (packageWidth.Text!="")
                my_pkg1.PackageDimensionsWidth = packageWidth.Text;
            if (packageHeight.Text != "")
                my_pkg1.PackageDimensionsHeight = packageHeight.Text;
            if (PackageDepth.Text != "")
                my_pkg1.PackageDimensionsLength = PackageDepth.Text;
            my_pkg1.PackageReferenceNumberValue = Package1_ReferenceNo.Text.Trim();
            my_pkg1.PackageReferenceNumberValue2 = Package1_ReferenceNo2.Text.Trim();
            my_pkg1.PackageServiceOptionsInsuredMonetaryValue = Package1_InsuredValue.Text;
            my_label.ShipAdd_Package(my_pkg1);

            // Is there a 2nd package?
            /*if (Package2_Weight.Text != "")
            {
                UPackage my_pkg2 = new UPackage();
                my_pkg2.PackageWeight = Package2_Weight.Text.Trim();
                my_pkg2.PackageReferenceNumberValue = Package2_ReferenceNo.Text.Trim();
                my_pkg2.PackageServiceOptionsInsuredMonetaryValue = Package2_InsuredValue.Text;
                my_label.ShipAdd_Package(my_pkg2);
            }*/

            // After adding your packages, now we're ready to "Submit" 
            TextBoxConfirmRequest.Text = my_label.xml_confirm_request;
            my_label.ShipSubmit();

            // Was there an error?
            if (my_label.error_code != 0)
            {
                LabelShipmentIdentificationNumber.Text = "";
                LabelTotalCharges.Text = "";
                LabelNegotiatedRates.Text = "";
                LabelBillingWeight.Text = "";
                LabelBillingWeightUnitOfMeasurementCode.Text = "";
                TextBoxConfirmRequest.Text = "";
                TextBoxConfirmResponse.Text = "";
                TextBoxAcceptResponse.Text = "";
                Error_Message.Text = my_label.error_description;
                Error_Message.ForeColor = System.Drawing.Color.Red;
                Error_Message.Visible = true;
                TextBoxConfirmRequest.Text = my_label.xml_confirm_request;
                tabControl1.SelectedTab = MsgTab;
            }
            else
            {
                // Display summary results:
                LabelShipmentIdentificationNumber.Text = my_label.ShipmentIdentificationNumber;
                LabelTotalCharges.Text = my_label.TotalChargesMonetaryValue;
                LabelNegotiatedRates.Text = my_label.NegotiatedRatesNetSummaryChargesGrandTotalMonetaryValue;
                LabelBillingWeight.Text = my_label.BillingWeight;
                LabelBillingWeightUnitOfMeasurementCode.Text = my_label.BillingWeightUnitOfMeasurementCode;

                /* ------------------------------------------------------------------------------------------------
                 * Display the package results:
                 *   Because we are assuming that there is more than one label, we used a data repeater here
                 *   just for presenting the labels. In this example, we created a memory table to be used as datasource for 
                 *   a data repeater control. This is done just for displaying the results visually.
                 *   If you have only one package all the time, then you can reference that package's properties by
                 *   always referring to the first entry (index of "0") in the array. 
                 *   Example: PackageResultsList[0].TrackingNumber
                 *          PackageResultsList[0].LabelFullImagePath
                 * ------------------------------------------------------------------------------------------------
                 * */
                DataTable workTable = new DataTable("TempTable");
                workTable.Columns.Add("TrackingNumber", typeof(String));
                workTable.Columns.Add("LabelFullImagePath", typeof(String));
                workTable.Columns.Add("url_label", typeof(String));
                workTable.Columns.Add("LabelFullHTMLPath", typeof(String));
                workTable.Columns.Add("url_html", typeof(String));
                DataRow workRow;
                Int32 i;
                for (i = 0; i < my_label.PackagesResultsCount; i++)
                {
                    workRow = workTable.NewRow();
                    workRow[0] = my_label.PackageResultsList[i].TrackingNumber;
                    if (my_label.WillCreateLabelImageFile)
                    {
                        workRow[1] = my_label.PackageResultsList[i].LabelFullImagePath;
                        workRow[2] = "~/Labels/label" + my_label.PackageResultsList[i].TrackingNumber + "." + my_label.LabelImageFormatCode;
                       _ShippingLabel= ShippingLabel.Image = new Bitmap(my_label.PackageResultsList[i].LabelFullImagePath);
                    }
                    if (my_label.WillCreateLabelHtmlFile)
                    {
                        workRow[3] = my_label.PackageResultsList[i].LabelFullHTMLPath;
                        workRow[4] = "~/Labels/label" + my_label.PackageResultsList[i].TrackingNumber + ".html";
                    }
                    workTable.Rows.Add(workRow);
                }

                // After creating a temporary table, bind it with the "repeater" control.
                /* ------------------------------------------------------------------------
                 * Display other technical info. You won't need these extra information during typical
                 * shipping transactions. You will use them for your CERTIFICATION requirements with UPS.
                 * These info will also help you in further understanding what goes on in the process
                 * and for debugging information.
                 * ------------------------------------------------------------------------
                 * */
                TextBoxConfirmRequest.Text = my_label.xml_confirm_request;
                TextBoxConfirmResponse.Text = my_label.xml_confirm_response;
                TextBoxAcceptRequest.Text = my_label.xml_accept_request;
                TextBoxAcceptResponse.Text = my_label.xml_accept_response;
                tabControl1.SelectedTab = LabelTab;


            }
        }
        private void printbtn_Click(object sender, EventArgs e)
        {
            var reply = MessageBox.Show("Shipping Information Is Correct?", "", MessageBoxButtons.YesNo);
            if (reply == DialogResult.Yes)
            {
                var plf = CreatePackingList();
                PrintDocument pd = new PrintDocument();
                //pd.DefaultPageSettings.PrinterSettings.PrinterName = "Printer Name";
                pd.DefaultPageSettings.Landscape = false; //or false!
                Margins margins = new Margins(25, 25, 25, 25);
                pd.DefaultPageSettings.Margins = margins;
                pd.PrintPage += (s, args) =>
                {
                    Image i = I;
                    Rectangle m = args.MarginBounds;

                    if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                    }
                    else
                    {
                        m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                    }
                    args.Graphics.DrawImage(i, m);
                };
                if (previewPrints.Checked)
                {
                    PrintPreviewDialog ppd = new PrintPreviewDialog();
                    ppd.Document = pd;
                    ppd.ShowDialog();
                }
                 PrintDialog pdiag = new PrintDialog();
                pdiag.Document = pd;
               var result = pdiag.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pdiag.Document.Print();
                }


            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void ShipOptTab_Click(object sender, EventArgs e)
        {
            this.AcceptButton = printbtn;
        }

        private void setDefaultShipper_Click(object sender, EventArgs e)
        {
            SetDefaultShipper();
        }

        private void printpackinglist_click(object sender, EventArgs e)
        {
            //print packing list
            var plf = CreatePackingList();
            PrintImage(I);

        }
        private void PrintImage(Image img, bool print=true)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.Landscape = false; //or false!
                Margins margins = new Margins(25, 25, 25, 25);
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
                if (previewPrints.Checked)
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
        private void button4_Click(object sender, EventArgs e)
        {
            var plf = CreatePackingList();
            plf.Show();
            Bitmap img = new Bitmap(plf.tableLayoutPanel1.Width, plf.tableLayoutPanel1.Height);
            img.SetResolution(60.0f, 60.0f);
            plf.tableLayoutPanel1.DrawToBitmap(img, plf.tableLayoutPanel1.ClientRectangle);
            plf.Close();
            
            PrintImage(img,true);
            PrintImage(ShippingLabel.Image,true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PrintImage(ShippingLabel.Image,true);
        }

        private void getLAbel_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (Convert.ToInt32(Package1_Weight.Text)>150)
                    {
                        MessageBox.Show("Cannot Ship Larger Than 150 lbs Package");
                        return;
                    }
                }
                catch { }
                
                var reply = MessageBox.Show("Proceed With Label Creation\r\nVoid in UPS account if not used", "", MessageBoxButtons.YesNo);
                if (reply == DialogResult.Yes)
                {
                    SubmitUPSLabelREquest();
                    this.AcceptButton = button4;
                    try
                    {
                        if (!ShipperEmail.Email.Contains("null"))
                        {
                            if (Directory.Exists("Labels"))
                            {
                                var files = Directory.GetFiles("Labels");
                                foreach (var file in files)
                                {
                                    if (file.Contains(LabelShipmentIdentificationNumber.Text))
                                    {
                                        System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(file);
                                        MainForm.SendBackupReport(ShipperEmail, DateTime.Now.ToString() + "UPS Label for :"+_customer.CompanyName+" " + LabelShipmentIdentificationNumber.Text, "Here is the Shipping Label for the item you just shipped for "+_customer.CompanyName, new List<System.Net.Mail.Attachment>() { attach });
                                        MessageBox.Show("Label Emailed To Shipper Email Address");
                                    }
                                }

                            }
                        }
                    }
                    catch(Exception ee)
                    {
                        MessageBox.Show("Error: \r\n"+ee.ToString());
                    }
                }
            }
            catch {
                MessageBox.Show("Error Creating Label: Check Internet Connection And Error Error Screen");
                tabControl1.SelectedTab = MsgTab;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            this.AcceptButton = button3;
        }

        private void LabelTab_Click(object sender, EventArgs e)
        {
            this.AcceptButton = button4;
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            var plf = CreatePackingList();
            plf.Show();
            Bitmap img = new Bitmap(plf.tableLayoutPanel1.Width, plf.tableLayoutPanel1.Height);
            img.SetResolution(60.0f, 60.0f);
            plf.tableLayoutPanel1.DrawToBitmap(img, plf.tableLayoutPanel1.ClientRectangle);
            plf.Close();
            I = (Image)img.Clone();
            PackingListImg.Image = I;
        }

        private void ShipTo_Company_TextChanged(object sender, EventArgs e)
        {
            _customer.CompanyName = ShipTo_Company.Text;
        }

        private void ShipTo_AttentionName_TextChanged(object sender, EventArgs e)
        {
            _customer.Attn = ShipTo_AttentionName.Text;
        }

        private void ShipTo_Addressline1_TextChanged(object sender, EventArgs e)
        {
            _customer.Address = ShipTo_Addressline1.Text;
        }

        private void ShipTo_Addressline2_TextChanged(object sender, EventArgs e)
        {
            _customer.Address2 = ShipTo_Addressline2.Text;
        }

        private void ShipTo_Phone_TextChanged(object sender, EventArgs e)
        {
            _customer.Phone = ShipTo_Phone.Text;
        }

        private void ShipTo_City_TextChanged(object sender, EventArgs e)
        {
            _customer.City = ShipTo_City.Text;
        }

        private void ShipTo_State_TextChanged(object sender, EventArgs e)
        {
            _customer.State = ShipTo_State.Text;
        }

        private void ShipTo_Postalcode_TextChanged(object sender, EventArgs e)
        {
            _customer.Postal = ShipTo_Postalcode.Text;
        }

        private void ShipTo_CountryCode_TextChanged(object sender, EventArgs e)
        {
            _customer.Country = ShipTo_CountryCode.Text;
        }

        private void RefreshEstimateBtn_Click(object sender, EventArgs e)
        {
            if (NetInfo.CheckForInternetConnection())
            {
                GetRateForm grf = new GetRateForm();
                grf.ExceptionListener += Grf_ExceptionListener;
                grf.ReturnListener += Grf_ReturnListener;

                Address shipFrom = new Address();
                shipFrom.AddressLine = new string[] { Shipper_Addressline1.Text, Shipper_Addressline2.Text };
                shipFrom.Name = Shipper_Company.Text;
                shipFrom.AttentionName = Shipper_Name.Text;
                shipFrom.City = Shipper_City.Text;
                shipFrom.State = Shipper_State.Text;
                shipFrom.Postal = Shipper_Postalcode.Text;
                shipFrom.Country = Shipper_CountryCode.Text;
                shipFrom.Phone = "5022283030";

                Address shipTo = new Address();
                shipTo.AddressLine = new string[] { ShipTo_Addressline1.Text, ShipTo_Addressline2.Text };
                shipTo.Name = ShipTo_Company.Text;
                shipTo.AttentionName = ShipTo_AttentionName.Text;
                shipTo.City = ShipTo_City.Text;
                shipTo.State = ShipTo_State.Text;
                shipTo.Postal = ShipTo_Postalcode.Text;
                shipTo.Country = ShipTo_CountryCode.Text;
                shipTo.Phone = "5022283030";
                var split = serviceCode.Text.Split('-');
                UPScode code = (UPScode)Enum.Parse(typeof(UPScode), split[0]);
                Package package = new Package();
                package.PackType = UPS_PackagingType.CustomerSupplied;
                package.Weight = Package1_Weight.Text;
                grf.GetRate(shipFrom, shipTo, shipFrom, code, package);
                //_Rate = _Rate.SubmitRateRequest();

                //ShippingCostEstimate.Text = _Rate._RESPONSE.Price;
            }
            else
            { MessageBox.Show("No Internet Detected");}
        }
        public Rate _Rate = new Rate();
        public Rate.RESPONSE _Response;
        private readonly object _Attachment;

        private void Grf_ReturnListener(object sender, ReturnEvent e)
        {
            _Response = e.Response;
            ShippingCostEstimate.Text = _Response.Price;
            //throw new NotImplementedException();
        }

        private void Grf_ExceptionListener(object sender, ExceptionOccured e)
        {
            //throw new NotImplementedException();
        }
    }
    public class ExceptionOccured : EventArgs
    {
        public ExceptionOccured(Exception ex = null)
        {
            if (ex != null)
            {
                Exception = ex;
            }
        }
        public Exception Exception { get; set; }
    }
    public class ReturnEvent : EventArgs
    {
        public ReturnEvent(Rate.RESPONSE obj = null)
        {
            if (obj != null)
            {
                Response = obj;
            }
        }
        public Rate.RESPONSE Response { get; set; }
    }
    
}
