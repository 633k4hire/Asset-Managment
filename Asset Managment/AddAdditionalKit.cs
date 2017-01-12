using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Asset_Managment
{
    public partial class AddAdditionalKit : Form
    {
        public List<string> Barcodes = new List<string>();
        public string _barcode = "";
        public AddAdditionalKit()
        {
            InitializeComponent();
        }
        public AddAdditionalKit(string barcode)
        {
            _barcode = barcode;
            InitializeComponent();
        }

        private void AddAdditionalKit_Load(object sender, EventArgs e)
        {
            MainForm._instance.Serial.DataReceived -= MainForm._instance.Serial_DataReceived;
            MainForm._instance.Serial.DataReceived += Serial_DataReceived;
        }

        private void Serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            var data = MainForm._instance.Serial.ReadExisting();
            Barcodes.Add(data);
            UpdateKitBox();
        }

        private void UpdateKitBox()
        {
            foreach(var code in Barcodes)
            {
                kitbox.Items.Add(code);
            }
        }

        private void AddAdditionalKit_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MainForm._instance.Serial.DataReceived -= Serial_DataReceived;
            MainForm._instance.Serial.DataReceived += MainForm._instance.Serial_DataReceived;
            this.Hide();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            MainForm._instance.Serial.DataReceived -= Serial_DataReceived;
            MainForm._instance.Serial.DataReceived += MainForm._instance.Serial_DataReceived;
            this.Hide();
        }

        private void AddAdditionalKit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F8)
                HiddenScanBox.Focus();
        }

        private void HiddenScanBox_TextChanged(object sender, EventArgs e)
        {
            if (HiddenScanBox.TextLength == 4)
            {
                bool GO = false;
                foreach (var ass in MainForm.Library.Assets)
                {
                    if (HiddenScanBox.Text==ass.AssetNumber)
                    {
                        GO = true;
                    }
                }
                if (HiddenScanBox.Text == _barcode)
                {
                    HiddenScanBox.Text = "";
                    return;
                }
                foreach (string code in kitbox.Items)
                {
                    Asset asset = new Asset();
                    foreach (var ase in MainForm.Library.Assets)
                    {
                        if (ase.AssetNumber == code)
                            asset = ase;
                    }
                    if (code == HiddenScanBox.Text || asset.IsOut == true)
                    {
                        HiddenScanBox.Text = "";
                        
                        return;
                    }
                }
                if (GO)
                {
                    kitbox.Items.Add(HiddenScanBox.Text);
                    Barcodes.Add(HiddenScanBox.Text);
                    HiddenScanBox.Text = "";
                    HiddenScanBox.Focus();
                }
                else
                {
                    HiddenScanBox.Text = "";
                    HiddenScanBox.Focus();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!savebtn.Focused)
                HiddenScanBox.Focus();
        }
    }
}
