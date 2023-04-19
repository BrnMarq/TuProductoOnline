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

namespace TuProductoOnline.Views.Users
{
    public partial class Users : Form
    {
        Computer myComputer = new Computer();

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
            try
            {
                string id = UsersTable.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (e.ColumnIndex == UsersTable.Columns["EditCell"].Index)
                    ShowEditModal(id);
                if (e.ColumnIndex == UsersTable.Columns["DeleteCell"].Index)
                    ShowDeleteModal(id);
            } catch 
            {
            }
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
            MessageBox.Show("Usuario editado con exito");
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
            MessageBox.Show("Usuario Borrado con exito");
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

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                string pathCSV = openFileDialog2.FileName;
                List<List<string>> usuariosImportados = DbHandler.LeerCSV(pathCSV);

                try
                {
                    foreach (List<string> user in usuariosImportados)
                    {
                        if (bool.Parse(user[8])) continue;
                        new User(
                            user[1].ToString(),
                            user[2].ToString(),
                            user[3].ToString(),
                            user[4].ToString(),
                            user[5].ToString(),
                            user[6].ToString(),
                            user[7].ToString()
                            );
                    }
                    RenderTable();
                } catch (Exception)
                {
                    MessageBox.Show("El archivo que quiere importar no tiene el formato correcto");
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún archivo");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveUsers= new SaveFileDialog();

            saveUsers.FileName = "Usuarios.csv";
            string origen = @"" + FileNames.Users;

            if (saveUsers.ShowDialog() == DialogResult.OK)
                myComputer.FileSystem.CopyFile(origen, saveUsers.FileName);
        }
    }
}
