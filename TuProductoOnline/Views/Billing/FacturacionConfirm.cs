using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProductoOnline.Models;

namespace TuProductoOnline
{
    public partial class FacturacionConfirm : Form
    {
        public bool confirm;
        public FacturacionConfirm()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            confirm= true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            confirm = false;
            this.Close();
        }

        
    }
}
