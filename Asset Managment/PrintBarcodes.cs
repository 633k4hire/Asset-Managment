using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Asset_Managment
{
    public partial class PrintBarcodes : Form
    {
        public PrintBarcodes()
        {
            InitializeComponent();
           
        }

        private void PrintBarcodes_Load(object sender, EventArgs e)
        {
            foreach (var asset in _Assets)
            {

                AssetList.Items.Add(asset.AssetNumber);
            }
        }
        public List<Asset> _Assets = MainForm.Library.Assets;
        public List<Asset> _assetsToPrint = new List<Asset>();

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

      
        private static void PrintLabelImage(Image img, bool print = true, bool previewPrints = false)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.Landscape = false; //or false!
                Margins margins = new Margins(25, 25, 35, 25);
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
                if (previewPrints)
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
        public List<Image> PrintAssetLabels(bool print = true, bool preview = true)
        {
            //Print asset Labels
            List<Image> IL = new List<Image>();
            List<Avery5160_BARCODE_Template> pages = new List<Avery5160_BARCODE_Template>();
            List<List<Asset>> AssetList = new List<List<Asset>>();
            int idx = 0;
            List<Asset> assets = new List<Asset>();
            for (int x = 0; x < _Assets.Count; ++x)
            {
                if (idx == 30)
                {
                    AssetList.Add(assets);
                    assets = new List<Asset>();
                    idx = 0;
                }
                assets.Add(_Assets[x]);
                ++idx;
            }
            if (assets.Count < 30)
                AssetList.Add(assets);
            foreach (var list in AssetList)
            {
                Avery5160_BARCODE_Template labels = new Avery5160_BARCODE_Template(list);
                pages.Add(labels);
                labels.Show();
                labels.tableLayoutPanel1.Focus();
                labels.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
                Bitmap img = new Bitmap(labels.tableLayoutPanel1.Width, labels.tableLayoutPanel1.Height);
                img.SetResolution(60.0f, 60.0f);
                labels.tableLayoutPanel1.DrawToBitmap(img, labels.tableLayoutPanel1.ClientRectangle);
                labels.Close();
                IL.Add(img);
            }
            foreach (var img in IL)
            {
                PrintLabelImage(img, print, preview);
            }
            return IL;
        }

        private void AssetTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void AssetList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public List<Image> IL = new List<Image>();
        private void preview_click(object sender, EventArgs e)
        {
            IL = new List<Image>();
            _assetsToPrint = new List<Asset>();
            List<string> printables = new List<string>();
            int idx = 0;
            foreach (string item in AssetList.Items)
            {
                if (AssetList.GetItemChecked(idx))
                {
                    printables.Add(item);
                }
                ++idx;
            }
            foreach (var pr in printables)
            {
                var asset = from ass in _Assets
                            where ass.AssetNumber == pr
                            select ass;
                _assetsToPrint.AddRange(asset);
            }
            //list of assets to print
            //Print asset Labels
            List<Avery5160_BARCODE_Template> pages = new List<Avery5160_BARCODE_Template>();
            List<List<Asset>> AssetL = new List<List<Asset>>();
            idx = Convert.ToInt32(startpos.Value);
            List<Asset> assets = new List<Asset>();
            for (int x = 0; x < _assetsToPrint.Count; ++x)
            {
                if (idx == 31)
                {
                    AssetL.Add(assets);
                    assets = new List<Asset>();
                    idx = 0;
                }
                assets.Add(_assetsToPrint[x]);
                ++idx;
            }
            if (assets.Count < 30)
                AssetL.Add(assets);
            int pospos = Convert.ToInt32(startpos.Value);
            foreach (var list in AssetL)
            {
                Avery5160_BARCODE_Template labels = new Avery5160_BARCODE_Template(list, pospos);
                pages.Add(labels);
                labels.Location = new Point(8000, 8000);
                labels.Show();
                labels.tableLayoutPanel1.Focus();
                labels.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
                Bitmap img = new Bitmap(labels.tableLayoutPanel1.Width, labels.tableLayoutPanel1.Height);
                img.SetResolution(60.0f, 60.0f);
                labels.tableLayoutPanel1.DrawToBitmap(img, labels.tableLayoutPanel1.ClientRectangle);
                labels.Close();
                IL.Add(img);
                pospos = 1;
            }
            try
            {
                img.Image = IL[0];
                imageIndex = 0;
                Pages.Text = "Pages: " + pages.Count.ToString();
            }
            catch { }
        }

        private void selectAll_click(object sender, EventArgs e)
        {
            ;
            for (var idx = 0; idx < AssetList.Items.Count; ++idx)
            {
                AssetList.SetItemChecked(idx, true);
            }
        }
        public int imageIndex = 0;
        private void previous_img_click(object sender, EventArgs e)
        {
            try
            {
                --imageIndex;
                img.Image = IL[imageIndex];
            }
            catch
            {
                try
                {
                    ++imageIndex;
                    img.Image = IL[imageIndex];
                }
                catch { }
            }
        }

        private void next_img_click(object sender, EventArgs e)
        {
            try
            {
                ++imageIndex;
                img.Image = IL[imageIndex];
            }
            catch
            {
                try
                {
                    --imageIndex;
                    img.Image = IL[imageIndex];
                }
                catch { }
            }
        }

        private void close_click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printbtn_Click(object sender, EventArgs e)
        {
            foreach (var image in IL)
            {
                PrintLabelImage(image);
            }
        }
    }
}
