using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProductoOnline.Utils;

namespace TuProductoOnline
{
    public partial class AddUsers : Form
    {
        string NamePlaceholder = "Nombre";
        string LastNamePlaceholder = "Apellido";
        string EmailPlaceholder = "Email";
        string PhoneNumberPlaceholder = "Teléfono";
        string AddressPlaceholder = "Dirección";
        string PasswordPlaceholder = "Contraseña";

        public AddUsers()
        {
            InitializeComponent();
        }
        private void AddUsers_Load(object sender, EventArgs e)
        {
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
                Accessbutton.Enabled = false;
                return;
            }
            Accessbutton.Enabled = true;
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
            Validar.SoloLetras(e);
        }

        private void LastNameInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void PhoneNumberInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }
    }
}
