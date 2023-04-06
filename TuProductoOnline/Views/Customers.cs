using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProductoOnline.Models;

namespace TuProductoOnline.Views
{
    public partial class Customers : Form
    {
        CustomerProperties miVentana = new CustomerProperties();
        private int index = 0;
        public Customers()
        {
            InitializeComponent();
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Customer cliente = new Customer();
            miVentana.ShowDialog();

            index = dgvCustomers.Rows.Add();
            

        }
    }
}
