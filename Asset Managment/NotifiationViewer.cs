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
    public partial class NotifiationViewer : Form
    {
        public NotifiationViewer()
        {
            InitializeComponent();
        }
        public List<Notification> _ThirtyDay = new List<Notification>();
        public List<Notification> _FifteenDay = new List<Notification>();
        public NotifiationViewer(List<Notification> ThirtyDay,List<Notification>FifteenDay)
        {
            _ThirtyDay = ThirtyDay;
            _FifteenDay = FifteenDay;
            InitializeComponent();
            foreach(var notice in ThirtyDay)
            {
                ListViewItem item = new ListViewItem();
                ListViewItem.ListViewSubItem time = new ListViewItem.ListViewSubItem(item, notice.Time.ToString());
                
                ListViewItem.ListViewSubItem time2 = new ListViewItem.ListViewSubItem(item, notice.LastNotified.ToString());
                item.SubItems.Add(time);
                item.SubItems.Add(time2);
                item.Tag = notice;
                item.Name = item.Text = notice.AssetNumber;
                _30DayList.Items.Add(item);
            }
            foreach (var notice in FifteenDay)
            {
                ListViewItem item = new ListViewItem();
                ListViewItem.ListViewSubItem time = new ListViewItem.ListViewSubItem(item, notice.Time.ToString());

                ListViewItem.ListViewSubItem time2 = new ListViewItem.ListViewSubItem(item, notice.LastNotified.ToString());
                item.SubItems.Add(time);
                item.Tag = notice;
                item.SubItems.Add(time2);
                item.Name = item.Text = notice.AssetNumber;
                _15DayList.Items.Add(item);
            }
        }
        public void refresh()
        {
            _30DayList.Items.Clear();
            _15DayList.Items.Clear();
            foreach (var notice in _ThirtyDay)
            {
                ListViewItem item = new ListViewItem();
                ListViewItem.ListViewSubItem time = new ListViewItem.ListViewSubItem(item, notice.Time.ToString());

                ListViewItem.ListViewSubItem time2 = new ListViewItem.ListViewSubItem(item, notice.LastNotified.ToString());
                item.SubItems.Add(time);
                item.SubItems.Add(time2);
                item.Name = item.Text = notice.AssetNumber;
                _30DayList.Items.Add(item);
            }
            foreach (var notice in _FifteenDay)
            {
                ListViewItem item = new ListViewItem();
                ListViewItem.ListViewSubItem time = new ListViewItem.ListViewSubItem(item, notice.Time.ToString());

                ListViewItem.ListViewSubItem time2 = new ListViewItem.ListViewSubItem(item, notice.LastNotified.ToString());
                item.SubItems.Add(time);
                item.SubItems.Add(time2);
                item.Name = item.Text = notice.AssetNumber;
                _15DayList.Items.Add(item);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clearAllNotificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ThirtyDay= MainForm._Settings.Notifications_30_Day = new List<Notification>();
            _FifteenDay = MainForm._Settings.Notifications_15_Day = new List<Notification>();
            refresh();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thirtyselected!=null)
            {
                if (thirtyselected.Tag is Notification)
                {
                    MainForm._Settings.Notifications_30_Day.Remove((Notification)thirtyselected.Tag);
                    refresh();
                }
            }
        }
        public ListViewItem thirtyselected = null;
        public ListViewItem fifteenselected = null;
        private void _30DayList_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            thirtyselected = e.Item;
        }

        private void _15DayList_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            fifteenselected = e.Item;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fifteenselected != null)
            {
                if (thirtyselected.Tag is Notification)
                {
                    MainForm._Settings.Notifications_15_Day.Remove((Notification)fifteenselected.Tag);
                    refresh();
                }
            }
        }

        private void setNotificationsForAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm._Settings.Notifications_15_Day = new List<Notification>();
            MainForm._Settings.Notifications_30_Day = new List<Notification>();
            foreach(var asset in MainForm.Library.Assets)
            {
                if (asset.IsOut)
                {
                    Notification notice = Notification.Create(asset.AssetNumber, MainForm.StaticEmails);
                    foreach (var email in MainForm._Settings.ServiceEngineers)
                    {
                        if (email.Name == asset.ServiceEngineer)
                        {
                            notice.Emails.Add(email);
                        }
                    }
                    notice.LastNotified = asset.DateShipped;
                    notice.Time = asset.DateShipped;
                    notice.IsNotified = true;
                    MainForm.Add30DayNotice(notice);
                }
            }
            _ThirtyDay = MainForm._Settings.Notifications_30_Day;
            _FifteenDay = MainForm._Settings.Notifications_15_Day;
            refresh();
        }
    }
}
