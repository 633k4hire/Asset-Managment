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
    public partial class Avery5160_BARCODE_Template : Form
    {
        public Avery5160_BARCODE_Template(List<Asset> Assets)
        {
            _assets = Assets;
            InitializeComponent();
        }
        public Avery5160_BARCODE_Template(List<Asset> Assets, int startpos)
        {
            _assets = Assets;
            pos = startpos * 2 - 1;
            InitializeComponent();
        }
        public List<Asset> _assets = new List<Asset>();
        public int pos = 1;
       
        private void Avery5160StickerTemplate_Load(object sender, EventArgs e)
        {
            int x = pos;
            foreach (var asset in _assets)
            {
                if (x == 62) break;
                try
                {
                    
                    PictureBox Barcode = (PictureBox)this.Controls.Find(("pictureBox" + x), true)[0];
                    try
                    {
                        var image = MainForm.CreateBarcodeImage(asset.AssetNumber, Zen.Barcode.BarcodeSymbology.Code39NC);
                        Barcode.Image = image;
                    }
                    catch { }
                }
                catch
                { ++x; }
                ++x;
            }
        }
    }
}
