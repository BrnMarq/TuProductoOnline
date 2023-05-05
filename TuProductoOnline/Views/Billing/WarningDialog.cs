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
    public partial class WarningDialog : Form
    {
        public WarningDialog(string aviso)
        {
            InitializeComponent();
            txtAdvertencia.Text = aviso;
        }

        private void bntAñadirProduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void WarningDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
