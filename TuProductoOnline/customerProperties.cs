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
