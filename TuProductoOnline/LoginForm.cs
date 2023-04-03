﻿using System;
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
    public partial class LoginForm : Form
    {
        int mov;
        int movX;
        int movY;

        string usernamePlaceholder = "Username";
        string passwordPlaceholder = "Password";
        char passwordMask = '*';

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            UsernameInput.Text = usernamePlaceholder;
            PasswordInput.Text = passwordPlaceholder;
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
                btnAcceso.Enabled = false;
                return;
            }
            btnAcceso.Enabled = true;
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
    }
}