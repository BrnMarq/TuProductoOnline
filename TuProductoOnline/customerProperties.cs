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
        string NamePlaceholder = "Nombre";
        string LastNamePlaceholder = "Apellido";
        string DocumentPlaceholder = "Cédula/RIF";
        string PhoneNumberPlaceholder = "Teléfono";
        string AddressPlaceholder = "Dirección";
        string EmailPlaceholder = "Email";

        //List<Customer> clientes = new List<Customer>();

        //internal List<Customer> Clientes { get => clientes; set => clientes = value; }

        //Customer cliente = new Customer();

        //internal Customer Cliente { get => cliente; }

        public CustomerProperties()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            crearCliente();
            this.Close(); 
        }

        private Customer crearCliente()
        {
            Customer cliente = new Customer(1,txtName.Text, txtLastName.Text, txtId.Text, txtPhoneNumber.Text, txtAddress.Text, txtEmail.Text, cbType.SelectedItem.ToString());

            return cliente;
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void CustomerProperties_Load(object sender, EventArgs e)
        {
            txtName.Text = NamePlaceholder;
            txtLastName.Text = LastNamePlaceholder;
            txtId.Text = DocumentPlaceholder;
            txtPhoneNumber.Text = PhoneNumberPlaceholder;
            txtAddress.Text = AddressPlaceholder;
            txtEmail.Text = EmailPlaceholder;
            cbType.SelectedIndex = 0;
        }

        private void VerifyInputs()
        {
            //Verificaciones de que los campos del usuario y clave no esten vacíos 
            //y asi activar el boton de acceso
            bool txtNameIsValid = string.IsNullOrEmpty(txtName.Text) || txtName.Text == NamePlaceholder;
            bool txtLastNameIsValid = string.IsNullOrEmpty(txtLastName.Text) || txtLastName.Text == LastNamePlaceholder;
            bool txtIdIsValid = string.IsNullOrEmpty(txtId.Text) || txtId.Text == DocumentPlaceholder;
            bool txtPhoneNumberInputIsInvalid = string.IsNullOrEmpty(txtPhoneNumber.Text) || txtPhoneNumber.Text == PhoneNumberPlaceholder;
            bool txtAddressIsInvalid = string.IsNullOrEmpty(txtAddress.Text) || txtAddress.Text == AddressPlaceholder;
            bool txtEmailIsInvalid = string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == EmailPlaceholder;
            if (txtNameIsValid || txtLastNameIsValid || txtIdIsValid || txtPhoneNumberInputIsInvalid || txtAddressIsInvalid || txtEmailIsInvalid)
            {
                btnAccept.Enabled = false;
                return;
            }
            btnAccept.Enabled = true;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            VerifyInputs();
        }

        // ------------------ Placeholders ------------------
        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == NamePlaceholder)
                txtName.Text = "";
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
                txtName.Text = NamePlaceholder;
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            if (txtLastName.Text == LastNamePlaceholder)
                txtLastName.Text = "";
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
                txtLastName.Text = LastNamePlaceholder;
        }

        private void txtId_Enter(object sender, EventArgs e)
        {
            if (txtId.Text == DocumentPlaceholder)
                txtId.Text = "";
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
                txtId.Text = DocumentPlaceholder;
        }

        private void txtPhoneNumber_Enter(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text == PhoneNumberPlaceholder)
                txtPhoneNumber.Text = "";
        }

        private void txtPhoneNumber_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                txtPhoneNumber.Text = PhoneNumberPlaceholder;
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            if (txtAddress.Text == AddressPlaceholder)
                txtAddress.Text = "";
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
                txtAddress.Text = AddressPlaceholder;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == EmailPlaceholder)
                txtEmail.Text = "";
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                txtEmail.Text = EmailPlaceholder;
        }
    }
}
