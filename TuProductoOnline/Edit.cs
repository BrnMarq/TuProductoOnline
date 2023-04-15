using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProductoOnline.Utils;

namespace TuProductoOnline
{

    public partial class Edit : Form
    {
        private string _name;
        private string _brand;
        private string _description;
        private double _price;
        private string _type;
        private int _id;
        private bool _clic = false;

        public bool Clic { get { return _clic; } set { _clic = value; } }
        public string Alias { get { return _name; } set { _name = value; } }
        public string Brand { get { return _brand; } set { _brand = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public double Price { get { return _price; } set { _price = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public int Id { get { return _id; } set { _id = value; } }

        public Edit(string id, string type, string name, string brand, string description, string price)
        {
            InitializeComponent();
            txtId.Text = id;
            cmbType.Text = type;
            txtName.Text = name;
            txtBrand.Text = brand;
            txtDescription.Text = description;
            txtPrice.Text = price;

            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Alias = txtName.Text.Trim();
                Brand = txtBrand.Text.Trim();
                Description = txtDescription.Text.Trim();
                Type = cmbType.Text.Trim();
                Price = Convert.ToDouble(txtPrice.Text);
                Id = Convert.ToInt32(txtId.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingresó un valor NO numérico en la casilla del precio");
            }
        }

        private void cmbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrand.Text) || string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrEmpty(cmbType.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPrice.Text))
            {
                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrand.Text) || string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrEmpty(cmbType.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPrice.Text))
            {
                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
            }
        }

        private void txtBrand_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrand.Text) || string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrEmpty(cmbType.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPrice.Text))
            {
                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrand.Text) || string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrEmpty(cmbType.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPrice.Text))
            {
                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrand.Text) || string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrEmpty(cmbType.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPrice.Text))
            {
                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Clic = true;
            this.Close();
        }

        private void Edit_Load(object sender, EventArgs e)
        {

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 && e.KeyChar != 44)||(e.KeyChar >= 58 && e.KeyChar <= 255)) 
            {
                e.Handled = true;
            }
        }
    }
}
