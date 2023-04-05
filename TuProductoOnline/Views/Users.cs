using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuProductoOnline.Views
{
    public partial class Users : Form
    {
        AddUsers miVentana = new AddUsers();
        public Users()
        {
            InitializeComponent();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            miVentana.ShowDialog();
        }
    }
}
