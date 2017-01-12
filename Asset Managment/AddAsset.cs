using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zen.Barcode;
namespace Asset_Managment
{
    public partial class AddAsset : Form
    {
        public Asset _asset = new Asset();
        public AddAsset()
        {
            InitializeComponent();
        }

        private void AddAsset_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Files|*.*|JPEG|*.jpeg|JPG|*.jpg|BMP|*.bmp|PNG|*.png|TIF|*.tif";
            ofd.FileName = "";
            ofd.Multiselect = true;
            ofd.ShowDialog();
            try
            {
                if (!ofd.FileNames[0].Equals(""))
                {
                    int i = 0;
                    foreach (var file in ofd.FileNames)
                    {
                        var ext = Path.GetExtension(file);
                        File.Copy(file, "Images\\" + AssetNumber.Text + _asset.Images.Count.ToString() + i.ToString()+ext, true);
                        _asset.Images.Add("Images\\" + AssetNumber.Text + _asset.Images.Count.ToString() + i.ToString() + ext);
                        ++i;
                    }
                    img.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(_asset.Images.FirstOrDefault())));
                }
            }
            catch (Exception ee){ MessageBox.Show("Error In Saving File\r\n"+ee.ToString());}
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AssetNumber.Text == "")
            {
                MessageBox.Show("Please Add Unique Asset Number");
                return;
            }
            int assetc = 0;
            foreach (var asset in MainForm.Library.Assets)
            {
                if (AssetNumber.Text==asset.AssetNumber.ToString())
                {
                    ++assetc;
                }
            }
            if (assetc>0)
            {
                MessageBox.Show("Please Use Unique Asset Number");
                return;
            }
            //save
            _asset.DateRecieved = DateTime.Now;
            _asset.OrderNumber = -1;
            Cancelled = false;
            if (!Directory.Exists("Assets"))
            {
                Directory.CreateDirectory("Assets");
            }

            try
            {
                if (File.Exists("Assets\\" + _asset.AssetNumber))
                {
                    File.Delete("Assets\\" + _asset.AssetNumber);
                }
                _asset.Write("Assets\\" + _asset.AssetNumber);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

            this.Hide();
        }
        public bool Cancelled = true;
        private void button3_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void description_TextChanged(object sender, EventArgs e)
        {
            _asset.Description = description.Text;
        }

        private void AddAsset_Load(object sender, EventArgs e)
        {
            AssetName.Focus();
            foreach (var item in Enum.GetValues(typeof(BarcodeSymbology)))
            {
                Symbologies.Items.Add(item);
            }
        }

        private void AssetName_TextChanged(object sender, EventArgs e)
        {
            _asset.ItemName = AssetName.Text;
        }

        private void AssetNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {

                _asset.AssetNumber = AssetNumber.Text;
                button1.Enabled = true;
                button4.Enabled = true;
                
                if (AssetNumber.Text.Length==0)
                {
                    button1.Enabled = false;
                    button4.Enabled = false;
                }else
                {
                    try
                    {
                        var image = MainForm.CreateBarcodeImage(AssetNumber.Text, BarcodeSymbology.Code39NC);
                        image.Save(@"Barcodes\" + _asset.AssetNumber + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        _asset.BarcodeImage = @"Barcodes\" + _asset.AssetNumber + ".png";
                        barcode.Image = image;
                    }
                    catch { }
                }
            }
            catch {
                MessageBox.Show("Numbers only");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Symbologies.Text != "")
                {
                    BarcodeSymbology bar = BarcodeSymbology.Code128;
                    var sym = (BarcodeSymbology)Enum.Parse(typeof(BarcodeSymbology), Symbologies.Text);
                    var image = MainForm.CreateBarcodeImage(AssetNumber.Text, sym);
                    image.Save(@"Barcodes\" + _asset.AssetNumber + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    _asset.BarcodeImage = @"Barcodes\" + _asset.AssetNumber + ".png";
                    barcode.Image = image;
                }
                else
                {
                    MessageBox.Show("Select Symbology");
                }
            }
            catch { }
            /*OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Files|*.*|JPEG|*.jpeg|JPG|*.jpg|BMP|*.bmp|PNG|*.png|TIF|*.tif";
            ofd.FileName = "";
            ofd.Multiselect = false;
            ofd.ShowDialog();
            try
            {
                if (!ofd.FileNames[0].Equals(""))
                {
                    int i = 0;
                    foreach (var file in ofd.FileNames)
                    {
                        var ext = Path.GetExtension(file);
                        File.Copy(file, "Barcodes\\" + AssetNumber.Text + i.ToString() + ext, true);
                        _asset.BarcodeImage=("Barcodes\\" + AssetNumber.Text + i.ToString() + ext);
                        ++i;
                    }
                    barcode.Image = Image.FromFile(_asset.BarcodeImage);
                }
            }
            catch { MessageBox.Show("Error"); }
            */

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _asset.weight = numericUpDown1.Value;
        }

        private void numericUpDown1_Scroll(object sender, ScrollEventArgs e)
        {
            _asset.weight = numericUpDown1.Value;
        }
    }
    
}
