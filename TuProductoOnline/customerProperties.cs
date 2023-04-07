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
using TuProductoOnline.Utils;
using TuProductoOnline.Views;

namespace TuProductoOnline
{
    public partial class CustomerProperties : Form
    {       
        public CustomerProperties()
        {
            InitializeComponent();
            cbType.SelectedIndex = 0;
            btnAccept.Enabled = false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            crearCliente();
            this.Close();
        }

        private Customer crearCliente()
        {
            Customer cliente = new Customer(
               txtName.Text,
               txtLastName.Text,
               txtId.Text,
               txtPhoneNumber.Text,
               txtAddress.Text,
               txtEmail.Text,
               cbType.SelectedItem.ToString()
            );

            return cliente;
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
                
        }

        private void CustomerProperties_FormClosed(object sender, FormClosedEventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtLastName.Text = "";
            txtId.Text = "";
            txtPhoneNumber.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            cbType.SelectedIndex = 0;

            txtName.TabIndex = 0;
            txtLastName.TabIndex = 1;
            txtId.TabIndex = 2;
            txtPhoneNumber.TabIndex = 3;
            txtAddress.TabIndex = 4;
            txtEmail.TabIndex = 5;
            cbType.TabIndex = 6;
        }

        private void VerifyInputs()
        {
           if(txtName.Text != "" && txtLastName.Text != "" && txtId.Text != "" && txtPhoneNumber.Text != "" && txtAddress.Text != "" && txtEmail.Text != "")
            {
                btnAccept.Enabled = true;
            }
            else
            {
                btnAccept.Enabled = false;
            }
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            VerifyInputs();
        }

        private int VerifyLengthTlf()
        {
            string telefono = txtPhoneNumber.Text;
            int control = 0;

            if(telefono.Length < 11)
            {
                MessageBox.Show("El número mínimo de caracteres para el teléfono es 12");
            }
            else if(telefono.Length > 20)
            {
                MessageBox.Show("El número máximo de caracteres para el teléfono es 20");
            }
            else
            {
                control = 1;
            }

            return control;
        }

        private int VerifyLengthCedula()
        {
            string cedula = txtId.Text;
            int control = 0;

            if (cedula.Length < 8)
            {
                MessageBox.Show("El número mínimo de caracteres para cédula/RIF es 8");
            }
            else if (cedula.Length > 20)
            {
                MessageBox.Show("El número máximo de caracteres para cédula/RIF es 20");
            }
            else
            {
                control = 1;
            }

            return control;
        }
        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if(VerifyLengthCedula() == 1)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if(VerifyLengthTlf() == 1)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        //Getters y setters para los textbox
        public string Code { get => txtCode.Text; set => txtCode.Text = value; }
        public string Nombre { get => txtName.Text; set => txtName.Text = value; }
        public string Last_name { get => txtLastName.Text; set => txtLastName.Text = value; }
        public string Id { get => txtId.Text; set => txtId.Text = value; }
        public string Phone_number { get => txtPhoneNumber.Text; set => txtPhoneNumber.Text = value; }
        public string Address { get => txtAddress.Text; set => txtAddress.Text = value; }
        public string Email { get => txtEmail.Text; set => txtEmail.Text = value; }
        public int Type { get => cbType.SelectedIndex; set => cbType.SelectedIndex = value; }
        public bool BtnActivado { get => btnAccept.Enabled; set => btnAccept.Enabled = value; }

    }
}
