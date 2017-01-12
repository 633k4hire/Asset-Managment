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
    public partial class addCustomer : Form
    {
        public addCustomer()
        {
            InitializeComponent();
        }
        public bool Cancelled = false;
        private void button1_Click(object sender, EventArgs e)
        {
            Cancelled = true;
            this.Hide();
        }

        private void addEngineer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ShipTo_Company.Text == "") { MessageBox.Show("Please Enter Customer Name");return; }
            this.Hide();
        }
    }
}
