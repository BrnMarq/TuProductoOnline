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
using TuProductoOnline.Views.Customers;

namespace TuProductoOnline.Views
{ 
    public partial class CustomersView : Form
    {
        CustomerProperties miVentana = new CustomerProperties();
        public CustomersView()
        {
            InitializeComponent();
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            new CustomerProperties(CreateCustomer).ShowDialog();
        }
        private void Customers_Load(object sender, EventArgs e)
        {
            RenderTable();
        }
        private void btnCheckCustomer_Click(object sender, EventArgs e)
        {
            miVentana.BtnActivado = false;
            
           int idSeleccionado = int.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
           Customer customer = Customer.GetCustomerById(idSeleccionado); 
          
            miVentana.Code = customer.Code.ToString();
            miVentana.Nombre = customer.Name;
            miVentana.Last_name = customer.LastName;
            miVentana.Id = customer.Document;
            miVentana.Phone_number = customer.PhoneNumber;
            miVentana.Address = customer.Address;
            miVentana.Email = customer.Email;
            if (customer.Type == "Ordinario")
            {
                miVentana.Type = 0;
            }
            else
            {
                miVentana.Type = 1;
            }

            miVentana.ShowDialog();
        }

        public void RenderTable()
        {
            dgvCustomers.Rows.Clear();
            dgvCustomers.Refresh();
            List<Customer> customers = Customer.GetCustomers();
            foreach (Customer customer in customers)
            {
                if (customer.Deleted) continue;
                dgvCustomers.Rows.Add(customer.Code, customer.Name, customer.PhoneNumber, customer.Address);
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgvCustomers.Rows[e.RowIndex].Cells[0].Value.ToString();
            if(e.ColumnIndex == dgvCustomers.Columns["edit"].Index)
                ShowEditModal(id);
            if (e.ColumnIndex == dgvCustomers.Columns["delete"].Index)
                ShowDeleteCustomer(id);
        }

        public void ShowEditModal(string id)
        {
            Customer customer = Customer.GetCustomerById(int.Parse(id));
            new CustomerProperties(EditCustomer, customer).ShowDialog();
        }

        public void ShowDeleteCustomer(string id)
        {
            new DeleteCustomer(int.Parse(id), DeleteCustomer).ShowDialog();
        }

        public void CreateCustomer(List<string> customerValues)
        {
            new Customer(
                customerValues[1],
                customerValues[2],
                customerValues[3],
                customerValues[4],
                customerValues[5],
                customerValues[6],
                customerValues[7]
                );
            RenderTable();
        }
        public void EditCustomer(List<string> customerValues)
        {
            Customer customer = Customer.GetCustomerById(int.Parse(customerValues[0]));
            List<string> values = new List<string> {
                customer.Code.ToString(),
                customerValues[1],
                customerValues[2],
                customerValues[3],
                customerValues[4],
                customerValues[5],
                customerValues[6],
                customerValues[7],
                customer.Deleted.ToString(),             
            };
            Customer.UpdateCustomer(customer.Code, values);
            RenderTable();
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = Customer.GetCustomerById(id);
            List<string> values = new List<string> {
                customer.Code.ToString(),
                customer.Name,
                customer.LastName,
                customer.Document,
                customer.PhoneNumber,
                customer.Address,
                customer.Email,
                customer.Type,
                "true",
            };
            Customer.UpdateCustomer(customer.Code, values);
            RenderTable();
        }
    }
}

