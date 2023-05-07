using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TuProductoOnline.Models;
using TuProductoOnline.Utils;
using System.IO;

namespace TuProductoOnline
{

    public partial class Products : Form
    {
        int acum = 1;
        private List<Product> GlobalProducts = Product.GetProducts();
        private List<Product> ProductsFiltrados;
        public int maxId = 0;
        public int num_page = 0;
        private int ProductsForPage = 25;
        private List<Product> Ordenado;
        private bool Buscar = false;
        private bool Ascendente = true;
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
                RenderTable(Paginar(num_page, ProductsFiltrados));
                maxId++;
            }
        }
        private void Products_Load(object sender, EventArgs e)
        {
            VerifyButtons();
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
            txtSearch.Clear();
            RenderTable(GlobalProducts);
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
                MessageBox.Show("¡Productos Exportados con exito!");
            }
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
                    }
                    if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
                    {
                        RenderTable(Paginar(acum, GlobalProducts));
                    }
                    else
                    {
                        RenderTable(Paginar(Convert.ToInt32(lblPag.Text), ProductsFiltrados));
                    }
                }
                if (dgvProducts.Columns[e.ColumnIndex].Name == "Edit")
                {
                    Edit edit = new Edit(id, type, name, brand, description, price);
                    edit.ShowDialog();
                    if (edit.Clic)
                    {
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
                        txtSearch.Clear();
                    }
                    if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
                    {
                        RenderTable(Paginar(acum, GlobalProducts));
                    }
                    else
                    {
                        RenderTable(Paginar(Convert.ToInt32(lblPag.Text), ProductsFiltrados));
                    }
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
            txtSearch.Clear();
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
                    MessageBox.Show("¡Archivo importado con exito!");
                    VerifyButtons();
                }
                catch (Exception ex) 
                { 
                    MessageBox.Show("El archivo que quiere importar no tiene el formato correcto");
                }
            }
        }
        public void RenderTable(List<Product>products)
        {
            dgvProducts.Rows.Clear();
            dgvProducts.Refresh();
            foreach (Product product in products)
            {
                if (product.Deleted) continue;
                dgvProducts.Rows.Add(product.Id, product.Type, product.Name, product.Brand, product.Description, product.Price);
            }
        }
        public List<Product> Paginar(int num, List<Product> producto) 
        { 
            var paginado = producto.Where(i => i.Deleted != true).Skip((num - 1) * ProductsForPage).Take(ProductsForPage).ToList();
            return paginado;
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
            if (!Buscar)
            {
                if (acum == LastPage(GlobalProducts))
                {
                    btn2.Enabled = false;
                    btnultimo.Enabled = false;
                    btnsiguiente.Enabled = false;
                }
                RenderTable(Paginar(acum, GlobalProducts));
                botones(acum + 2, btn3, GlobalProducts);
                botones(acum + 3, btn4, GlobalProducts);
            }
            else
            {
                if (acum == LastPage(ProductsFiltrados))
                {
                    btn2.Enabled = false;
                    btnultimo.Enabled = false;
                    btnsiguiente.Enabled = false;
                }
                RenderTable(Paginar(acum, ProductsFiltrados));
                botones(acum + 2, btn3, ProductsFiltrados);
                botones(acum + 3, btn4, ProductsFiltrados);
            }
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
            btnultimo.Enabled = true;
            btnsiguiente.Enabled = true;
            SumarBotones();
        }
        private void btnantes_Click(object sender, EventArgs e)
        {
            acum -= 1;
            lblPag.Text = Convert.ToString(acum);
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
            lblPag.Text = Convert.ToString(acum);
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
            else 
            {
                btnsiguiente.Enabled = true;
                btnultimo.Enabled = true;
            }

        }
        private void btnultimo_Click(object sender, EventArgs e)
        {
            int lastPage;
            if (!Buscar)
            {
                lastPage = LastPage(GlobalProducts);
                RenderTable(Paginar(lastPage, GlobalProducts));
            }
            else
            {
                lastPage = LastPage(ProductsFiltrados);
                RenderTable(Paginar(lastPage, ProductsFiltrados));
            }
            acum = lastPage;
            lblPag.Text = lastPage.ToString();
            btnultimo.Enabled = false;
            btnsiguiente.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btnprimero.Enabled = true;
            btnantes.Enabled = true;
            if (!Buscar)
            {
                btn1.Text = Convert.ToString(LastPage(GlobalProducts));
                btn2.Text = Convert.ToString(LastPage(GlobalProducts) + 1);
                btn3.Text = Convert.ToString(LastPage(GlobalProducts) + 2);
                btn4.Text = Convert.ToString(LastPage(GlobalProducts) + 3);
            }
            else
            {
                btn1.Text = Convert.ToString(LastPage(ProductsFiltrados));
                btn2.Text = Convert.ToString(LastPage(ProductsFiltrados) + 1);
                btn3.Text = Convert.ToString(LastPage(ProductsFiltrados) + 2);
                btn4.Text = Convert.ToString(LastPage(ProductsFiltrados) + 3);
            }
        }
        public void VerifyButtons()
        {
            int lastPage;
            if (acum == 1)
            {
                btnprimero.Enabled = false;
                btnantes.Enabled = false;
            }
            if (!Buscar)
            {
                botones(acum + 1, btn2, GlobalProducts);
                botones(acum + 2, btn3, GlobalProducts);
                botones(acum + 3, btn4, GlobalProducts);
                lastPage = LastPage(GlobalProducts);
                RenderTable(Paginar(acum, GlobalProducts));
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
                botones(acum + 1, btn2, ProductsFiltrados);
                botones(acum + 2, btn3, ProductsFiltrados);
                botones(acum + 3, btn4, ProductsFiltrados);
                lastPage = LastPage(ProductsFiltrados);
                RenderTable(Paginar(acum, ProductsFiltrados));
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
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string pattern = txtSearch.Text.ToLower();
            Buscar = true;
            if (pattern.Length != 0)
            {
                lblPag.Text = "1";
                acum = 1;
                btn1.Text = Convert.ToString(acum);
                btn2.Text = Convert.ToString(acum + 1);
                btn3.Text = Convert.ToString(acum + 2);
                btn4.Text = Convert.ToString(acum + 3);
                btnprimero.Enabled = false;
                btnantes.Enabled = false;
            }
            var filtrado = GlobalProducts.Where(i => i.Deleted != true && i.Name.ToLower().StartsWith(pattern) || i.Id.ToString().ToLower().Contains(pattern)).ToList();
            ProductsFiltrados = filtrado;
            botones(acum + 1, btn2, ProductsFiltrados);
            botones(acum + 2, btn3, ProductsFiltrados);
            botones(acum + 3, btn4, ProductsFiltrados);
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
            RenderTable(Paginar(Convert.ToInt32(lblPag.Text), ProductsFiltrados));
        }
        public void OrdenarGridAscendente(DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex == 1 || e.ColumnIndex > 5) return;

            List<string> searchParams = new List<string> { "GridCode", "GridName", "GridModel", "GridDescription", "GridPrice" };
            string searchParam = searchParams[e.ColumnIndex];
            int pageNum = Convert.ToInt32(lblPag.Text);
            List<Product> paginated = Paginar(pageNum, GlobalProducts);
            Ordenado = paginated.OrderBy(l => Searcher(l, searchParam)).ToList();
            RenderTable(Ordenado);
        }
        public void OrdenarGridDescendente(DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex ==1 || e.ColumnIndex > 5) return;
            List<string> searchParams = new List<string> { "GridCode", "GridName", "GridModel", "GridDescription", "GridPrice" };
            string searchParam = searchParams[e.ColumnIndex];
            int pageNum = Convert.ToInt32(lblPag.Text);
            List<Product> paginated = Paginar(pageNum, GlobalProducts);
            Ordenado = paginated.OrderByDescending(l => Searcher(l, searchParam)).ToList();
            RenderTable(Ordenado);
        }
        public object Searcher(Product product, string searchParam)
        {
            return product.GetType().GetProperty(searchParam).GetValue(product, null);
        }
        private void dgvCustomers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Ascendente)
                OrdenarGridDescendente(e);
            else
                OrdenarGridAscendente(e);
            Ascendente = !Ascendente;
        }
        public void botones(int acum, Button btn, List<Product> products)
        {
            int block = LastPage(products);
            if (acum > block)
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
                RenderTable(Paginar(acum, GlobalProducts));
                botones(acum + 1, btn2, GlobalProducts);
                botones(acum + 2, btn3, GlobalProducts);
                botones(acum + 3, btn4, GlobalProducts);
            }
            else
            {
                RenderTable(Paginar(acum, ProductsFiltrados));
                botones(acum + 1, btn2, ProductsFiltrados);
                botones(acum + 2, btn3, ProductsFiltrados);
                botones(acum + 3, btn4, ProductsFiltrados);
            }
        }
        private int LastPage(List<Product> products)
        {
            var numUsuario = (float)(products.Where(i => i.Deleted != true).ToList().Count) / ProductsForPage;
            double numPaginas = Math.Ceiling(numUsuario);
            if (numPaginas < numUsuario)
                numPaginas++;
            return (int)numPaginas;
        }
    }
}