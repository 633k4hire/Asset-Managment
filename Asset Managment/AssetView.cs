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
    public partial class AssetView : Form
    {
        public delegate void saveAss(Asset asset);
        public saveAss SaveAsset;
        public delegate void updateAssLists();
        public updateAssLists UpdateAssetLists;
        public Asset _asset = new Asset();
        public AssetView()
        {
            InitializeComponent();
        }
        public int currentImageIndex = 0;
        public int imageIndex = 0;
        public AssetView(Asset asset)
        {
            _asset = asset;
            InitializeComponent();
            if (MainForm._EDITMODE)
            {
                groupBox10.Visible = true;
            }
            AssetName.Text = asset.ItemName;
            AssetNumber.Text = asset.AssetNumber.ToString();
            description.Text = asset.Description;
            shipper.Text = asset.PersonShipping;
            engineer.Text = asset.ServiceEngineer;
            weightChooser.Value = asset.weight;
            if (asset.DateShipped.Year != 0001)
            {
                shipped.Value = asset.DateShipped;
                shipped.Text = asset.DateShipped.ToString();
            }
            if (asset.DateRecieved.Year != 0001)
            {
                recieved.Value = asset.DateRecieved;
                recieved.Text = asset.DateRecieved.ToString();
            }
            shipTo.Text = asset.ShipTo;
            orderNumber.Value = asset.OrderNumber;
            try
            {
                if (asset.Images.Count > 0)
                img.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(asset.Images.FirstOrDefault())));
            }
            catch { }
            /*if (asset.BarcodeImage!=null)
                barcode.Image = Image.FromFile(asset.BarcodeImage);
                */
            try
            {
                var image = MainForm.CreateBarcodeImage(AssetNumber.Text,Zen.Barcode.BarcodeSymbology.Code39NC);
                barcode.Image = image;
            }
            catch { }
            if (asset.IsOut)
            {
                dateReturnBox.Visible = false;
                reout.Visible = true;
                if (MainForm._EDITMODE)
                {
                    groupBox10.Visible = true;
                }
            }
            if (asset.D=="true")
            {
                isDamaged.Checked = true;
            }
            else
            {
                isDamaged.Checked = false;
            }
            foreach(var notice in MainForm._Settings.Notifications_30_Day)
            {
                if (notice.AssetNumber==asset.AssetNumber)
                {
                    if (notice.IsNotified)
                    {
                        silenceNotify.Checked = false;
                    }else
                    {
                        silenceNotify.Checked = true;
                    }
                    break;
                }
            }
            foreach (var notice in MainForm._Settings.Notifications_15_Day)
            {
                if (notice.AssetNumber == asset.AssetNumber)
                {
                    if (notice.IsNotified)
                    {
                        silenceNotify.Checked = false;
                    }
                    else
                    {
                        silenceNotify.Checked = true;
                    }
                    break;
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void AssetView_Load(object sender, EventArgs e)
        {
            foreach(var asset in _asset.History)
            {
                
                var ListItem = new ListViewItem();
                ListItem.ImageIndex = 0;
                ListItem.Text = asset.ItemName + ": ";
                ListItem.ToolTipText = AssetNumber.ToString();
                var ON = new ListViewItem.ListViewSubItem(ListItem, asset.OrderNumber.ToString());
                ListItem.SubItems.Add(ON);
                var st = new ListViewItem.ListViewSubItem(ListItem, asset.ShipTo);
                ListItem.SubItems.Add(st);
                var de = new ListViewItem.ListViewSubItem(ListItem, asset.Description);
                ListItem.SubItems.Add(de);
                var ds = new ListViewItem.ListViewSubItem(ListItem, asset.DateShipped.ToString());
                ListItem.SubItems.Add(ds);
                var dr = new ListViewItem.ListViewSubItem(ListItem, asset.DateRecieved.ToString());
                ListItem.SubItems.Add(dr);
                var se = new ListViewItem.ListViewSubItem(ListItem, asset.ServiceEngineer);
                ListItem.SubItems.Add(se);
                var ps = new ListViewItem.ListViewSubItem(ListItem, asset.PersonShipping);
                ListItem.SubItems.Add(ps);
                HistoryList.Items.Add(ListItem);
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveAsset?.Invoke(_asset);
        }
        private void AddAsset_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void imgadd(object sender, EventArgs e)
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
                        if (File.Exists("Images\\" + AssetNumber.Text + _asset.Images.Count.ToString() + i.ToString() + ext))
                        {
                            File.Delete("Images\\" + AssetNumber.Text + _asset.Images.Count.ToString() + i.ToString() + ext);
                        }
                        File.Copy(file, "Images\\" + AssetNumber.Text+_asset.Images.Count.ToString() + i.ToString() + ext, true);
                        _asset.Images.Add("Images\\" + AssetNumber.Text + _asset.Images.Count.ToString() + i.ToString() + ext);
                        ++i;
                    }
                    try
                    {
                        img.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes("Images\\" + AssetNumber.Text + _asset.Images.Count.ToString() + i.ToString() + Path.GetExtension(ofd.FileNames[0]))));
                    }
                    catch (Exception ee)
                    {

                        //MessageBox.Show("Error:\r\n" + ee.ToString());
                    }
                }
            }
            catch(Exception ee) {

               // MessageBox.Show("Error:\r\n"+ee.ToString());
            }
        }

        private void save(object sender, EventArgs e)
        {
            //save
            _asset.DateRecieved = DateTime.Now;
            Cancelled = false;
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


        private void AssetName_TextChanged(object sender, EventArgs e)
        {
            _asset.ItemName = AssetName.Text;
        }

        private void AssetNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _asset.AssetNumber = AssetNumber.Text;
            }
            catch
            {
                MessageBox.Show("Numbers only");
            }
        }

        private void barcodeadd(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
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
                        File.Copy(file, "Barcodes\\" + AssetNumber.Text + i.ToString() + ext,true);
                        _asset.BarcodeImage = ("Barcodes\\" + AssetNumber.Text + i.ToString() + ext);
                        ++i;
                    }
                    barcode.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(_asset.BarcodeImage)));
                }
            }
            catch { MessageBox.Show("Error"); }
        }

        private void shipTo_TextUpdate(object sender, EventArgs e)
        {
            _asset.ShipTo = shipTo.Text;
        }

        private void engineer_TextUpdate(object sender, EventArgs e)
        {
            _asset.ServiceEngineer = engineer.Text;
        }

        private void orderNumber_TextUpdate(object sender, EventArgs e)
        {
            _asset.OrderNumber = Convert.ToInt32(orderNumber.Value);
        }

        private void shipper_TextUpdate(object sender, EventArgs e)
        {
            _asset.PersonShipping = shipper.Text;
        }

        private void shipped_ValueChanged(object sender, EventArgs e)
        {
            _asset.DateShipped = shipped.Value;
            //remove from in stock
            //library.instock..outstock..
        }

        private void recieved_ValueChanged(object sender, EventArgs e)
        {
            _asset.DateRecieved = recieved.Value;
            //return to stock 
            //library.instock..outstock..
        }

        private void returnbtn_Click(object sender, EventArgs e)
        {
            if (_asset.IsOut)
            {
                
            }
        }

        private void removebtn_Click(object sender, EventArgs e)
        {
            if (!_asset.IsOut)
            {

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                ++imageIndex;
                img.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(_asset.Images[imageIndex])));
            }
            catch
            {
                try
                {
                    --imageIndex;
                    img.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(_asset.Images[imageIndex])));
                }
                catch { }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                --imageIndex;
                img.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(_asset.Images[imageIndex])));
            }
            catch
            {
                try
                {
                    ++imageIndex;
                    img.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(_asset.Images[imageIndex])));
                }
                catch { }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editToolStripMenuItem.Checked)
            {
                description.Enabled = true;
                Application.DoEvents();
            }
            else
            {
                description.Enabled = false;
                Application.DoEvents();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                img.Image = null;
                File.Delete(_asset.Images[imageIndex]);
                _asset.Images.RemoveAt(imageIndex);
                
               
            }
            catch {
            }
        }

        private void weightChooser_ValueChanged(object sender, EventArgs e)
        {
            _asset.weight = weightChooser.Value;
        }

        private void isDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if (isDamaged.Checked)
            {
                _asset.D= "true";
            }
            else
            {
                _asset.D = "false";
            }
        }

        private void silenceNotify_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                List<Notification> removable = new List<Notification>();
                List<Notification> addable = new List<Notification>();
                foreach(var notice in MainForm._Settings.Notifications_30_Day)
                {
                    if (notice.AssetNumber==_asset.AssetNumber)
                    {
                        if (silenceNotify.Checked)
                        {
                            removable.Add(notice);
                            Notification note = new Notification();
                            note = notice;
                            note.IsNotified = false;
                            addable.Add( note);
                        }
                        else
                        {
                            removable.Add(notice); Notification note = new Notification();
                            note = notice;
                            note.IsNotified = true;
                            addable.Add(note);
                        }
                    }
                }
                foreach(var rem in removable)
                {
                    MainForm._Settings.Notifications_30_Day.Remove(rem);
                }
                
                MainForm._Settings.Notifications_30_Day.AddRange(addable);
            }
            catch { }
            try
            {
                List<Notification> removable = new List<Notification>();
                List<Notification> addable = new List<Notification>();
                foreach (var notice in MainForm._Settings.Notifications_15_Day)
                {
                    if (notice.AssetNumber == _asset.AssetNumber)
                    {
                        if (silenceNotify.Checked)
                        {
                            removable.Add(notice);
                            Notification note = new Notification();
                            note = notice;
                            note.IsNotified = false;
                            addable.Add(note);
                        }
                        else
                        {
                            removable.Add(notice); Notification note = new Notification();
                            note = notice;
                            note.IsNotified = true;
                            addable.Add(note);
                        }
                    }
                }
                foreach (var rem in removable)
                {
                    MainForm._Settings.Notifications_15_Day.Remove(rem);
                }

                MainForm._Settings.Notifications_15_Day.AddRange(addable);
            }
            catch { }

        }

        private void reout_Click(object sender, EventArgs e)
        {
            try
            {
                List<Notification> removals = new List<Notification>();
                foreach(var notice in MainForm._Settings.Notifications_30_Day)
                {
                    if (notice.AssetNumber==_asset.AssetNumber)
                    {
                        removals.Add(notice);
                    }
                }
                foreach(var rem in removals)
                {
                    MainForm._Settings.Notifications_30_Day.Remove(rem);
                }
                removals = new List<Notification>();
                foreach (var notice in MainForm._Settings.Notifications_15_Day)
                {
                    if (notice.AssetNumber == _asset.AssetNumber)
                    {
                        removals.Add(notice);
                    }
                }
                foreach (var rem in removals)
                {
                    MainForm._Settings.Notifications_15_Day.Remove(rem);
                }
                ScanRemove sr = new ScanRemove(_asset.AssetNumber);
                sr.ShowDialog();
            }
            catch { }
        }

        private void AssetView_FormClosing(object sender, FormClosingEventArgs e)
        {
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Notification notice = Notification.Create(_asset.AssetNumber, MainForm.StaticEmails);
            foreach (var email in MainForm._Settings.ServiceEngineers)
            {
                if (email.Name == _asset.ServiceEngineer)
                {
                    notice.Emails.Add(email);
                }
            }
            notice.LastNotified = _asset.DateShipped;
            notice.Time = _asset.DateShipped;
            notice.IsNotified = true;
            MainForm.Add30DayNotice(notice);
            MessageBox.Show("Added To Notification List");
        }
    }
}
