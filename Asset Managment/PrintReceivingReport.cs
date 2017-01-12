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
    public partial class PrintReceivingReport : Form
    {
        public PrintReceivingReport()
        {
            InitializeComponent();
        }
        public ReceivingReport _TLP = null;
        public PrintReceivingReport(ReceivingReport tlp)
        {
            _TLP = tlp;
            InitializeComponent();
        }

        private void printbtn_Click(object sender, EventArgs e)
        {
            try
            {
                //Print p = new Print();
                //var ppd = p.printImg(I);
                //ppd.Print();
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
                if (checkBox1.Checked)
                {
                    PrintPreviewDialog ppd = new PrintPreviewDialog();
                    ppd.Document = pd;
                    ppd.ShowDialog();
                }
                PrintDialog pdd = new PrintDialog();
                pdd.Document = pd;
                var reply = pdd.ShowDialog();
                if (reply == DialogResult.OK) pdd.Document.Print();
            }
            catch { }
        }
        Image I;
        private void PrintReceivingReport_Load(object sender, EventArgs e)
        {
            if (_TLP!=null)
            {
                _TLP.Show();
                _TLP.tableLayoutPanel1.Focus();
                Bitmap im = new Bitmap(_TLP.tableLayoutPanel1.Width, _TLP.tableLayoutPanel1.Height);
                im.SetResolution(60.0f, 60.0f);
                _TLP.tableLayoutPanel1.DrawToBitmap(im, _TLP.tableLayoutPanel1.ClientRectangle);
                img.Image = im;
                I = im;
                _TLP.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
