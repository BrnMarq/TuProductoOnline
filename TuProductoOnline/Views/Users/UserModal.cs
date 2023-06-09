﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProductoOnline.Models;
using TuProductoOnline.Utils;

namespace TuProductoOnline.Views.Users
{
    public partial class UserModal : Form
    {
        private readonly string NamePlaceholder = "Nombre";
        private readonly string LastNamePlaceholder = "Apellido";
        private readonly string EmailPlaceholder = "Email";
        private readonly string PhoneNumberPlaceholder = "Teléfono";
        private readonly string AddressPlaceholder = "Dirección";
        private readonly string PasswordPlaceholder = "Contraseña";

        private readonly int _id;
        private readonly string _firstName = "";
        private readonly string _lastName = "";
        private readonly string _email = "";
        private readonly string _phoneNumber = "";
        private readonly string _address = "";
        private readonly string _password = "";
        private readonly bool _isEdit = false;
        private readonly char[] eliminar = { '\n', '\r' };

        private readonly Action<List<string>> acceptFunction;

        public UserModal()
        {
            InitializeComponent();
        }
        public UserModal(Action<List<string>> callback)
        {
            InitializeComponent();
            acceptFunction = callback;
        }
        public UserModal(Action<List<string>> callback, User user)
        {
            InitializeComponent();
            _id = user.Id;
            _firstName = user.FirstName;
            _lastName = user.LastName;
            _email = user.Email;
            _phoneNumber = user.Phone;
            _address = user.Address;
            _isEdit = true;

            acceptFunction = callback;
        }
        private void AddUsers_Load(object sender, EventArgs e)
        {
            if (_isEdit) 
            {
                TitleUser.Text = "Editar Usuario";
                NameInput.Text = _firstName;
                LastNameInput.Text = _lastName;
                EmailInput.Text = _email;
                PhoneNumberInput.Text = _phoneNumber;
                AddressInput.Text = _address;
                PasswordInput.Text = _password;
                return;
            }
            NameInput.Text = NamePlaceholder;
            LastNameInput.Text = LastNamePlaceholder;
            EmailInput.Text = EmailPlaceholder;
            PhoneNumberInput.Text = PhoneNumberPlaceholder;
            AddressInput.Text = AddressPlaceholder;
            PasswordInput.Text = PasswordPlaceholder;
        }
        private void VerifyInputs()
        {
            //Verificaciones de que los campos del usuario y clave no esten vacíos 
            //y asi activar el boton de acceso
            bool NameInputIsInvalid = string.IsNullOrEmpty(NameInput.Text) || NameInput.Text == NamePlaceholder;
            bool LastNameIsInvalid = string.IsNullOrEmpty(LastNameInput.Text) || LastNameInput.Text == LastNamePlaceholder;
            bool EmailIsInvalid = string.IsNullOrEmpty(EmailInput.Text) || EmailInput.Text == EmailPlaceholder;
            bool PhoneNumberInputIsInvalid = string.IsNullOrEmpty(PhoneNumberInput.Text) || PhoneNumberInput.Text == PhoneNumberPlaceholder;
            bool AddressInputIsInvalid = string.IsNullOrEmpty(AddressInput.Text) || AddressInput.Text == AddressPlaceholder;
            bool PasswordInputIsInvalid = string.IsNullOrEmpty(PasswordInput.Text) || PasswordInput.Text == PasswordPlaceholder;
            if (NameInputIsInvalid || LastNameIsInvalid || EmailIsInvalid || PhoneNumberInputIsInvalid || AddressInputIsInvalid || PasswordInputIsInvalid)
            {
                AcceptButton.Enabled = false;
                return;
            }
            AcceptButton.Enabled = true;
        }
        private int VerifyLengthTlf()
        {
            string telefono = PhoneNumberInput.Text;
            int control = 0;

            if (telefono.Length < 11)
            {
                MessageBox.Show("El número mínimo de caracteres para el teléfono es 12");
            }
            else if (telefono.Length > 20)
            {
                MessageBox.Show("El número máximo de caracteres para el teléfono es 20");
            }
            else
            {
                control = 1;
            }

            return control;
        }
        private void NameInput_TextChanged(object sender, EventArgs e)
        {
            VerifyInputs();

        }
        private void LastNameInput_TextChanged(object sender, EventArgs e)
        {
            VerifyInputs();
        }
        private void EmailInput_TextChanged(object sender, EventArgs e)
        {
            VerifyInputs();
        }
        private void PhoneNumberInput_TextChanged(object sender, EventArgs e)
        {
            VerifyInputs();
        }
        private void AddressInput_TextChanged(object sender, EventArgs e)
        {
            VerifyInputs();
        }
        private void PasswordInput_TextChanged(object sender, EventArgs e)
        {
            VerifyInputs();
        }
        // ------------------ Placeholders ------------------
        private void NameInput_Enter(object sender, EventArgs e)
        {
            if (NameInput.Text == NamePlaceholder)
            {
                NameInput.Text = "";
            }
        }
        private void NameInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameInput.Text))
                NameInput.Text = NamePlaceholder;
        }
        private void LastNameInput_Enter(object sender, EventArgs e)
        {
            if (LastNameInput.Text == LastNamePlaceholder)
            {
                LastNameInput.Text = "";
            }
        }
        private void LastNameInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastNameInput.Text))
                LastNameInput.Text = LastNamePlaceholder;
        }
        private void EmailInput_Enter(object sender, EventArgs e)
        {
            if (EmailInput.Text == EmailPlaceholder)
            {
                EmailInput.Text = "";
            }
        }
        private void EmailInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailInput.Text))
                EmailInput.Text = EmailPlaceholder;
        }
        private void PhoneNumberInput_Enter(object sender, EventArgs e)
        {
            if (PhoneNumberInput.Text == PhoneNumberPlaceholder)
            {
                PhoneNumberInput.Text = "";
            }
        }
        private void PhoneNumberInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PhoneNumberInput.Text))
                PhoneNumberInput.Text = PhoneNumberPlaceholder;
        }
        private void AddressInput_Enter(object sender, EventArgs e)
        {
            if (AddressInput.Text == AddressPlaceholder)
            {
                AddressInput.Text = "";
            }
        }
        private void AddressInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddressInput.Text))
                AddressInput.Text = AddressPlaceholder;
        }
        private void PasswordInput_Enter(object sender, EventArgs e)
        {
            if (PasswordInput.Text == PasswordPlaceholder)
            {
                PasswordInput.Text = "";
            }
        }
        private void PasswordInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordInput.Text))
                PasswordInput.Text = PasswordPlaceholder;
        }
        private void NameInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && NameInput.Text == "")
            {
                NameErrorlbl.Visible = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && NameInput.Text != "")
            {
                NameErrorlbl.Visible = false;
            }
            Validar.SoloLetras(e);
            Validar.Tab_Enter(e);
        }
        private void LastNameInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && LastNameInput.Text == "")
            {
                LastNameErrorlbl.Visible = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && LastNameInput.Text != "")
            {
                LastNameErrorlbl.Visible = false;
            }
            Validar.SoloLetras(e);
            Validar.Tab_Enter(e);
        }
        private void PhoneNumberInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (Validar.ValidarTelefono(PhoneNumberInput.Text.TrimStart(eliminar)))
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                    PhoneNumberErrorlbl.Visible = false;
                }
                else
                {
                    MessageBox.Show("Número de teléfono inválido");
                    PhoneNumberErrorlbl.Visible = true;
                }
            }
        }
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            List<string> values = new List<string>
            {
                _id.ToString(),
                NameInput.Text,
                LastNameInput.Text,
                PasswordInput.Text,
                EmailInput.Text,
                PhoneNumberInput.Text,
                AddressInput.Text,
            };
            acceptFunction(values);
            this.Close();
        }
        private void EmailInput_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (Validar.ValidarEmail(EmailInput.Text.TrimStart(eliminar)))
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                    EmailErrorlbl.Visible = false;
                }
                else
                {
                    MessageBox.Show("Correo inválido");
                    EmailErrorlbl.Visible = true;
                }
            }
        }
        private void AddressInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && AddressInput.Text == "")
            {
                AddressErrorlbl.Visible = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && AddressInput.Text != "")
            {
                AddressErrorlbl.Visible = false;
            }
            Validar.Tab_Enter(e);
        }
        private void PasswordInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && PasswordInput.Text == "")
            {
                MessageBox.Show("Contraseña invalida");
                PasswordErrorlbl.Visible = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && PasswordInput.Text != "")
            {
                PasswordErrorlbl.Visible = false;
            }
            Validar.Tab_Enter(e);
        }
    }
}
