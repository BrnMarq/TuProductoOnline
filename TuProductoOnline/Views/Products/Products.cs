using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TuProductoOnline.Models;
using TuProductoOnline.Utils;
using System.IO;
using Microsoft.VisualBasic.Devices;
using TuProductoOnline.Consts;

namespace TuProductoOnline
{

    public partial class Products : Form
    {
        private List<Product> product = new List<Product>();
        public List<Product> filter = new List<Product>();
        public List<Product> Searchfilter = new List<Product>();
        int acum = 1;
        public int maxId = 0;
        public int num_page = 0;
        private bool BuscarClick = false;

        public Products()
        {
            InitializeComponent();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add add = new Add(maxId + 1);
            add.ShowDialog();
            if (add.Id != 0)
            {
                new Product(add.Alias, add.Price, add.Brand, add.Description, add.Type);
                filter = Paginar(num_page, product);
                FilterRender();
                maxId++;
            }
        }

        private void Products_Load(object sender, EventArgs e)
        {
            lblPag.Text = "1";
            num_page = Convert.ToInt32(lblPag.Text);
            // Se Habilitan o deshabilitan los botones según el rol que tenga el usuario.

            product = Product.GetProducts();
            maxId = product.Count();
            if (acum == 1)
            {
                btnprimero.Enabled = false;
                btnantes.Enabled = false;
               
            }
            filter = Paginar(Convert.ToInt32(lblPag.Text), product);
            FilterRender();

           

            User activeUser = User.ActiveUser;
            if (activeUser.Role == "Admin") return;
            btnAdd.Visible = false;
            btnExport.Visible = false;
            btnImport.Visible = false;
            dgvProducts.Location = new Point(3, 20);
            dgvProducts.Size = new Size(678, 422);
            dgvProducts.Columns["Edit"].Visible = false;
            dgvProducts.Columns["Eliminar"].Visible = false;

            

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            RenderTable();
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivo CSV|*.csv" };



            if (sfd.ShowDialog() == DialogResult.OK)
            {
                List<string> filas = new List<string>();
                List<string> cabeceras = new List<string>();

                foreach (DataGridViewColumn col in dgvProducts.Columns)
                {
                    cabeceras.Add(col.HeaderText); // Se guardan Las cabeceras.
                }
                string SEP = ";";
                filas.Add(string.Join(SEP, cabeceras.GetRange(0,6))); // Se agregan en  la primera fila el valor de las cabeceras

                foreach (DataGridViewRow fila in dgvProducts.Rows)
                {
                    List<string> celdas = new List<string>();
                    try
                    {

                        foreach (DataGridViewCell c in fila.Cells)
                            celdas.Add(c.Value.ToString()); //Se almacena  el valor de las celdas


                        filas.Add(string.Join(SEP, celdas.GetRange(0, 6))); //se agrega el valor de las celdas al resto de filas
                    }
                    catch (Exception ex)
                    {

                    }


                }
                File.WriteAllLines(sfd.FileName, filas);

            }
            filter = Paginar(Convert.ToInt32(lblPag.Text), product);
            FilterRender();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
            try
            {
                
                //Se le asignan a las variables el valor de la celda seleccionada.
                string id = dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString();
                string type = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
                string name = dgvProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
                string brand = dgvProducts.Rows[e.RowIndex].Cells[3].Value.ToString();
                string description = dgvProducts.Rows[e.RowIndex].Cells[4].Value.ToString();
                string price = dgvProducts.Rows[e.RowIndex].Cells[5].Value.ToString();

                if (dgvProducts.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    
                    ConfirmDelete confirm = new ConfirmDelete();
                    confirm.ShowDialog();
                    if (confirm.Clic == true)
                    {
                        btnRefresh.Visible = false;
                        Product pro = Product.GetProductById(int.Parse(id));
                        List<string> productValues = new List<string>
                    {
                        id,
                        pro.Name,
                        pro.Price.ToString(),
                        pro.Brand,
                        pro.Description,
                        pro.Type,
                        "true",
                        "Amount"
                    };
                        Product.UpdateProduct(int.Parse(id), productValues);
                        MessageBox.Show("Producto borrado con exito");
                        
                        // RenderTable();
                    }
                    filter = Paginar(Convert.ToInt32(lblPag.Text), product);
                    FilterRender();
                }
                if (dgvProducts.Columns[e.ColumnIndex].Name == "Edit")
                {
                    Edit edit = new Edit(id, type, name, brand, description, price);
                    edit.ShowDialog();
                    if (edit.Clic)
                    {
                        btnRefresh.Visible = false;
                        List<string> productValues = new List<string>
                    {
                        id,
                        edit.Alias,
                        edit.Price.ToString(),
                        edit.Brand,
                        edit.Description,
                        edit.Type,
                        "false",
                        "Amount"
                    };
                        Product.UpdateProduct(int.Parse(id), productValues);
                        MessageBox.Show("Producto editado con exito");                       
                        //RenderTable();
                    }
                    filter = Paginar(Convert.ToInt32(lblPag.Text), product);
                    FilterRender();
                }
                if (dgvProducts.Columns[e.ColumnIndex].Name == "Consultar")
                {
                    Consult consultar = new Consult(id, type, name, brand, description, price);
                    consultar.ShowDialog();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error en la funcionalidad de la tabla");
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivo CSV|*.csv" };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string pathCSV = ofd.FileName;
                List<List<string>> importedProducts = DbHandler.LeerCSV(pathCSV);

                importedProducts.RemoveAt(0);
                try
                {
                    foreach (List<string> iProduct in importedProducts)
                    {
                        new Product(
                            iProduct[2],
                            Convert.ToDouble(iProduct[5]),
                            iProduct[3],
                            iProduct[4],
                            iProduct[1]
                        );
                    }

                    filter = Paginar(Convert.ToInt32(lblPag.Text), product);
                    FilterRender();
                }
                catch (Exception ex) 
                { 
                    MessageBox.Show("El archivo que quiere importar no tiene el formato correcto");
                }
            }
        }

        public void RenderTable()
        {
            dgvProducts.Rows.Clear();
            dgvProducts.Refresh();
            List<Product> products = Product.GetProducts();
            foreach (Product product in products)
            {
                if (product.Deleted) continue;
                dgvProducts.Rows.Add(product.Id, product.Type, product.Name, product.Brand, product.Description, product.Price);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if ( !string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                dgvProducts.Rows.Clear();
                filter = product.Where
                    (x => (x.Name.ToLower() == txtSearch.Text.ToLower().Trim()
                    || x.Id.ToString() == txtSearch.Text
                    || x.Description.ToLower().Contains(txtSearch.Text.ToLower().Trim()) == true)
                    && x.Deleted != true).ToList();

                txtSearch.Clear();
                if (filter.Count != 0)
                {
                    btnRefresh.Visible = true;
                    lblPag.Text = "1";
                    num_page = Convert.ToInt32(lblPag.Text);
                    Searchfilter = Paginar(num_page, filter);
                    SearchFilterRender();
                }
                else
                {
                    MessageBox.Show("Lo que está buscando no se encuentra en el sistema");
                    filter = Paginar(num_page, product);
                    FilterRender();
                }
            }
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            lblPag.Text = "1";
            num_page = Convert.ToInt32(lblPag.Text);
            filter = Paginar(num_page, product);
            FilterRender();
            btnRefresh.Visible = false;
        }

        public List<Product> Paginar(int num, List<Product> producto) 
        { 
            var paginado = producto.Where(i => i.Deleted != true).Skip((num - 1) * 2).Take(2).ToList();
            return paginado;
        }

        public void FilterRender() 
        {
            dgvProducts.Rows.Clear();
            foreach (Product f in filter)
            {
                int a = dgvProducts.Rows.Add();
                DataGridViewRow row = dgvProducts.Rows[a];
                row.Cells[0].Value = f.Id;
                row.Cells[1].Value = f.Type;
                row.Cells[2].Value = f.Name;
                row.Cells[3].Value = f.Brand;
                row.Cells[4].Value = f.Description;
                row.Cells[5].Value = f.Price;
            }
        }

        public void SearchFilterRender() 
        {
            dgvProducts.Rows.Clear();
            foreach (Product f in Searchfilter)
            {
                int a = dgvProducts.Rows.Add();
                DataGridViewRow row = dgvProducts.Rows[a];
                row.Cells[0].Value = f.Id;
                row.Cells[1].Value = f.Type;
                row.Cells[2].Value = f.Name;
                row.Cells[3].Value = f.Brand;
                row.Cells[4].Value = f.Description;
                row.Cells[5].Value = f.Price;
            }
        }

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            acum += 1;
            lblPag.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = true;
            btnantes.Enabled = true;
            if (!BuscarClick)
                filter = Paginar(acum, product);
                FilterRender();
        }

        private void btnprimero_Click(object sender, EventArgs e)
        {
            lblPag.Text = "1";
            acum = 1;
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = false;
            btnantes.Enabled = false;
            if (!BuscarClick)
                filter = Paginar(acum, product);
                FilterRender();
        }

        private void btnantes_Click(object sender, EventArgs e)
        {
            acum -= 1;
            lblPag.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            if (acum == 1)
            {
                btnprimero.Enabled = false;
                btnantes.Enabled = false;
            }
            if (!BuscarClick)
                filter = Paginar(acum, product);
                 FilterRender();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btnsiguiente_Click(sender, e);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            acum += 2;
            lblPag.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = true;
            btnantes.Enabled = true;
            if (!BuscarClick)
                filter = Paginar(acum, product);
                FilterRender();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            acum += 3;
            lblPag.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = true;
            btnantes.Enabled = true;
            if (!BuscarClick)
                filter = Paginar(acum, product);
                FilterRender();
        }
    }
}


