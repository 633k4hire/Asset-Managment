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
    public partial class addEngineer : Form
    {
        public addEngineer()
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
            if (engineername.Text == "") { MessageBox.Show("Enter Name"); return; }
            if (!engineeremail.Text.Contains("@") || !engineeremail.Text.Contains("."))
            {
                MessageBox.Show("Enter A Valid Email");
                return;
            }
            this.Hide();
        }
    }
}
