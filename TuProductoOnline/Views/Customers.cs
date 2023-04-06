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

namespace TuProductoOnline.Views
{
    public partial class Customers : Form
    {
        CustomerProperties miVentana = new CustomerProperties();
        public Customers()
        {
            InitializeComponent();

        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            miVentana.ShowDialog();
        }
        private void Customers_Load(object sender, EventArgs e)
        {
            List<Customer> customers = Customer.GetCustomers();
            foreach (Customer customer in customers)
            {
                dgvCustomers.Rows.Add(customer.Code, customer.Name, customer.PhoneNumber, customer.Address);
            }
        }
    }
}
