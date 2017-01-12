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
    public partial class GeneralSettings : Form
    {
        public Settings _S;
        public GeneralSettings()
        {
            InitializeComponent();
            _S = MainForm._Settings;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void GeneralSettings_Load(object sender, EventArgs e)
        {
            
            checkinmessage.Text = MainForm.StandardCheckInMessage;
            checkoutmessage.Text = MainForm.StandardCheckOutMessage;
            notificationmessage.Text = MainForm.StandardNotificationMessage;
            foreach(var email in MainForm.StaticEmails)
            {
                TreeNode node = new TreeNode();
                node.Text = email.Email;
                node.ToolTipText = email.Name;
                staticEmails.Nodes.Add(node);
            }
            foreach(var engineer in MainForm._Settings.ServiceEngineers)
            {
                TreeNode node = new TreeNode();
                node.Text = engineer.Name;
                node.ToolTipText = engineer.Email;
                serviceEngineers.Nodes.Add(node);
            }
            foreach (var customer in MainForm._Settings.Customers)
            {
                TreeNode node = new TreeNode();
                node.Text = customer.CompanyName;
                node.ToolTipText = customer.Attn;
                Customers.Nodes.Add(node);
            }
            foreach (var shipper in MainForm.ShippingPersonnel)
            {
                TreeNode node = new TreeNode();
                node.Text = shipper.Name;
                shippingPersonnel.Nodes.Add(node);
            }
            int i = 0;
            foreach (var email in MainForm._Settings.NotSentEmails)
            {
                ++i;
            }
            unsentemails.Text = i.ToString();
            serviceEngineers.Sort();
            Customers.Sort();
            shippingPersonnel.Sort();
            staticEmails.Sort();
        }

        private void clearunsentemailbtn_Click(object sender, EventArgs e)
        {
            MainForm._Settings.NotSentEmails = new List<Email>();
            unsentemails.Text = "0";
        }

        private void sendunsentemailbtn_Click(object sender, EventArgs e)
        {
            if (unsentemails.Text != "0")
            {
                MessageBox.Show("Send " + unsentemails.Text + " unsent emails?");
                lock (MainForm._NotSentLock)
                {
                    List<Email> removals = new List<Email>();
                    foreach (var msg in MainForm._Settings.NotSentEmails)
                    {
                        MainForm.SendUnsent(msg);
                        removals.Add(msg);
                    }
                    foreach (var rem in removals)
                    {
                        MainForm._Settings.NotSentEmails.Remove(rem);
                    }
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //engineer add
            addEngineer ae = new addEngineer();
            ae.ShowDialog();
            if (!ae.Cancelled)
            {
                var email = new EmailAddress();
                email.Name = ae.engineername.Text;
                email.Email = ae.engineeremail.Text;
                MainForm._Settings.ServiceEngineers.Add(email);
                TreeNode node = new TreeNode();
                node.Text = email.Name;
                node.ToolTipText = email.Email;
                serviceEngineers.Nodes.Add(node);
                if (File.Exists("engineer.txt"))
                {
                    File.AppendAllLines("engineer.txt", new string[] {(ae.engineername.Text+","+ae.engineeremail.Text) });
                }
            }
            ae.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addShipper ae = new addShipper();
            ae.ShowDialog();
            if (!ae.Cancelled)
            {
                var email = new EmailAddress();
                email.Name = ae.engineername.Text;
                email.Email = ae.engineeremail.Text;
                MainForm.ShippingPersonnel.Add(email);
                TreeNode node = new TreeNode();
                node.Text = email.Name;
                node.ToolTipText = email.Email;
                shippingPersonnel.Nodes.Add(node);
                if (File.Exists("shipping.txt"))
                {
                    File.AppendAllLines("shipping.txt", new string[] { (ae.engineername.Text + "," + ae.engineeremail.Text) });
                }
            }
            ae.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            addCustomer ae = new addCustomer();
            ae.ShowDialog();
            if (!ae.Cancelled)
            {
                Customer customer = new Customer();
                customer.CompanyName = ae.ShipTo_Company.Text;
                customer.Attn = ae.ShipTo_AttentionName.Text;
                customer.Address = ae.ShipTo_Addressline1.Text;
                customer.Address2 = ae.ShipTo_Addressline2.Text;
                customer.Phone = ae.ShipTo_Phone.Text;
                customer.City = ae.ShipTo_City.Text;
                customer.State = ae.ShipTo_State.Text;
                customer.Postal = ae.ShipTo_Postalcode.Text;
                customer.Country = ae.ShipTo_CountryCode.Text;
                MainForm._Settings.Customers.Add(customer);
                TreeNode node = new TreeNode();
                node.Text = customer.CompanyName;
                node.ToolTipText = customer.Attn;
                Customers.Nodes.Add(node);
                if (File.Exists("customers.csv"))
                {
                    //Company Name,Nick Name,Contact Name,Street Address Line 1,Street Address Line 2,Street Address Line 3,City,St/Prov,Postal Cd,Country,Contact Phone,Contact Tel Ext,Contact Email,Contact Fax,Res Ind,Loc ID,Cons Ind,Account Number,Acc Postal Cd,USPSPO Box IND
                    var a = new string[1] { ( ae.ShipTo_Company.Text + "," + "," + ae.ShipTo_AttentionName.Text + "," + ae.ShipTo_Addressline1.Text + "," + ae.ShipTo_Addressline2.Text + "," + "," + ae.ShipTo_City.Text + "," + ae.ShipTo_State.Text + "," + ae.ShipTo_Postalcode.Text + "," + ae.ShipTo_CountryCode.Text + "," + "," + "," + "," + "," + "," + "," + "," + "," + "," )};
                    File.AppendAllLines("customers.csv", a);
                }
            }
            ae.Close();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            addShipper ae = new addShipper();
            ae.ShowDialog();
            if (!ae.Cancelled)
            {
                var email = new EmailAddress();
                email.Name = ae.engineername.Text;
                email.Email = ae.engineeremail.Text;
                MainForm.StaticEmails.Add(email);
                TreeNode node = new TreeNode();
                node.Text = email.Name;
                node.ToolTipText = email.Email;
                staticEmails.Nodes.Add(node);
                if (File.Exists("StaticEmails.txt"))
                {
                    File.AppendAllLines("StaticEmails.txt", new string[] { (ae.engineername.Text + "," + ae.engineeremail.Text) });
                }
            }
            ae.Close();
        }
    }
}
