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
        Computer myComputer = new Computer();
        public List<Product> product = new List<Product>();
        public List<int> Ids = new List<int>();


        public Products()
        {
            InitializeComponent();

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

            Add add = new Add(Ids.Count + 1);
            add.ShowDialog();
            if (add.Id != 0)
            {
                product.Add(new Product(add.Alias, add.Price, add.Brand, add.Description, add.Type, add.Id));
                Ids.Add(add.Id);
                int rowIndex = dgvProducts.Rows.Add();
                DataGridViewRow row = dgvProducts.Rows[rowIndex];
                row.Cells[0].Value = add.Id;
                row.Cells[1].Value = add.Type;
                row.Cells[2].Value = add.Alias;
                row.Cells[3].Value = add.Brand;
                row.Cells[4].Value = add.Description;
                row.Cells[5].Value = add.Price;


            }

        }




        private void Products_Load(object sender, EventArgs e)
        {

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

                    for (int i = 0; i < product.Count; i++)
                    {
                        if (product[i].Id.ToString() == id)
                        {
                            product.RemoveAt(i);
                        }
                    }
                    dgvProducts.Rows.Clear();
                    foreach (Product p in product)
                    {
                        int rowIndex = dgvProducts.Rows.Add();
                        DataGridViewRow row = dgvProducts.Rows[rowIndex];
                        row.Cells[0].Value = p.Id;
                        row.Cells[1].Value = p.Type;
                        row.Cells[2].Value = p.Name;
                        row.Cells[3].Value = p.Brand;
                        row.Cells[4].Value = p.Description;
                        row.Cells[5].Value = p.Price;
                    }
                }

            }
            if (dgvProducts.Columns[e.ColumnIndex].Name == "Edit")
            {
                Edit edit = new Edit(id, type, name, brand, description, price);
                edit.ShowDialog();
                if (edit.Clic != true)
                {
                    for (int i = 0; i < product.Count; i++)
                    {
                        if (product[i].Id.ToString() == id)
                        {
                            product[i].Name = edit.Alias;
                            product[i].Price = Convert.ToDouble(edit.Price);
                            product[i].Brand = edit.Brand;
                            product[i].Description = edit.Description;
                            product[i].Type = edit.Type;
                            product[i].Id = edit.Id;
                        }
                    }
                    dgvProducts.Rows.Clear();
                    foreach (Product p in product)
                    {
                        int rowIndex = dgvProducts.Rows.Add();
                        DataGridViewRow row = dgvProducts.Rows[rowIndex];
                        row.Cells[0].Value = p.Id;
                        row.Cells[1].Value = p.Type;
                        row.Cells[2].Value = p.Name;
                        row.Cells[3].Value = p.Brand;
                        row.Cells[4].Value = p.Description;
                        row.Cells[5].Value = p.Price;
                    }
                }

            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivo CSV|*.csv" };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string SEP = ",";

                string[] lineas = File.ReadAllLines(ofd.FileName);
                string[] cabeceras = lineas[0].Split(new[] { SEP }, StringSplitOptions.None);

                dgvProducts.Columns.Clear();
                foreach (string c in cabeceras)
                {
                    dgvProducts.Columns.Add(c, c);
                }

                for (int i = 0; i < lineas.Length; i++)
                {
                    string[] celdas = lineas[i].Split(new[] { SEP }, StringSplitOptions.None);
                    dgvProducts.Rows.Add(celdas);
                }
            }
        }
    }
}


