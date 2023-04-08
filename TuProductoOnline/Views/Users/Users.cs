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

namespace TuProductoOnline.Views.Users
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {
            RenderTable();
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            new UserModal(CreateUser).ShowDialog();
        }

        private void UsersTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = UsersTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (e.ColumnIndex == UsersTable.Columns["EditCell"].Index)
                ShowEditModal(id);
            if (e.ColumnIndex == UsersTable.Columns["DeleteCell"].Index)
                ShowDeleteModal(id);
        }

        public void ShowEditModal(string id)
        {
            User user = User.GetUserById(int.Parse(id));
            new UserModal(EditUser, user).ShowDialog();
        }

        public void ShowDeleteModal(string id)
        {
            new DeleteModal(int.Parse(id), DeleteUser).ShowDialog();
        }

        public void CreateUser(List<string> userValues)
        {
            new User(
                userValues[1],
                userValues[2],
                userValues[3],
                "member",
                userValues[4],
                userValues[5],
                userValues[6]
            );
            RenderTable();
        }

        public void EditUser(List<string> userValues)
        {
            User user = User.GetUserById(int.Parse(userValues[0]));
            List<string> values = new List<string> {
                user.Id.ToString(),
                userValues[1],
                userValues[2],
                userValues[3],
                user.Role,
                userValues[4],
                userValues[5],
                userValues[6],
                user.Deleted.ToString(),
            };
            User.UpdateUser(user.Id, values);
            RenderTable();
        }

        public void DeleteUser(int id)
        {
            User user = User.GetUserById(id);
            List<string> values = new List<string> {
                user.Id.ToString(),
                user.FirstName,
                user.LastName,
                user.Password,
                user.Role,
                user.Email,
                user.Phone,
                user.Address,
                "true",
            };
            User.UpdateUser(user.Id, values);
            RenderTable();
        }

        public void RenderTable()
        {
            UsersTable.Rows.Clear();
            UsersTable.Refresh();
            List<User> users = User.GetUsers();
            foreach (User user in users)
            {
                if (user.Deleted) continue;
                UsersTable.Rows.Add(user.Id, user.FirstName, user.LastName, user.Email, user.Phone, user.Address);
            }
        }
    }
}
