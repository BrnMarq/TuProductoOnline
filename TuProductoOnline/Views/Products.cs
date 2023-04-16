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
                new Product(add.Alias, add.Price, add.Brand, add.Description, add.Type) { Amount = "Amount" };
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


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                List<string> filas = new List<string>();
                List<string> cabeceras = new List<string>();

                foreach (DataGridViewColumn col in dgvProducts.Columns)
                {
                    cabeceras.Add(col.HeaderText);
                }
                string SEP = ";";
                filas.Add(string.Join(SEP, cabeceras.GetRange(0, 6)));

                foreach (DataGridViewRow fila in dgvProducts.Rows)
                {
                    List<string> celdas = new List<string>();
                    try
                    {

                        foreach (DataGridViewCell c in fila.Cells)
                            celdas.Add(c.Value.ToString());


                        filas.Add(string.Join(SEP, celdas.GetRange(0, 6)));
                    }
                    catch (Exception ex)
                    {

                    }


                }
                File.WriteAllLines(sfd.FileName, filas);
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
                        "true",
                        "Amount"
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
                        "false",
                        "Amount"
                    };
                    Product.UpdateProduct(int.Parse(id), productValues);
                    RenderTable();
                }

            }
            if (dgvProducts.Columns[e.ColumnIndex].Name == "Consultar") 
            {
                Consult consult = new Consult(id, type, name, brand, description, price);
                consult.ShowDialog();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivo CSV|*.csv" };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string SEP = ";";

                string[] lineas = File.ReadAllLines(ofd.FileName);
                string[] cabeceras = lineas[0].Split(new[] { SEP }, StringSplitOptions.None);


                for (int i = 1; i < lineas.Length; i++)
                {
                    string[] celdas = lineas[i].Split(new[] { SEP }, StringSplitOptions.None);
                    dgvProducts.Rows.Add(celdas);
                    Product pro = new Product();
                    pro.Type = celdas[1];
                    pro.Name = celdas[2];
                    pro.Brand = celdas[3];
                    pro.Description = celdas[4];
                    pro.Price = Convert.ToDouble(celdas[5]);
                    product.Add(new Product(pro.Name, pro.Price, pro.Brand, pro.Description, pro.Type));
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
    }
}


