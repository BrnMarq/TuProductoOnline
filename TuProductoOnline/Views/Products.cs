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
        int index;


        public Products()
        {
            InitializeComponent();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            index = product.Count();
            Add add = new Add(index+1);
            add.ShowDialog();
            if (add.Id != 0) 
            {
                product.Add(new Product(add.Alias, add.Price, add.Brand, add.Description, add.Type, add.Id));
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
            //Delete delete = new Delete();
            //ConfirmDelete confirm = new ConfirmDelete();
            //delete.ShowDialog();
            //for (int i = 0; i < product.Count; i++)
            //{
            //    if (delete.Id == product[i].Id) 
            //    {
                    
                
            //    }
            //}
        }
    }

}


