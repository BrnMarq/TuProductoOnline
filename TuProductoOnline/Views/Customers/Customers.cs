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
using TuProductoOnline.Views.Customers;
using TuProductoOnline.Utils;
using System.IO;
using TuProductoOnline.Consts;
using Microsoft.VisualBasic.Devices;

namespace TuProductoOnline.Views
{
    public partial class CustomersView : Form
    {
        int acum = 1;
        CustomerProperties miVentana = new CustomerProperties();
        Computer myComputer = new Computer();
        private readonly List<Customer> GlobalCustomers = Customer.GetCustomers();
        private List<Customer> CustomersFiltrados;
        private List<Customer> Ordenado;
        private bool Buscar = false;
        private bool Ascendente = true;
        private int CustomerForPage = 25;
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
            VerifyButtons();

            if (User.ActiveUser.Role != "Admin")
            {
                btnImport.Visible = false;
                btnExport.Visible = false;
            }
        }
        private void VerifyButtons()
        {
            int lastPage;
            if (acum == 1)
            {
                btnprimero.Enabled = false;
                btnantes.Enabled = false;
            }
            if (!Buscar)
            {
                botones(acum + 1, btn2, GlobalCustomers);
                botones(acum + 2, btn3, GlobalCustomers);
                botones(acum + 3, btn4, GlobalCustomers);
                lastPage = LastPage(GlobalCustomers);
                RenderTable(Paginar(acum, GlobalCustomers));
                if (btn2.Enabled == false)
                {
                    btnultimo.Enabled = false;
                    btnsiguiente.Enabled = false;
                }
                else
                {
                    btnultimo.Enabled = true;
                    btnsiguiente.Enabled = true;
                }
            }
            else
            {
                botones(acum + 1, btn2, CustomersFiltrados);
                botones(acum + 2, btn3, CustomersFiltrados);
                botones(acum + 3, btn4, CustomersFiltrados);
                lastPage = LastPage(CustomersFiltrados);
                RenderTable(Paginar(acum, CustomersFiltrados));
                if (btn2.Enabled == false)
                {
                    btnultimo.Enabled = false;
                    btnsiguiente.Enabled = false;
                }
                else
                {
                    btnultimo.Enabled = true;
                    btnsiguiente.Enabled = true;
                }
            }
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
                    btnprimero_Click(sender, e);
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

            SumarBotones();
            if (btn2.Enabled == true)
            {
                btnsiguiente.Enabled = true;
                btnultimo.Enabled = true;
            }
            else
            {
                btnsiguiente.Enabled = false;
                btnultimo.Enabled = false;
            }

            Renderizar();
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
            txtSearch.Text = "";
            Renderizar();
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

            VerifyButtons();
            
            Renderizar(); 
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
                VerifyButtons();       
            }

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
                DialogResult replace = MessageBox.Show("Ya existe un archivo con este nombre. ¿Desea reemplazarlo?", "Reemplazar", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (replace == DialogResult.OK)
                {
                    myComputer.FileSystem.DeleteFile(saveCustomer.FileName + ".csv");
                    myComputer.FileSystem.CopyFile(origen, saveCustomer.FileName + ".csv");
                    MessageBox.Show("Clientes exportados con éxito");
                }
            }
        }
        private List<Customer> Paginar(int num,List<Customer> customers)
        {
            var lista = customers.Where(i => i.Deleted != true).Skip((num - 1) * CustomerForPage).Take(CustomerForPage).ToList();

            return lista;
        }
        public void OrdenarGridAscendente(DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex > 3) return;

            List<string> searchParams = new List<string> { "Code", "Name", "PhoneNumber", "Address" };
            string searchParam = searchParams[e.ColumnIndex];
            int pageNum = Convert.ToInt32(lblPageNum.Text);

            List<Customer> paginated = Paginar(pageNum, GlobalCustomers);

            Ordenado = paginated.OrderBy(l => Searcher(l,searchParam)).ToList();

            RenderTable(Ordenado);
        }
        public void OrdenarGridDescendente(DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex > 3) return;

            List<string> searchParams = new List<string> { "Code", "Name", "PhoneNumber", "Address" };
            string searchParam = searchParams[e.ColumnIndex];
            int pageNum = Convert.ToInt32(lblPageNum.Text);

            List<Customer> paginated = Paginar(pageNum, GlobalCustomers);

            Ordenado = paginated.OrderByDescending(l => Searcher(l,searchParam)).ToList();

            RenderTable(Ordenado);

        }
        public object Searcher(Customer customer,string searchParam)
        {
            return customer.GetType().GetProperty(searchParam).GetValue(customer, null);
        }
        private void dgvCustomers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Ascendente) 
                OrdenarGridDescendente(e);
            else 
                OrdenarGridAscendente(e); 
            Ascendente = !Ascendente;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string pattern = txtSearch.Text.ToLower();
            Buscar = true;

            if (pattern.Length != 0)
            {
                lblPageNum.Text = "1";
                acum = 1;
                btn1.Text = Convert.ToString(acum);
                btn2.Text = Convert.ToString(acum + 1);
                btn3.Text = Convert.ToString(acum + 2);
                btn4.Text = Convert.ToString(acum + 3);
                btnprimero.Enabled = false;
                btnantes.Enabled = false;
            }
                
            var filtrado = GlobalCustomers.Where(i => i.Deleted != true && i.Name.ToLower().StartsWith(pattern) || i.Code.ToString().ToLower().StartsWith(pattern)).ToList();
            CustomersFiltrados = filtrado;

            botones(acum + 1, btn2, CustomersFiltrados);
            botones(acum + 2, btn3, CustomersFiltrados);
            botones(acum + 3, btn4, CustomersFiltrados);

            if (btn2.Enabled == false)
            {
                btnultimo.Enabled = false;
                btnsiguiente.Enabled = false;
            }
            else
            {
                btnultimo.Enabled = true;
                btnsiguiente.Enabled = true;
            }

            RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text), CustomersFiltrados));
        }
        private void btnprimero_Click(object sender, EventArgs e)
        {
            lblPageNum.Text = "1";
            acum = 1;
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = false;
            btnantes.Enabled = false;
            btnultimo.Enabled = true;
            btnsiguiente.Enabled = true;

            SumarBotones();
        }
        private void btnantes_Click(object sender, EventArgs e)
        {
            acum -= 1;
            lblPageNum.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnultimo.Enabled = true;
            btnsiguiente.Enabled = true;
            if (acum == 1)
            {
                btnprimero.Enabled = false;
                btnantes.Enabled = false;
            }
            SumarBotones();
            if (btn2.Enabled == false)
            {
                btnultimo.Enabled = false;
                btnsiguiente.Enabled = false;
            }
            else
            {
                btnultimo.Enabled = true;
                btnsiguiente.Enabled = true;
            }
        }
        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            acum += 1;
            lblPageNum.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = true;
            btnantes.Enabled = true;

            if (!Buscar)
            {
                if (acum == LastPage(GlobalCustomers))
                {
                    btn2.Enabled = false;
                    btnultimo.Enabled = false;
                    btnsiguiente.Enabled = false;
                }
                RenderTable(Paginar(acum, GlobalCustomers));
                botones(acum + 2, btn3, GlobalCustomers);
                botones(acum + 3, btn4, GlobalCustomers);
            }         
            else 
            {
                if (acum == LastPage(CustomersFiltrados))
                {
                    btn2.Enabled = false;
                    btnultimo.Enabled = false;
                    btnsiguiente.Enabled = false;
                }
                RenderTable(Paginar(acum, CustomersFiltrados));
                botones(acum + 2, btn3, CustomersFiltrados);
                botones(acum + 3, btn4, CustomersFiltrados);   
            }

        }
        private void btn2_Click(object sender, EventArgs e)
        {
            btnsiguiente_Click(sender, e);
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            acum += 2;
            lblPageNum.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = true;
            btnantes.Enabled = true;
            SumarBotones();
            if (btn2.Enabled == false) 
            {
                btnsiguiente.Enabled = false;
                btnultimo.Enabled = false;
            }
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            acum += 3;
            lblPageNum.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = true;
            btnantes.Enabled = true;
            SumarBotones();
        }
        private int LastPage(List<Customer> customers)
        {
            var numClientes = (float) (customers.Where(i => i.Deleted != true).ToList().Count)/CustomerForPage;
            double numPaginas = Math.Ceiling(numClientes);
            if (numPaginas < numClientes)
                numPaginas++;
            return (int) numPaginas;
        }
        private void btnultimo_Click(object sender, EventArgs e)
        {
            int lastPage;
            if (!Buscar)
            {
                lastPage = LastPage(GlobalCustomers);
                RenderTable(Paginar(lastPage, GlobalCustomers));
            }
            else
            {
                lastPage = LastPage(CustomersFiltrados);
                RenderTable(Paginar(lastPage, CustomersFiltrados));
            }
            acum = lastPage; 
            lblPageNum.Text = lastPage.ToString();
            btnultimo.Enabled = false;
            btnsiguiente.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btnprimero.Enabled = true;
            btnantes.Enabled = true;
            if (!Buscar)
            {
                btn1.Text = Convert.ToString(LastPage(GlobalCustomers));
                btn2.Text = Convert.ToString(LastPage(GlobalCustomers)+1);
                btn3.Text = Convert.ToString(LastPage(GlobalCustomers)+2);
                btn4.Text = Convert.ToString(LastPage(GlobalCustomers)+3);
            }
            else
            {
                btn1.Text = Convert.ToString(LastPage(CustomersFiltrados));
                btn2.Text = Convert.ToString(LastPage(CustomersFiltrados) + 1);
                btn3.Text = Convert.ToString(LastPage(CustomersFiltrados) + 2);
                btn4.Text = Convert.ToString(LastPage(CustomersFiltrados) + 3);
            }
        }
        public void botones(int acum, Button btn, List <Customer> customers) 
        {
            int block = LastPage(customers);
            if (acum > block ) 
            {
                btn.Enabled = false;
            }
            else 
            {
                btn.Enabled = true;
            }
        }
        public void SumarBotones()
        {
            if (!Buscar)
            {
                RenderTable(Paginar(acum, GlobalCustomers));
                botones(acum + 1, btn2, GlobalCustomers);
                botones(acum + 2, btn3, GlobalCustomers);
                botones(acum + 3, btn4, GlobalCustomers);
            }
            else
            {
                RenderTable(Paginar(acum, CustomersFiltrados));
                botones(acum + 1, btn2, CustomersFiltrados);
                botones(acum + 2, btn3, CustomersFiltrados);
                botones(acum + 3, btn4, CustomersFiltrados);
            }
        }
        public void Renderizar()
        {
            if (!Buscar)
                RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text), GlobalCustomers));
            else
                RenderTable(Paginar(Convert.ToInt32(lblPageNum.Text), CustomersFiltrados));
        }
    }
}

