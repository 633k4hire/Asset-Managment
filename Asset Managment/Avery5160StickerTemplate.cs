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
    public partial class Avery5160StickerTemplate : Form
    {
        public Avery5160StickerTemplate()
        {
            InitializeComponent();
        }
        public List<Asset> _assets = new List<Asset>();
        public int pos = 1;
        public Avery5160StickerTemplate(List<Asset> Assets)
        {
            _assets = Assets;
            InitializeComponent();
        }
        public Avery5160StickerTemplate(List<Asset> Assets, int startpos)
        {
            _assets = Assets;
            pos = startpos*2-1;
            InitializeComponent();
        }
        private void Avery5160StickerTemplate_Load(object sender, EventArgs e)
        {
            int x = pos;
            foreach(var asset in _assets)
            {
                if (x == 62) break;
                try
                {
                    TextBox AssetNumber = (TextBox)this.Controls.Find(("textBox" + x), true)[0];
                    AssetNumber.Text = asset.AssetNumber;
                    TextBox Desc = (TextBox)this.Controls.Find(("textBox" + ++x), true)[0];
                    Desc.Text = asset.ItemName+"\r\n"+asset.Description;
                }
                catch
                { ++x; }
                ++x;         
            }
        }
    }
}
