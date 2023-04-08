using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProductoOnline.Models;

namespace TuProductoOnline.Views
{
    public partial class Users : Form
    {
        AddUsers miVentana = new AddUsers();
        public Users()
        {
            InitializeComponent();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {
            List<User> users = User.GetUsers();
            foreach (User user in users)
            {
                UsersTable.Rows.Add(user.Id, user.FirstName, user.LastName, user.Email, user.Phone, user.Address);
            }
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            miVentana.ShowDialog();
        }

        private void UsersTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == UsersTable.Columns["EditCell"].Index)
            {
                EditUser(UsersTable.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        public void EditUser(string id)
        {

        }
    }
}
