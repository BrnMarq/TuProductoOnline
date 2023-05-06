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
        private List<User> UsersFiltrados;
        private bool Buscar = false;
        private int UserForPage = 25;
        private List<User> Ordenado;
        private bool Ascendente = true;

        public Users()
        {
            InitializeComponent();
        }
        private void Users_Load(object sender, EventArgs e)
        {
            int lastPage;
            if(acum == 1) 
            {
                btnprimero.Enabled = false;
                btnantes.Enabled = false;
            }
            if (!Buscar)
            {
                botones(acum + 1, btn2, GlobalUsers);
                botones(acum + 2, btn3, GlobalUsers);
                botones(acum + 3, btn4, GlobalUsers);
                lastPage = LastPage(GlobalUsers);
                RenderTable(Paginar(acum, GlobalUsers));
                if (btn2.Enabled == false)
                {
                    btnultimo.Enabled = false;
                    btnsiguiente.Enabled = false;
                }
                else
                {
                    btnultimo.Enabled = true;
                    btnsiguiente.Enabled = true;
                }
            }
            else
            {
                botones(acum + 1, btn2, UsersFiltrados);
                botones(acum + 2, btn3, UsersFiltrados);
                botones(acum + 3, btn4, UsersFiltrados);
                lastPage = LastPage(UsersFiltrados);
                RenderTable(Paginar(acum, UsersFiltrados));
                if (btn2.Enabled == false)
                {
                    btnultimo.Enabled = false;
                    btnsiguiente.Enabled = false;
                }
                else
                {
                    btnultimo.Enabled = true;
                    btnsiguiente.Enabled = true;
                }
            }

        }
        private List<User> Paginar(int num, List<User> users)
        {
            var lista = users.Where(i => i.Deleted != true).Skip((num - 1) * UserForPage).Take(UserForPage).ToList();

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
            } 
            catch (ArgumentOutOfRangeException)
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
                    if (!Buscar) 
                    {
                        RenderTable(Paginar(Convert.ToInt32(lblPag.Text), GlobalUsers));
                    }
                    else 
                    {
                    RenderTable(Paginar(Convert.ToInt32(lblPag.Text), UsersFiltrados));

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
            SaveFileDialog saveUser = new SaveFileDialog();
            saveUser.FileName = "Usuarios";
            string origen = @"" + FileNames.Users;

            try
            {
                if (saveUser.ShowDialog() == DialogResult.OK)
                {
                    myComputer.FileSystem.CopyFile(origen, saveUser.FileName + ".csv");
                    MessageBox.Show("Usuarios exportados con éxito");
                }
            }
            catch (Exception)
            {
                DialogResult replace = MessageBox.Show("Ya existe un archivo con este nombre. ¿Desea reemplazarlo?", "Reemplazar", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (replace == DialogResult.OK)
                {
                    myComputer.FileSystem.DeleteFile(saveUser.FileName + ".csv");
                    myComputer.FileSystem.CopyFile(origen, saveUser.FileName + ".csv");
                    MessageBox.Show("Usuarios exportados con éxito");
                }
            }
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
            if (!Buscar)
            {
                if (acum == LastPage(GlobalUsers))
                {
                    btn2.Enabled = false;
                    btnultimo.Enabled = false;
                    btnsiguiente.Enabled = false;
                }
                RenderTable(Paginar(acum, GlobalUsers));
                botones(acum + 2, btn3, GlobalUsers);
                botones(acum + 3, btn4, GlobalUsers);
            }
            else
            {
                if (acum == LastPage(UsersFiltrados))
                {
                    btn2.Enabled = false;
                    btnultimo.Enabled = false;
                    btnsiguiente.Enabled = false;
                }
                RenderTable(Paginar(acum, UsersFiltrados));
                botones(acum + 2, btn3, UsersFiltrados);
                botones(acum + 3, btn4, UsersFiltrados);
            }

        }
        private void btnprimero_Click(object sender, EventArgs e)
        {
            lblPag.Text = "1";
            acum = 1;
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btnprimero.Enabled = false;
            btnantes.Enabled = false;
            btnultimo.Enabled = true;
            btnsiguiente.Enabled = true;
            if (!Buscar) 
            {
                botones(acum + 1, btn2, GlobalUsers);
                botones(acum + 2, btn3, GlobalUsers);
                botones(acum + 3, btn4, GlobalUsers);
                RenderTable(Paginar(acum, GlobalUsers));   
            }
            else 
            {
                botones(acum + 1, btn2, UsersFiltrados);
                botones(acum + 2, btn3, UsersFiltrados);
                botones(acum + 3, btn4, UsersFiltrados);
                RenderTable(Paginar(acum, UsersFiltrados));
            
            }
        }
        private void btnantes_Click(object sender, EventArgs e)
        {
            acum -= 1;
            lblPag.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnultimo.Enabled = true;
            btnsiguiente.Enabled = true;
            if (acum == 1) 
            {
                btnprimero.Enabled = false;
                btnantes.Enabled = false;
            }
            if (!Buscar)
            {
                RenderTable(Paginar(acum, GlobalUsers));
                botones(acum + 1, btn2, GlobalUsers);
                botones(acum + 2, btn3, GlobalUsers);
                botones(acum + 3, btn4, GlobalUsers);
            }
            else
            {
                RenderTable(Paginar(acum, UsersFiltrados));
                botones(acum + 1, btn2, UsersFiltrados);
                botones(acum + 2, btn3, UsersFiltrados);
                botones(acum + 3, btn4, UsersFiltrados);
            }
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
            if (!Buscar)
            {
                RenderTable(Paginar(acum, GlobalUsers));
                botones(acum + 1, btn2, GlobalUsers);
                botones(acum + 2, btn3, GlobalUsers);
                botones(acum + 3, btn4, GlobalUsers);
            }
            else
            {
                RenderTable(Paginar(acum, UsersFiltrados));
                botones(acum + 1, btn2, UsersFiltrados);
                botones(acum + 2, btn3, UsersFiltrados);
                botones(acum + 3, btn4, UsersFiltrados);
            }
            if (btn2.Enabled == false)
            {
                btnsiguiente.Enabled = false;
                btnultimo.Enabled = false;
            }
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
            if (!Buscar)
            {
                RenderTable(Paginar(acum, GlobalUsers));
                botones(acum + 1, btn2, GlobalUsers);
                botones(acum + 2, btn3, GlobalUsers);
                botones(acum + 3, btn4, GlobalUsers);
            }
            else
            {
                RenderTable(Paginar(acum, UsersFiltrados));
                botones(acum + 1, btn2, UsersFiltrados);
                botones(acum + 2, btn3, UsersFiltrados);
                botones(acum + 3, btn4, UsersFiltrados);
            }
        }
        private int LastPage(List<User> users)
        {
            var numUsuario= (float)(users.Where(i => i.Deleted != true).ToList().Count) / UserForPage;
            double numPaginas = Math.Ceiling(numUsuario);
            if (numPaginas < numUsuario)
                numPaginas++;

            return (int)numPaginas;
        }
        private void btnultimo_Click(object sender, EventArgs e)
        {
            int lastPage;
            if (!Buscar) 
            {
                lastPage = LastPage(GlobalUsers);
                RenderTable(Paginar(lastPage, GlobalUsers));
            }
            else 
            { 
                lastPage = LastPage(UsersFiltrados);
                RenderTable(Paginar(lastPage, UsersFiltrados));
            }
            acum = lastPage;
            lblPag.Text = lastPage.ToString();
            btnultimo.Enabled = false;
            btnsiguiente.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btnprimero.Enabled = true;
            btnantes.Enabled = true;
            if (!Buscar)
            {
                btn1.Text = Convert.ToString(LastPage(GlobalUsers));
                btn2.Text = Convert.ToString(LastPage(GlobalUsers) + 1);
                btn3.Text = Convert.ToString(LastPage(GlobalUsers) + 2);
                btn4.Text = Convert.ToString(LastPage(GlobalUsers) + 3);
            }
            else
            {
                btn1.Text = Convert.ToString(LastPage(UsersFiltrados));
                btn2.Text = Convert.ToString(LastPage(UsersFiltrados) + 1);
                btn3.Text = Convert.ToString(LastPage(UsersFiltrados) + 2);
                btn4.Text = Convert.ToString(LastPage(UsersFiltrados) + 3);
            }
        }
        public void botones(int acum, Button btn, List<User> users)
        {
            int block = LastPage(users);
            if (acum > block)
            {
                btn.Enabled = false;
            }
            else
            {
                btn.Enabled = true;
            }
        }
        public object Searcher(User users, string searchParam)
        {
            return users.GetType().GetProperty(searchParam).GetValue(users, null);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string pattern = txtSearch.Text.ToLower();
            Buscar = true;

            if (pattern.Length != 0)
            {
                lblPag.Text = "1";
                acum = 1;
                btn1.Text = Convert.ToString(acum);
                btn2.Text = Convert.ToString(acum + 1);
                btn3.Text = Convert.ToString(acum + 2);
                btn4.Text = Convert.ToString(acum + 3);
                btnprimero.Enabled = false;
                btnantes.Enabled = false;
            }

            var filtrado = GlobalUsers.Where(i => i.Deleted != true && i.FirstName.ToLower().StartsWith(pattern) || i.Id.ToString().ToLower().Contains(pattern)).ToList();
            UsersFiltrados = filtrado;

            botones(acum + 1, btn2, UsersFiltrados);
            botones(acum + 2, btn3, UsersFiltrados);
            botones(acum + 3, btn4, UsersFiltrados);
            if (btn2.Enabled == false)
            {
                btnultimo.Enabled = false;
                btnsiguiente.Enabled = false;
            }
            else 
            {
                btnultimo.Enabled = true;
                btnsiguiente.Enabled = true;
            }

            RenderTable(Paginar(Convert.ToInt32(lblPag.Text), UsersFiltrados));
        }
        public void OrdenarGridAscendente(DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex > 5) return;

            List<string> searchParams = new List<string> { "Id", "Name", "LastName", "Email", "Phonenumber", "Direction" };
            string searchParam = searchParams[e.ColumnIndex];
            int pageNum = Convert.ToInt32(lblPag.Text);

            List<User> paginated = Paginar(pageNum, GlobalUsers);

            Ordenado = paginated.OrderBy(l => Searcher(l, searchParam)).ToList();

            RenderTable(Ordenado);
        }
        public void OrdenarGridDescendente(DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex > 5) return;
            List<string> searchParams = new List<string> { "Id", "Name", "LastName", "Email", "Phonenumber", "Direction" };
            string searchParam = searchParams[e.ColumnIndex];
            int pageNum = Convert.ToInt32(lblPag.Text);
            List<User> paginated = Paginar(pageNum, GlobalUsers);
            Ordenado = paginated.OrderByDescending(l => Searcher(l, searchParam)).ToList();
            RenderTable(Ordenado);
        }
        private void UsersTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Ascendente)
                OrdenarGridDescendente(e);
            else
                OrdenarGridAscendente(e);
            Ascendente = !Ascendente;
        }
    }
}
