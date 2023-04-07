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
        private void btnCheckCustomer_Click(object sender, EventArgs e)
        {
            miVentana.BtnActivado = false;

            List<Customer> customers = Customer.GetCustomers();
            
            int idSeleccionado = int.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());

                foreach (Customer customer in customers)
                {
                    if (customer.Code == idSeleccionado)
                    {
                        miVentana.Code = customer.Code.ToString();
                        miVentana.Nombre = customer.Name;
                        miVentana.Last_name = customer.LastName;
                        miVentana.Id = customer.Document;
                        miVentana.Phone_number = customer.PhoneNumber;
                        miVentana.Address = customer.Address;
                        miVentana.Email = customer.Email;
                        if(customer.Type == "Ordinario")
                        {
                            miVentana.Type = 0;
                        }
                        else
                        {
                            miVentana.Type = 1;
                        }
                        break;
                    }
                }
            miVentana.ShowDialog();
        }

    }
}

