using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuProductoOnline
{

    public partial class Products : Form
    {

        public List<Product> product = new List<Product>();
        public List<int> Ids = new List<int>();


        public Products()
        {
            InitializeComponent();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            Add add = new Add(Ids.Count+1);
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
           
            delete.ShowDialog();
            for (int i = 0; i < product.Count; i++)
            {
                if (delete.Id == product[i].Id)
                {
                    ConfirmDelete confirm = new ConfirmDelete(product[i].Name);
                    confirm.ShowDialog();
                    if (confirm.Clic == true)
                    {
                        product.RemoveAt(i);
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
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit_Id_Verification edit_verificacion = new Edit_Id_Verification();
            
            edit_verificacion.ShowDialog();

            for (int i = 0; i < product.Count; i++)
            {
                if (edit_verificacion.Id == product[i].Id) 
                {
                    Edit edit = new Edit(product[i].Id);
                    edit.ShowDialog();

                    product[i].Name = edit.Alias;
                    product[i].Price = edit.Price;
                    product[i].Brand = edit.Brand;
                    product[i].Description = edit.Description;
                    product[i].Type = edit.Type;
                    product[i].Id = edit.Id;

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

                    break;

                }
            }
        }

        private void Products_Load(object sender, EventArgs e)
        {

        }
    }

}


