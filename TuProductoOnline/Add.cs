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
    public partial class Add : Form
    {
        //Atributos.

        private string _name;
        private string _brand;
        private string _description;
        private double _price;
        private string _type;
        private int _id;

        //Getters y Setters
        public string Alias { get { return _name; } set { _name = value; } }
        public string Brand { get { return _brand; } set { _brand = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public double Price { get { return _price; } set { _price = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public int Id { get { return _id; } set { _id = value; } }

        
        public Add(int index)
        {
            InitializeComponent();
            txtId.Text = index.ToString();
                        
        }
        
        //Función que regresará al Form Products lo que el usuario haya añadido.
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                Alias = txtName.Text.Trim();
                Brand = txtBrand.Text.Trim();
                Description = txtDescription.Text.Trim();
                Type = cmbType.Text.Trim();
                Price = Convert.ToDouble(txtPrice.Text.Trim());
                Id = Convert.ToInt32(txtId.Text.Trim());                                
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ingresó un valor NO numérico en la casilla del precio");
            }
        }
        //Funciones que bloquean el botón de agregado si no tiene todos sus campos llenos.
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



        //Función que inhabilita las teclas para la opción de Tipo.
        private void cmbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        //Función que solo valida el ingreso de números y la coma. 
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtPrice.Text == "")
            {
                TxtPriceErrorlbl.Visible = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtPrice.Text != "")
            {
                TxtPriceErrorlbl.Visible = false;
            }
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 && e.KeyChar != 44) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
            }

        }

        //Funciones que habilitan solo el ingreso de letras y numeros
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtName.Text == "")
            {
                TxtNameErrorlbl.Visible = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtName.Text != "")
            {
                TxtNameErrorlbl.Visible = false;
            }
            Validar.Tab_Enter(e);
        }

        private void txtBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtBrand.Text == "")
            {
                TxtBrandErrorlbl.Visible = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtBrand.Text != "")
            {
                TxtBrandErrorlbl.Visible = false;
            }
            Validar.Tab_Enter(e);
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtDescription.Text == "")
            {
                TxtDescriptionErrorlbl.Visible = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtDescription.Text != "")
            {
                TxtDescriptionErrorlbl.Visible = false;
            }
            Validar.Tab_Enter(e);
        }
    }
}
