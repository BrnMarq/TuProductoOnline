using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProductoOnline.Models;
using TuProductoOnline.Utils;
using Microsoft.VisualBasic.Devices;
using TuProductoOnline.Consts;
using TuProductoOnline.Views.Customers;
using System.IO;

namespace TuProductoOnline
{

    public partial class Products : Form
    {
        public List<Product> product = new List<Product>();
        public int maxId = 0;

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
                RenderTable();
                maxId++;
            }
        }

        private void Products_Load(object sender, EventArgs e)
        {
            product = Product.GetProducts();
            maxId = product.Count();
            RenderTable();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivo CSV|*.csv" };
            //saveProducts.FileName = "Productos.csv";
            //string origen = @"" + FileNames.Products;
            //if (saveProducts.ShowDialog() == DialogResult.OK)
            //{
            //    myComputer.FileSystem.CopyFile(origen, saveProducts.FileName);

            //}


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                List<string> filas = new List<string>();
                List<string> cabeceras = new List<string>();

                foreach (DataGridViewColumn col in dgvProducts.Columns)
                {
                    cabeceras.Add(col.HeaderText);
                }
                string SEP = ",";
                filas.Add(string.Join(SEP, cabeceras));

                foreach (DataGridViewRow fila in dgvProducts.Rows)
                {
                    List<string> celdas = new List<string>();
                    try
                    {

                        foreach (DataGridViewCell c in fila.Cells)
                            celdas.Add(c.Value.ToString());


                        filas.Add(string.Join(SEP, celdas));
                    }
                    catch (Exception ex)
                    {

                    }


                }
                File.WriteAllLines(sfd.FileName, filas);

            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
                        "true"
                    };
                    Product.UpdateProduct(int.Parse(id), productValues);
                    RenderTable();
                }

            }
            if (dgvProducts.Columns[e.ColumnIndex].Name == "Edit")
            {
                Edit edit = new Edit(id, type, name, brand, description, price);
                edit.ShowDialog();
                if (edit.Clic != true)
                {
                    List<string> productValues = new List<string>
                    {
                        id,
                        edit.Alias,
                        edit.Price.ToString(),
                        edit.Brand,
                        edit.Description,
                        edit.Type,
                        "false"
                    };
                    Product.UpdateProduct(int.Parse(id), productValues);
                    RenderTable();
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivo CSV|*.csv" };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string pathCSV = ofd.FileName;
                List<List<string>> importedProducts = DbHandler.LeerCSV(pathCSV);

                foreach (List<string> iProduct in importedProducts)
                {
                    new Product(
                        iProduct[1],
                        Convert.ToDouble(iProduct[2]),
                        iProduct[3],
                        iProduct[4],
                        iProduct[5]
                    );
                }
                RenderTable();
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
    }
}


