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
    public partial class Add : Form
    {
        private string _name;
        private string _brand;
        private string _description;
        private double _price;
        private string _type;
        private int _id;

        public string Alias { get { return _name; } set { _name = value; } }
        public string Brand { get { return _brand; } set { _brand = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public double Price { get { return _price; } set { _price = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public int Id { get { return _id; } set { _id = value; } }
        public Add(int index)
        {
            InitializeComponent();
            txtId.Text = index.ToString();
            
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Alias = txtName.Text;
            Brand = txtBrand.Text;
            Description = txtDescription.Text;
            Type = cmbType.Text;
            Price = Convert.ToDouble(txtPrice.Text);
            Id = Convert.ToInt32(txtId.Text);
            this.Close();
        }

        private void cmbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
