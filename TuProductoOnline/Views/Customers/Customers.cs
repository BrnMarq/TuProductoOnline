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
        private readonly List<Customer> GlobalCustomers = Customer.GetCustomers();
        private List<Customer> CustomersFiltrados;
        private List<Customer> Ordenado;
        private bool BuscarClick = false;
        private bool Descendente = true;
        public CustomersView()
        {
            InitializeComponent();
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            new CustomerProperties(CreateCustomer).ShowDialog();
            VerifyButtons();
        }
        private void Customers_Load(object sender, EventArgs e)
        {
            lblPageNum.Text = "1";
            RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text),GlobalCustomers));
            if (User.ActiveUser.Role != "Admin")
            {
                btnImport.Visible = false;
                btnExport.Visible = false;
            }
            VerifyButtons();
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
            miVentana.Title = "Consultar Cliente";
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
        public void RenderTable(List<Customer> customers)
        {
            dgvCustomers.Rows.Clear();
            dgvCustomers.Refresh();
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
                {
                    ShowDeleteCustomer(id);
                    VerifyButtons();
                }
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
            RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text),GlobalCustomers));
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
            RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text),GlobalCustomers));
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

            RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text),GlobalCustomers));
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pathCSV = openFileDialog1.FileName;
                List<List<string>> clientesImportados = DbHandler.LeerCSV(pathCSV);

                for(int i = 1; i < clientesImportados.Count; i++)
                    if(clientesImportados[i].Count < 9)
                    {
                        MessageBox.Show("El archivo que quiere importar no tiene el formato correcto");
                        return;
                    }                
                
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

                MessageBox.Show("Clientes importados con éxito");

                if (!BuscarClick)
                    RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text),GlobalCustomers));
                else
                    RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text), CustomersFiltrados));
            }

            VerifyButtons();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveCustomer = new SaveFileDialog();
            saveCustomer.FileName = "Clientes";
            string origen = @"" + FileNames.Customers;

            try
            {
                if (saveCustomer.ShowDialog() == DialogResult.OK)
                {
                    myComputer.FileSystem.CopyFile(origen, saveCustomer.FileName + ".csv");
                    MessageBox.Show("Clientes exportados con éxito");
                }
            }
            catch (Exception)
            {
                DialogResult replace = MessageBox.Show("Ya existe un archivo con este nombre. ¿Desea reemplazarlo?", "Reemplazar", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);

                if (replace == DialogResult.OK)
                {
                    myComputer.FileSystem.DeleteFile(saveCustomer.FileName + ".csv");
                    myComputer.FileSystem.CopyFile(origen, saveCustomer.FileName + ".csv");
                    MessageBox.Show("Clientes exportados con éxito");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int result;
            BuscarClick = true;
            

            if(int.TryParse(txtSearch.Text,out result))
            {
                var customer = GlobalCustomers.Where(i => i.Code == result).ToList();
                if (customer.Count == 0 || customer[0].Deleted)
                {
                    MessageBox.Show("No existe un cliente con ese ID");
                    txtSearch.Text = "";
                    BuscarClick = false;
                    return;
                }
                else
                {
                    lblPageNum.Text = "1";
                    CustomersFiltrados = customer;
                    RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text), customer));
                    VerifyButtons();
                }
            }
            else
            {
                var customer = GlobalCustomers.Where(i => i.Name == txtSearch.Text && i.Deleted != true).ToList();
                if (customer.Count == 0)
                {
                    MessageBox.Show("No existe un cliente con ese nombre");
                    txtSearch.Text = "";
                    BuscarClick = false;
                    return;
                }
                else
                {
                    lblPageNum.Text = "1";
                    CustomersFiltrados = customer;
                    RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text), customer));
                    VerifyButtons();
                }
            }

            btnRefresh.Visible = true;
            txtSearch.Text = "";          
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblPageNum.Text = "1";
            RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text),GlobalCustomers));
            VerifyButtons();
            btnRefresh.Visible = false;
            BuscarClick = false;
        }

        private List<Customer> Paginar(int num,List<Customer> customers)
        {
            var lista = customers.Where(i => i.Deleted != true).Skip((num - 1) * 10).Take(10).ToList();

            return lista;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int numPag = (Convert.ToInt32(lblPageNum.Text) + 1);
            lblPageNum.Text = numPag.ToString();
            if (!BuscarClick)
                RenderTable(Paginar(numPag, GlobalCustomers));
            else
                RenderTable(Paginar(numPag, CustomersFiltrados));
            VerifyButtons();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int numPag = (Convert.ToInt32(lblPageNum.Text) - 1);
            lblPageNum.Text = numPag.ToString();
            if (!BuscarClick)
                RenderTable(Paginar(numPag, GlobalCustomers));
            else
                RenderTable(Paginar(numPag, CustomersFiltrados));
            VerifyButtons();
        }

        //Esta función es la que alterna la visibilidad de los botones de la paginación
        //En la primera página, el botón de volver está oculto
        //En la última página, el botón de siguiente está oculto
        private void VerifyButtons()
        {
            if (dgvCustomers.RowCount < 10)
                btnNext.Visible = false;
            else
                btnNext.Visible = true;

            if (lblPageNum.Text == "1")
                btnBack.Visible = false;
            else
                btnBack.Visible = true;
        }

        //Ordenamiento 

        public void OrdenarGridAscendente(DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Ordenado = GlobalCustomers.Where(l => l.Deleted != true).OrderBy(l => l.Code).ToList();
                RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text),Ordenado));
            }
            else if (e.ColumnIndex == 1)
            {
                Ordenado = GlobalCustomers.Where(l => l.Deleted != true).OrderBy(l => l.Name).ToList();
                RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text), Ordenado));
            }
            else if (e.ColumnIndex == 2)
            {
                Ordenado = GlobalCustomers.Where(l => l.Deleted != true).OrderBy(l => l.PhoneNumber).ToList();
                RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text), Ordenado));
            }
            else if (e.ColumnIndex == 3)
            {
                Ordenado = GlobalCustomers.Where(l => l.Deleted != true).OrderBy(l => l.Address).ToList();
                RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text), Ordenado));
            }
        }

        public void OrdenarGridDescendente(DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Ordenado = GlobalCustomers.Where(l => l.Deleted != true).OrderByDescending(l => l.Code).ToList();
                RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text), Ordenado));
            }
            else if (e.ColumnIndex == 1)
            {
                Ordenado = GlobalCustomers.Where(l => l.Deleted != true).OrderByDescending(l => l.Name).ToList();
                RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text), Ordenado));
            }
            else if (e.ColumnIndex == 2)
            {
                Ordenado = GlobalCustomers.Where(l => l.Deleted != true).OrderByDescending(l => l.PhoneNumber).ToList();
                RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text), Ordenado));
            }
            else if (e.ColumnIndex == 3)
            {
                Ordenado = GlobalCustomers.Where(l => l.Deleted != true).OrderByDescending(l => l.Address).ToList();
                RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text), Ordenado));
            }
        }
        private void dgvCustomers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Descendente)
            {
                OrdenarGridAscendente(e);
            }
            else
            {
                OrdenarGridDescendente(e);
            }
            Descendente = !Descendente;
        }
    }
}

