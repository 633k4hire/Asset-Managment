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
    public partial class ScanAction : Form
    {
        public  delegate void updateList();
        public updateList Update;
        public Asset _asset;
        public ScanAction()
        {
            InitializeComponent();
        }
        public string Barcode = "";
        public bool Halt = false;
        public ScanAction(string barcode)
        {
            Barcode = barcode;
            InitializeComponent();
            bool isBadAssetNumber = true;

            List<string> assetNumbers = new List<string>();
            foreach (var asset in MainForm.Library.Assets)
            {
                assetNumbers.Add(asset.AssetNumber.ToString());
               
            }
            BarecodeChooser.Items.AddRange(assetNumbers.ToArray());
            BarecodeChooser.Text = barcode;
            if (assetNumbers.Count==0)
            {
                Halt = true;
                MessageBox.Show("No Assets Available");
            }
            foreach(var ass in MainForm.Library.Assets)
            {
                if (ass.AssetNumber == barcode)
                {
                    _asset = ass;
                    isBadAssetNumber = false;
                }
            }
            if (isBadAssetNumber)
            {
                MessageBox.Show("Invalid asset number scanned");
                this.Close();
            }
        }

        private void ScanAction_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(var ass in MainForm.Library.Assets)
                {
                    if (ass.AssetNumber==Barcode && ass.IsOut==true)
                    {
                        ScanAdd sa = new ScanAdd(Barcode);
                    sa.Update = upaction;
                    sa.ShowDialog();
                    this.Close();
                    }
                }
            }
            catch {
                MessageBox.Show("Invalid Choice"); }
        }
        public void upaction()
        {
            Update?.Invoke();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var ass in MainForm.Library.Assets)
                {
                    if (ass.AssetNumber == Barcode && ass.IsOut == false)
                    {
                        if (_asset.D != "true")
                        {
                            ScanRemove sr = new ScanRemove(Barcode);
                            sr.Update = upaction;
                            sr.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Cannot Check Out Service Tool\r\n Service Tool Is Damaged or Missing Parts");
                        }
                    }
                }                
            }
            catch { MessageBox.Show("Invalid Choice");}
        }

        private void BarecodeChooser_TextUpdate(object sender, EventArgs e)
        {
            Barcode = BarecodeChooser.Text;
        }

        private void BarecodeChooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            Barcode = BarecodeChooser.Text;
        }
    }
}
