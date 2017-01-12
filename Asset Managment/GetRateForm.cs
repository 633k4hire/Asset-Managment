using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShippingAPI;
using static ShippingAPI.Rate;
using System.Net;

namespace Asset_Managment
{
    public partial class GetRateForm : Form
    {
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        public static List<Exception> Exceptions = new List<Exception>();
        protected virtual void newException(ExceptionOccured e)
        {
            Exceptions.Add(e.Exception);
            EventHandler<ExceptionOccured> handler = ExceptionListener;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public event EventHandler<ExceptionOccured> ExceptionListener;
        protected virtual void ReturnReady(ReturnEvent obj)
        {
            EventHandler<ReturnEvent> handler = ReturnListener;
            if (handler != null)
            {
                handler(this, obj);
            }
        }
        public event EventHandler<ReturnEvent> ReturnListener;
        public GetRateForm()
        {
            InitializeComponent();
            _Rate.ExceptionListener += Rate_ExceptionListener;
            _Rate.ReturnListener += Rate_ReturnListener;
        }
        public GetRateForm(Address shipFrom, Address shipTo, Address shipper, UPScode code, Package package)
        {
            InitializeComponent();
            _Rate = new ShippingAPI.Rate();
            _Rate.ExceptionListener += Rate_ExceptionListener;
            _Rate.ReturnListener += Rate_ReturnListener;
            _Rate.SubmitRateRequest(shipper, shipFrom, shipTo, code, package);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
            {
                Address shipFrom = new Address();
                shipFrom.AddressLine = new string[] { "3300 cherry tree lane" };
                shipFrom.Name = "M-Tech";
                shipFrom.AttentionName = "Matthew";
                shipFrom.City = "Prospect";
                shipFrom.State = "KY";
                shipFrom.Postal = "40059";
                shipFrom.Country = "US";
                shipFrom.Phone = "5022973852";

                Address shipTo = new Address();
                shipTo.AddressLine = new string[] { "13457 Inglewood Ave", "Apt A" };
                shipTo.Name = "Eclectic Elegance";
                shipTo.AttentionName = "Jami Williams";
                shipTo.City = "hawthorne";
                shipTo.State = "CA";
                shipTo.Postal = "90250";
                shipTo.Country = "US";
                shipTo.Phone = "5022973852";

                Package package = new Package();
                package.PackType = UPS_PackagingType.CustomerSupplied;
                package.Weight = "15";



                _Rate.AddShipper(shipFrom);
                _Rate.AddShipFrom(shipFrom);
                _Rate.AddShipTo(shipTo);
                _Rate.SelectServiceCode(UPScode.Ground);
                _Rate.AddPackage(package);

                _Rate = _Rate.SubmitRateRequest();
                this.Text = _Response.Price;
                MessageBox.Show(_Response.Price);
            }
            else
            {
                MessageBox.Show("No Internet");
            }
        }
        public void GetRate(Address shipFrom, Address shipTo, Address shipper, UPScode code, Package package)
        {
            if (CheckForInternetConnection())
            {
                _Rate = new Rate();
                _Rate.ExceptionListener += Rate_ExceptionListener;
                _Rate.ReturnListener += Rate_ReturnListener;
                _Rate.AddShipper(shipFrom);
                _Rate.AddShipFrom(shipFrom);
                _Rate.AddShipTo(shipTo);
                _Rate.SelectServiceCode(code);
                _Rate.AddPackage(package);
                _Rate = _Rate.SubmitRateRequest();
            }
            
        }
        public static Rate _Rate = new Rate();
        public RESPONSE _Response;
        private void Rate_ReturnListener(object sender, Rate.ReturnEvent e)
        {
            _Response = e.Response;
            ReturnReady(new ReturnEvent(_Response));
        }
        public int Timeout = 15;
        public bool disable = false;
        private void Rate_ExceptionListener(object sender, Rate.ExceptionOccured e)
        {
            newException(new ExceptionOccured(e.Exception));
            if (e.Exception.Message.Contains("aborted"))
            {
                if (Timeout == 0)
                {
                    MessageBox.Show(e.Exception.Message);
                    disable = true;
                }
                System.Threading.Thread.Sleep(5);
                _Rate.SubmitRateRequest();
                --Timeout;
            }
            if (e.Exception.Message.Contains("client data"))
            {
                if (!disable)
                {
                    MessageBox.Show(e.Exception.Message + "\r\nPlease Check Address and such");
                    disable = true;
                }
            }
            else
            {
                System.Threading.Thread.Sleep(5);
                _Rate.SubmitRateRequest();
                ++Timeout;
            }
            
        }
    }
    public class NetInfo
    {
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
