using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProductoOnline.Models;
using TuProductoOnline.Utils;

namespace TuProductoOnline.Views
{

    public partial class Facturacion : Form
    {
        List<List<string>> Clientes = new List<List<string>>(DbHandler.LeerCSV("../../Database/Client.csv"));
        List<List<string>> Productos = new List<List<string>>(DbHandler.LeerCSV("../../Database/Products.csv"));
        List<List<string>> ProductosCarrito = new List<List<string>>();
        public int contador = 0;


        public Facturacion()
        {
            InitializeComponent();
            Refield();



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

        public void Refield()
        {
            //Llenar combobox clientes
            foreach (List<string> subList in Clientes)
            {
                ClientBox1.Items.Add(subList[1]);
            }
            //llenar combobox productos
            foreach (List<string> subList in Productos)
            {
                ProductBox2.Items.Add(subList[1]);
            }


        }

        private void ClientBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarPrecio();
        }

        private void CantidadBox_KeyPress(object sender, KeyPressEventArgs e)
        { 
            //hacer que solo se puedan introducir numeros.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {

            //evaluar campos vacios.

            if(ClientBox1.SelectedItem == null || ProductBox2.SelectedItem == null) 
            {
                //campo de seleccion de cliente vacio.
                if (ClientBox1.SelectedItem == null)
                {
                    string txtAdvertencia = "Por favor selecciona un cliente.";
                    WarningDialog advertencia = new WarningDialog(txtAdvertencia);

                    advertencia.ShowDialog();
                }
                //campo de seleccion de producto vacio.
                else
                {
                    string txtAdvertencia = "Por favor selecciona un producto.";
                    WarningDialog advertencia = new WarningDialog(txtAdvertencia);

                    advertencia.ShowDialog();
                }

            }
            else
            {
                //Agregar a una lista

                ProductosCarrito.Add(new List<string>());

                foreach (var item in Productos[ProductBox2.SelectedIndex])
                {
                    ProductosCarrito[contador].Add(item);
                }


                //Agregar al DataGridView

                ListProducTable.Rows.Add(ProductosCarrito[contador][0], ProductosCarrito[contador][1], ProductosCarrito[contador][2], ProductosCarrito[contador][3],  DataGridViewButtonColumn.);
            
                contador++;
            actualizarPrecio();
            }


        }

        public void actualizarPrecio()
        {
            double Precio = 0;
            foreach (var item in ProductosCarrito)
            {
                Precio += int.Parse(item[3]);
            }

            txtSubTotal.Text = Precio.ToString();
            txtTotal.Text = ((Precio * double.Parse(Clientes[ClientBox1.SelectedIndex][0])).ToString());
        }

        private void txtTotal_Click(object sender, EventArgs e)
        {

        }

        //Remover fila.
        private void ListProducTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //asignar variable para remover los datos de la lista que creamos en paralelo.
            int i = ListProducTable.CurrentRow.Index;

            //Remover la fila seleccionada
            ListProducTable.Rows.Remove(ListProducTable.CurrentRow);

            ProductosCarrito.RemoveAt(i);
            contador--;


        }
    }

    
}
