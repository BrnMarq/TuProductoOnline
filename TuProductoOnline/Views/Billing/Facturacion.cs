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
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
using System.IO;
using TuProductoOnline.Consts;
using System.Reflection.Emit;


//

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

        private void btnAñadirClient_Click(object sender, EventArgs e)
        {
            CustomerProperties miVentana = new CustomerProperties();
            miVentana.ShowDialog();
            Refield();
        }

        
        private void btnFacturar_Click_1(object sender, EventArgs e)
        {
            List<Product> prueba = new List<Product>(TransformarCarritoAProducto(ProductosCarrito));
 

            Bill factura = new Bill("chris")
            {
                BillId = DbHandler.GetNewId(FileNames.BillId),
                Fecha = DateTime.Now.ToString("dd/MM/yyyy. HH:mm:ss"),

            ListaProductos = new List<Product>(TransformarCarritoAProducto(ProductosCarrito)){}
            };

            string fileName = FileNames.BillRegister;
            string jsonString = File.ReadAllText(fileName);
          
            List<Bill> BillsRegister = new List<Bill>();
            try //adquirirfactura
            {
                BillsRegister = JsonSerializer.Deserialize<List<Bill>>(jsonString);
                BillsRegister.Add(factura);
            }
            catch (Exception) //Capturar json vacio.
            {
                //Crear y agregar primera dactura a la lista 
                BillsRegister = new List<Bill>();
                BillsRegister.Add(factura);
                jsonString = JsonSerializer.Serialize(BillsRegister);
                BillsRegister = JsonSerializer.Deserialize<List<Bill>>(jsonString);
                File.WriteAllText(fileName, jsonString);

            }

            jsonString = JsonSerializer.Serialize(BillsRegister);
            File.WriteAllText(fileName, jsonString);
            



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

        //Aqui toca editar los campos de las listas.
        private void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            bool verificar = string.IsNullOrEmpty(CantidadBox.Text);
            
            //evaluar campos vacios. 

            if (ClientBox1.SelectedItem == null || ProductBox2.SelectedItem == null || verificar == true || int.Parse(CantidadBox.Text) == 0) 
            {
                //campo de seleccion de cliente vacio.
                if (ClientBox1.SelectedItem == null)
                {
                    string txtAdvertencia = "Por favor selecciona un cliente.";
                    WarningDialog advertencia = new WarningDialog(txtAdvertencia);

                    advertencia.ShowDialog();
                }
                //campo de seleccion de producto vacio.
                else if(ProductBox2.SelectedItem == null)
                {
                    string txtAdvertencia = "Por favor selecciona un producto.";
                    WarningDialog advertencia = new WarningDialog(txtAdvertencia);

                    advertencia.ShowDialog();
                }
                else
                {
                    string txtAdvertencia = "Por favor introduce una cantidad mayor que 0";
                    WarningDialog advertencia = new WarningDialog(txtAdvertencia);

                    advertencia.ShowDialog();
                }

            }

            else
            {
                //Agregar a una lista

                ProductosCarrito.Add(new List<string>());

                int iterador = 0;
                foreach (string item in Productos[ProductBox2.SelectedIndex])
                {
                    
                    ProductosCarrito[contador].Add(item);

                    
                    iterador++;
                }


                ProductosCarrito[contador][ProductosCarrito[contador].IndexOf("Amount")] = CantidadBox.Text;

                //Agregar al DataGridView

                ProducTable.Rows.Add(ProductosCarrito[contador][0], ProductosCarrito[contador][1], ProductosCarrito[contador][3], CantidadBox.Text);
            
                contador++;
            actualizarPrecio();
            }


        }

        private void ProducTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = ProducTable.CurrentCell.RowIndex;

            if (e.ColumnIndex == ProducTable.Columns["DeleteCell"].Index)
            {
                ProducTable.Rows.Remove(ProducTable.CurrentRow);

                ProductosCarrito.RemoveAt(i);
                contador--;
                actualizarPrecio();
            }
        }
        //Aqui toca editar los campos de las listas.
        public void Refield()
        {
            //Llenar combobox clientes.
            //La excepcion controla el caso en que no hayan clientes en el csv.
            foreach (List<string> subList in Clientes)
            {
                try{ClientBox1.Items.Add(subList[1]);} catch (Exception){}
            }
            //llenar combobox productos
            foreach (List<string> subList in Productos)
            {
                try { ProductBox2.Items.Add(subList[1]); } catch (Exception) { }
            }


        }
        //Aqui toca editar los campos de las listas.
        public void actualizarPrecio()
        {
            double Precio = 0;
            foreach (var item in ProductosCarrito)
            {
                Precio += (double.Parse(item[3]) * double.Parse(item[4]));
            }

            txtSubTotal.Text = Precio.ToString();
            txtTotal.Text = ((Precio * double.Parse(Clientes[ClientBox1.SelectedIndex][0])).ToString());
        }
        //Aqui toca editar los campos de las listas.
        public List<Product> TransformarCarritoAProducto(List<List<string>> list)
        {
            List<Product> ListaProductos = new List<Product>();
            int i = 0;
            foreach (var producto in list)
            {
                ListaProductos.Add(new Product(){ Id = int.Parse(list[i][0]), Price = double.Parse(list[i][3]), Amount = list[i][4], Name = list[i][1]});
                i++;
               
            }

            return ListaProductos;
        }

       
    }


}
