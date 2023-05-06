using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuProductoOnline.Views.Billing
{
    public partial class ProductDelete : Form
    {
        private DataGridView _dgv;
        public static bool _eliminated;
        public ProductDelete(ref DataGridView dgv)
        {
            _dgv = dgv;
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _eliminated = false;
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            _eliminated = true;
            _dgv.Rows.Remove(_dgv.CurrentRow);
            this.Close();
            MessageBox.Show("Producto eliminado con exito");
        }
    }
}
