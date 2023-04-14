using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuProductoOnline.Utils
{
    class Validar
    {
        public static void SoloLetras(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
            }

        }
         public static void Tab_Enter(KeyPressEventArgs e) 
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        public static void SoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static bool ValidarEmail(string email)
        {
            try
            {
                var compararEmail = new System.Net.Mail.MailAddress(email);
                return compararEmail.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidarTelefono(string telefono)
        {
            string patron = @"/^\s*(?:\+?(\d{1,3}))?([-. (]*(\d{3})[-. )]*)?((\d{3})[-. ]*(\d{2,4})(?:[-.x ]*(\d+))?)\s*$/gm";

            if (Regex.IsMatch(telefono,patron))
                return true;
            else
                return false;
        }
    }
}
