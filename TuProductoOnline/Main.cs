using System;
using System.Windows.Forms;
using TuProductoOnline.Views;
using TuProductoOnline.Views.Users;
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
            customizeDesign();
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
            OpenChildForm(new CustomersView());
        }

        private void UsersTab_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Users());
        }

        private void ProductsTab_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Products());
        }

        private void BillingTab_Click(object sender, EventArgs e)
        {
            showSubMenu();
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Facturacion());
            hideSubMenu();
        }

        private void btnRegistros_Click(object sender, EventArgs e)
        {
            //...
            //tu código
            //...
            hideSubMenu();
        }

        private void customizeDesign()
        {
            panelSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelSubMenu.Visible == true)
                panelSubMenu.Visible = false;
        }

        private void showSubMenu()
        {
            if (panelSubMenu.Visible == false)
            {
                panelSubMenu.Visible = true;
            }
            else
            {
                panelSubMenu.Visible = false;
            }

        }
    }
}
