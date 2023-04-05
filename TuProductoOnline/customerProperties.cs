﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProductoOnline.Models;

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
            Customer cliente = new Customer();

            cliente.IncrementarCode();
            cliente.Name = txtName.Text;
            cliente.LastName = txtLastName.Text;
            cliente.Document = txtId.Text;
            cliente.PhoneNumber = txtPhoneNumber.Text;
            cliente.Direction = txtDirection.Text;
            cliente.Email = txtEmail.Text;
            cliente.Type = cbType.SelectedItem.ToString();

            this.Close(); 
        }
    }
}
