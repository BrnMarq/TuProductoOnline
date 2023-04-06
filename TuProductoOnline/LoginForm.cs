using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using TuProductoOnline.Models;
using TuProductoOnline.Consts;

namespace TuProductoOnline
{
    public partial class LoginForm : Form
    {
        int mov;
        int movX;
        int movY;

        string usernamePlaceholder = "Usuario";
        string passwordPlaceholder = "Contraseña";
        char passwordMask = '*';

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            UsernameInput.Text = usernamePlaceholder;
            PasswordInput.Text = passwordPlaceholder;

            bool usersFileExist = File.Exists(@"" + FileNames.Users);
            if (!usersFileExist) new User("admin", "admin", "admin", "Admin");
        }

        // ------------------ Make window movable functionality ------------------
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void Header_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        // -----------------------------------------------------

        // ------------------ Input Verifying ------------------
        private void VerifyInputs()
        {
            //Verificaciones de que los campos del usuario y clave no esten vacíos 
            //y asi activar el boton de acceso
            bool usernameInputIsInvalid = string.IsNullOrEmpty(UsernameInput.Text) || UsernameInput.Text == usernamePlaceholder;
            bool passwordInputIsInvalid = string.IsNullOrEmpty(PasswordInput.Text) || PasswordInput.Text == passwordPlaceholder;
            if (usernameInputIsInvalid || passwordInputIsInvalid)
            {
                AccessButton.Enabled = false;
                return;
            }
            AccessButton.Enabled = true;
        }

        private void UsernameInput_TextChanged(object sender, EventArgs e)
        {
            VerifyInputs();
        }

        private void PasswordInput_TextChanged(object sender, EventArgs e)
        {
            VerifyInputs();
        }

        // ------------------------------------------------------

        // ------------------ Placeholders ------------------
        private void UsernameInput_Enter(object sender, EventArgs e)
        {
            if (UsernameInput.Text == usernamePlaceholder)
            {
                UsernameInput.Text = "";
            }
        }

        private void UsernameInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameInput.Text))
                UsernameInput.Text = usernamePlaceholder;
        }

        private void PasswordInput_Enter(object sender, EventArgs e)
        {
            if (PasswordInput.Text == passwordPlaceholder)
            {
                PasswordInput.Text = "";
            }
        }

        private void PasswordInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordInput.Text))
                PasswordInput.Text = passwordPlaceholder;
        }

        // ------------------------------------------------------

        // ------------------ Password visibility ------------------
        private void EyeButton_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility();
        }

        private void TogglePasswordVisibility()
        {
            if (PasswordInput.PasswordChar == passwordMask)
            {
                PasswordInput.PasswordChar = '\0';
                return;
            }
            PasswordInput.PasswordChar = passwordMask;
        }
        // ------------------------------------------------------

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AccessButton_Click(object sender, EventArgs e)
        {
            List<User> users = User.GetUsers();
            string username = UsernameInput.Text;
            string password = PasswordInput.Text;
            User user = users.Find(targetUser => targetUser.FirstName == username && targetUser.Password == password);
            if (user != null)
            {
                User.Login(user);
                OpenApp();
                this.Close();
                return;
            }
            MessageBox.Show("Usuario y contraseña no válidos");
            UsernameInput.Text = "";
            PasswordInput.Text = "";
        }
        
        private void OpenApp()
        {
            Thread th = new Thread(() => Application.Run(new Main()));
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
}
