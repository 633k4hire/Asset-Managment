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
    public partial class SearchResults : Form
    {
        public string SearchTerm="";
        public SearchResults()
        {
            InitializeComponent();
        }
        public SearchResults(string searchTerm)
        {
            SearchTerm = searchTerm;
            InitializeComponent();
        }
    }
}
