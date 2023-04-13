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
                txtCode.Text = _id.ToString();
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
            txtCode.Text = "";
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
                txtId.Text,
                txtPhoneNumber.Text,
                txtAddress.Text,
                txtEmail.Text,
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

        private int VerifyLengthTlf()
        {
            string telefono = txtPhoneNumber.Text;
            int control = 0;

            if (telefono.Length < 11)
            {
                MessageBox.Show("El número mínimo de caracteres para el teléfono es 11");
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
                    Validar.Tab_Enter(e); 
                }
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (VerifyLengthTlf() == 1)
                {
                    Validar.Tab_Enter(e);
                }
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.Tab_Enter(e);
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.Tab_Enter(e);
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