using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuProductoOnline.Views
{
    
    public partial class Facturacion : Form
    {
        List<List<string>> Clientes = new List<List<string>>();
        List<List<string>> Productos = new List<List<string>>();
        List<List<string>> ProductosCarrito = new List<List<string>>();

        public Facturacion()
        {
            InitializeComponent();
            Clientes.Add(new List<string> { "007", "Angel", "5" });
            Clientes.Add(new List<string> { "2", "Franchesco", "3" });
            Clientes.Add(new List<string> { "3", "Virgolini", "1" });
            Clientes.Add(new List<string> { "4", "TuNoMeteCabraZalamanbique", "5" });

            foreach (List<string> subList in Clientes)
            {
                ClientBox1.Items.Add(subList[1]);
            }
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            
        }

    }

    
}
