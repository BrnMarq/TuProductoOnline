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
        private readonly int _id;
        private readonly string _name = "";
        private readonly string _last_name = "";
        private readonly string _document = "";
        private readonly string _phone_number = "";
        private readonly string _address = "";
        private readonly string _email = "";
        private readonly string _type = "";
        private readonly bool _isEdit = false;
        private readonly char[] eliminar= { '\n', '\r' };

        private readonly Action<List<string>> acceptFunction;

        public CustomerProperties()
        {
            InitializeComponent();        
        }
        public CustomerProperties(Action<List<string>> callback)
        {
            InitializeComponent();
            cbType.SelectedIndex = 0;
            btnAccept.Enabled = false;
            acceptFunction = callback;
        }

        public CustomerProperties(Action<List<string>> callback, Customer customer)
        {
            InitializeComponent();
            _id = customer.Code;
            _name = customer.Name;
            _last_name = customer.LastName;
            _document = customer.Document;
            _phone_number = customer.PhoneNumber;
            _address = customer.Address;
            _email = customer.Email;
            _type = customer.Type;
            _isEdit = true;

            acceptFunction = callback;
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            VerifyInputs();
        }
        private void CustomerProperties_Load(object sender, EventArgs e)
        {
            if (_isEdit)
            {
                TitleCustomers.Text = "Editar Cliente";
                txtName.Text = _name;
                txtLastName.Text = _last_name;
                txtId.Text = _document;
                txtPhoneNumber.Text = _phone_number;
                txtAddress.Text = _address;
                txtEmail.Text = _email;
                if (_type == "Ordinario")
                {
                    cbType.SelectedIndex = 0;
                }
                else
                {
                    cbType.SelectedIndex = 1;
                }
                return;
            }
        }
        private void CustomerProperties_FormClosed(object sender, FormClosedEventArgs e)
        {
            txtName.Text = "";
            txtLastName.Text = "";
            txtId.Text = "";
            txtPhoneNumber.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            cbType.SelectedIndex = 0;

            txtName.Select();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<string> values = new List<string>
            {
                _id.ToString(),
                txtName.Text,
                txtLastName.Text,
                txtId.Text.TrimStart(eliminar),
                txtPhoneNumber.Text.TrimStart(eliminar),
                txtAddress.Text,
                txtEmail.Text.TrimStart(eliminar),
                cbType.SelectedItem.ToString(),

            };
            acceptFunction(values);
            this.Close();
        }

        private void VerifyInputs()
        {
            if (txtName.Text != "" && txtLastName.Text != "" && txtId.Text != "" && txtPhoneNumber.Text != "" && txtAddress.Text != "" && txtEmail.Text != "")
            {
                btnAccept.Enabled = true;
            }
            else
            {
                btnAccept.Enabled = false;
            }
        }

        private int VerifyLengthCedula()
        {
            string cedula = txtId.Text;
            int control = 0;

            if (cedula.Length < 7)
            {
                MessageBox.Show("El número mínimo de caracteres para cédula/RIF es 7");
            }
            else
            {
                control = 1;
            }

            return control;
        }
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
            Validar.SoloLetras(e);
            Validar.Tab_Enter(e);
        }
        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtLastName.Text == "")
            {
                TxtLastNameErrorlbl.Visible = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtLastName.Text != "")
            {
                TxtLastNameErrorlbl.Visible = false;
            }
            Validar.SoloLetras(e);
            Validar.Tab_Enter(e);
        }
        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (VerifyLengthCedula() == 1)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                    TxtIdErrorlbl.Visible = false;
                }
                else 
                {
                    TxtIdErrorlbl.Visible = true;
                }
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (Validar.ValidarTelefono(txtPhoneNumber.Text.TrimStart(eliminar)))
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                    TxtPhoneNumberErrorlbl.Visible = false;
                }
                else
                {
                    MessageBox.Show("Número de teléfono inválido");
                    TxtPhoneNumberErrorlbl.Visible = true;
                }
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtAddress.Text == "")
            {
                TxtAddressErrorlbl.Visible = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && txtAddress.Text != "")
            {
                TxtAddressErrorlbl.Visible = false;
            }
            Validar.Tab_Enter(e);
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (Validar.ValidarEmail(txtEmail.Text.TrimStart(eliminar)))
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                    TxtEmailErrorlbl.Visible = false;
                    btnAccept.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Correo inválido");
                    TxtEmailErrorlbl.Visible = true;
                    btnAccept.Enabled = false;
                }
            }
        }

        //Setters para el texto de los textbox
        public string Nombre {  set => txtName.Text = value; }
        public string Last_name {set => txtLastName.Text = value; }
        public string Id { set => txtId.Text = value; }
        public string Phone_number {  set => txtPhoneNumber.Text = value; }
        public string Address { set => txtAddress.Text = value; }
        public string Email { set => txtEmail.Text = value; }
        public int Type { set => cbType.SelectedIndex = value; }
        public bool BtnActivado {set => btnAccept.Enabled = value; }

        //Setters para ReadOnly de los textBox

        public bool Nombre1 { set => txtName.ReadOnly = value; }
        public bool Apellido { set => txtLastName.ReadOnly = value; }
        public bool Cedula { set => txtId.ReadOnly = value; }
        public bool Telefono { set => txtPhoneNumber.ReadOnly = value; }
        public bool Direccion { set => txtAddress.ReadOnly = value; }
        public bool Correo { set => txtEmail.ReadOnly = value; }

        //Setters para Color de los textBox
        public Color ApellidoColor { set => txtLastName.BackColor = value; }
        public Color CedulaColor { set => txtId.BackColor = value; }
        public Color TelefonoColor { set => txtPhoneNumber.BackColor = value; }
        public Color DireccionColor { set => txtAddress.BackColor = value; }
        public Color CorreoColor { set => txtEmail.BackColor = value; }

    }
}