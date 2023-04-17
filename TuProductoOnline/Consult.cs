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
    public partial class Consult : Form
    {
        public Consult(string id, string type, string name, string brand, string description, string price)
        {
            InitializeComponent();
            txtId.Text = id;
            txtName.Text = name;
            txtType.Text = type;
            txtPrice.Text = price + "Bs";
            txtDescription.Text = description;
            txtBrand.Text = brand;
        }

        private void Consult_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
