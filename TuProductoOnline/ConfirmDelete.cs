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
    public partial class ConfirmDelete : Form
    {
        private bool _clic = false;
        public bool Clic { get { return _clic; } set { _clic = value; } }
        
        public ConfirmDelete(string nombre)
        {
            InitializeComponent();
            label1.Text = $"{nombre}?";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Clic = true;
            this.Close();
        }
    }
}
