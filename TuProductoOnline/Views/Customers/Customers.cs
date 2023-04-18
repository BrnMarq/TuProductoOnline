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
using TuProductoOnline.Utils;
using System.IO;
using TuProductoOnline.Consts;
using Microsoft.VisualBasic.Devices;

namespace TuProductoOnline.Views
{
    public partial class CustomersView : Form
    {
        CustomerProperties miVentana = new CustomerProperties();
        Computer myComputer = new Computer();
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
        public void ConsultarCliente()
        {
            int idSeleccionado = int.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
            Customer customer = Customer.GetCustomerById(idSeleccionado);

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

            ConfigurarCustomerProperties();  
            miVentana.ShowDialog();
        }

        public void ConfigurarCustomerProperties()
        {
            miVentana.Nombre1 = true;
            miVentana.Apellido = true;
            miVentana.Cedula = true;
            miVentana.Telefono = true;
            miVentana.Direccion = true;
            miVentana.Correo = true;
            miVentana.ApellidoColor = Color.White;
            miVentana.CedulaColor = Color.White;
            miVentana.TelefonoColor = Color.White;
            miVentana.DireccionColor = Color.White;
            miVentana.CorreoColor = Color.White;
            miVentana.BtnActivado = false;
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
            try
            {
                string id = dgvCustomers.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (e.ColumnIndex == dgvCustomers.Columns["Edit"].Index)
                    ShowEditModal(id);
                if (e.ColumnIndex == dgvCustomers.Columns["Delete"].Index)
                    ShowDeleteCustomer(id);
                if (e.ColumnIndex == dgvCustomers.Columns["Consultar"].Index)
                    ConsultarCliente();
            }
            catch (ArgumentOutOfRangeException)
            {

            }
              
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
                customer.Deleted.ToString().ToLower(),
            };
            Customer.UpdateCustomer(customer.Code, values);
            MessageBox.Show("Cliente editado con exito");
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
            MessageBox.Show("Cliente borrado con exito");
            RenderTable();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pathCSV = openFileDialog1.FileName;
                List<List<string>> clientesImportados = DbHandler.LeerCSV(pathCSV);

                try
                {
                    for (int i = 1; i < clientesImportados.Count; i++)
                    {
                        if (clientesImportados[i][8] == "true") continue;
                        new Customer(
                            clientesImportados[i][1].ToString(),
                            clientesImportados[i][2].ToString(),
                            clientesImportados[i][3].ToString(),
                            clientesImportados[i][4].ToString(),
                            clientesImportados[i][5].ToString(),
                            clientesImportados[i][6].ToString(),
                            clientesImportados[i][7].ToString()
                        );
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("El archivo que quiere importar no tiene el formato correcto");
                }               
                RenderTable();
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveCustomer = new SaveFileDialog();
                saveCustomer.FileName = "Clientes";
                string origen = @"" + FileNames.Customers;

                if (saveCustomer.ShowDialog() == DialogResult.OK)
                {
                    myComputer.FileSystem.CopyFile(origen, saveCustomer.FileName + ".csv");
                    MessageBox.Show("Clientes exportados con éxito");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ya existe un archivo con este nombre");
            } 
        }
    }
}

