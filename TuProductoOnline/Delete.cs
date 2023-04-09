using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuProductoOnline
{
    public partial class Delete : Form
    {
        private int _id;
       
        public int Id { get { return _id; } set { _id = value; } }
        
        public Delete()
        {
            InitializeComponent();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <=  47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(txtId.Text);            
            this.Close();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) 
            {
                btnContinue.Enabled = false;
            }
            else 
            {
                btnContinue.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
