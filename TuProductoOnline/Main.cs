using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProductoOnline.Views;
using TuProductoOnline.Utils;
using TuProductoOnline.Consts;
using TuProductoOnline.Models;

namespace TuProductoOnline
{
    public partial class Main : Form
    {
        
        
        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Container.Controls.Add(childForm);
            Container.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomersTab_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Customers());
        }

        private void UsersTab_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Users());
        }

        private void ProductsTab_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Products());
        }
    }
}
