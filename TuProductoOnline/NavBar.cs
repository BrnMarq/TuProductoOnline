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
    public partial class NavBar : Form
    {
        public NavBar()
        {
            InitializeComponent();
        }

        private void NavBar_Load(object sender, EventArgs e)
        {
            List<String> values = new List<String> { "uno", "Brian", "Dos" };
            DbHandler.EscribirCSV("prueba.csv", values);
            //MessageBox.Show(linea);
        }

        private void ProductsTab_Click(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
