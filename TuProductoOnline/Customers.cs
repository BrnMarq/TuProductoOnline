using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TuProductoOnline
{
    public partial class Customers : TuProductoOnline.NavBar
    {
       
        public Customers()
        {
            InitializeComponent();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            customerProperties customerWindow = new customerProperties();
            customerWindow.Show();
        }

        private void btnCheckCustomer_Click(object sender, EventArgs e)
        {
            customerProperties customerWindow = new customerProperties();
            customerWindow.Show();
        }
    }
}
