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
        int acum = 1;
        Computer myComputer = new Computer();
        private readonly List<User> GlobalUsers = User.GetUsers();
        private bool BuscarClick = false;

        public Users()
        {
            InitializeComponent();
        }
        private void Users_Load(object sender, EventArgs e)
        {
            if(acum == 1) 
            {
                btnprimero.Enabled = false;
                btnantes.Enabled = false;
            }
            RenderTable(Paginar(Convert.ToInt32(lblPag.Text), GlobalUsers));

        }
        private List<User> Paginar(int num, List<User> users)
        {
            var lista = users.Where(i => i.Deleted != true).Skip((num - 1) * 25).Take(25).ToList();

            return lista;
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
            RenderTable(Paginar(Convert.ToInt32(lblPag.Text), GlobalUsers));
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
            RenderTable(Paginar(Convert.ToInt32(lblPag.Text), GlobalUsers));
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
            RenderTable(Paginar(Convert.ToInt32(lblPag.Text), GlobalUsers));
        }

        public void RenderTable(List<User>users)
        {
            UsersTable.Rows.Clear();
            UsersTable.Refresh();
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
                    if (!BuscarClick) 
                    {
                        RenderTable(Paginar(Convert.ToInt32(lblPag.Text), GlobalUsers));
                    }

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

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            acum += 1;
            lblPag.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = true;
            btnantes.Enabled = true;
            if (!BuscarClick)
                RenderTable(Paginar(acum, GlobalUsers));

        }

        private void btnprimero_Click(object sender, EventArgs e)
        {
            lblPag.Text = "1";
            acum = 1;
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = false;
            btnantes.Enabled = false;
            if (!BuscarClick)
                RenderTable(Paginar(acum, GlobalUsers));
        }

        private void btnantes_Click(object sender, EventArgs e)
        {
            acum -= 1;
            lblPag.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            if (acum == 1) 
            {
                btnprimero.Enabled = false;
                btnantes.Enabled = false;
            }
            if (!BuscarClick)
                RenderTable(Paginar(acum, GlobalUsers));
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btnsiguiente_Click(sender, e);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            acum += 2;
            lblPag.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = true;
            btnantes.Enabled = true;
            if (!BuscarClick)
                RenderTable(Paginar(acum, GlobalUsers));
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            acum += 3;
            lblPag.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = true;
            btnantes.Enabled = true;
            if (!BuscarClick)
                RenderTable(Paginar(acum, GlobalUsers));
        }
    }
}
