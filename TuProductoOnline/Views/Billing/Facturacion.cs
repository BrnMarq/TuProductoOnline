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
using System.Net.Http.Headers;
using TuProductoOnline.Consts;
using System.Reflection.Emit;
using System.Text.Json;
using System.Text.Json.Serialization;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System.IO;
using System.Runtime.InteropServices.ComTypes;


//

namespace TuProductoOnline.Views
{

    public partial class Facturacion : Form
    {
        List<List<string>> Clientes = new List<List<string>>(DbHandler.LeerCSV(FileNames.Customers));
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
            if (ProducTable.Rows.Count == 0) { }

            else
            {
                List<Product> prueba = new List<Product>(TransformarCarritoAProducto(ProductosCarrito));


                Bill factura = new Bill(User.ActiveUser.Id.ToString())
                {
                    BillId = DbHandler.GetNewId(FileNames.BillId),
                    Fecha = DateTime.Now.ToString("dd/MM/yyyy. HH:mm:ss"),
                    FechaDeVencimiento = DateTime.Now.AddDays(15).ToString("dd/MM/yyyy. HH:mm:ss"),

                    Cliente = TransformarSeleccionACliente(Clientes[ClientBox1.SelectedIndex]),
                    ListaProductos = new List<Product>(TransformarCarritoAProducto(ProductosCarrito)) { },

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
                //guardar Json actualizado.
                jsonString = JsonSerializer.Serialize(BillsRegister);
                File.WriteAllText(fileName, jsonString);

                //Imprimir Pdf
                ToPdf(factura);

                //Reseteset del carrito, datagridview y contadores.
                ProductosCarrito.Clear();
                ProducTable.Rows.Clear();
                contador = 0;
                actualizarPrecio();
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
                else if (ProductBox2.SelectedItem == null)
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

        // Eliminar producto del data gridview y el carrito al clickear en el simbolo.
        private void ProducTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int i;
            try
            {
                i = ProducTable.CurrentCell.RowIndex;
            }
            catch (NullReferenceException)
            {
                i = -1;
            }

            if (e.ColumnIndex == ProducTable.Columns["DeleteCell"].Index && i != -1)
            {
                ProducTable.Rows.Remove(ProducTable.CurrentRow);
                ProductosCarrito.RemoveAt(i);
                contador--;
                actualizarPrecio();
            }

        }
        private void bntAñadirProduct_Click(object sender, EventArgs e)
        {

        }

        //Aqui toca editar los campos de las listas.
        public void Refield()
        {
            //Llenar combobox clientes.
            //La excepcion controla el caso en que no hayan clientes en el csv.
            foreach (List<string> subList in Clientes)
            {
                if (subList[8] != "true")
                {
                    try { ClientBox1.Items.Add(subList[1]); } catch (Exception) { }
                }
                
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

            
            txtTotal.Text = ((Precio * 16/100) + Precio).ToString();
        }
        //Aqui toca editar los campos de las listas.
        public List<Product> TransformarCarritoAProducto(List<List<string>> list)
        {
            List<Product> ListaProductos = new List<Product>();
            int i = 0;
            foreach (var producto in list)
            {
                ListaProductos.Add(new Product() { Id = int.Parse(list[i][0]), Price = double.Parse(list[i][3]), Amount = list[i][4], Name = list[i][1] });
                i++;

            }

            return ListaProductos;
        }

        public Customer TransformarSeleccionACliente(List<string> List)
        {
            Customer Cliente = new Customer() { Code = int.Parse(List[0]), Name = List[1], LastName = List[2], Document = List[3], PhoneNumber = List[4], Address = List[5], Email = List[6], Type = List[7]};
            
            return Cliente;
         }


        void ToPdf(Bill factura)
        {
            
            SaveFileDialog guardarFactura = new SaveFileDialog();
            guardarFactura.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            //Leer plantilla y pasar a string.
            string FacturaHtlml_Texto = Properties.Resources.plantillaFactura.ToString();

            //Replace de la factura y otros calculos.

            //Empresa
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@NOMBREEMPRESA", "TuProductOnline");
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@RAZONSOCIAL", "TuProductOnline C.A.");
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@DOMICILIOFISCAL", "Narnia");
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@NUMERO", "0800-NoJuegenLolYBañese");

            //Datos de la factura.
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@NRODEFACTURA", factura.BillId.ToString());
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@IDCAJERO", factura.Cajero);
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@FECHA", factura.Fecha);
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@DATE", factura.FechaDeVencimiento);


            //Cliente
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@IDENTIDAD", factura.Cliente.Document.ToString());
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@CONDICION", factura.Cliente.Type);
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@REASON", factura.Cliente.Name);
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@ADDRES", factura.Cliente.Address);
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@PHONE", factura.Cliente.PhoneNumber);
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@IVA", "16 %");

            //Producto
            string filas = string.Empty;
            double iva = 16;
            double Total = 0;
            if (factura.Cliente.Type == "Ordinario"){ iva = 16; }
            
            foreach (var item in factura.ListaProductos)
            {
                double priceProduct = 0;
                priceProduct = ((iva * item.Price / 100) + item.Price)*double.Parse(item.Amount);
                filas += "<tr>";
                filas += "<td>" + item.Amount + "</td>" ;
                filas += "<td>" + item.Name + "</td>";
                filas += "<td>" + iva.ToString() + "</td>";
                filas += "<td>" + item.Price + "</td>";
                filas += "<td>" + priceProduct.ToString() + "</td>";
                filas += "</tr>";
                Total += priceProduct;
            }
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@Filas", filas);

            /*Calculos finales
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@MONTO1",);
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@MONTO2",);
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@MONTO3",);*/
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@MONTOTOTAL", Total.ToString());


            if (guardarFactura.ShowDialog() == DialogResult.OK)
            {
                //Asignar espacio de memoria y crear el documento.
                using (FileStream stream = new FileStream(guardarFactura.FileName, FileMode.Create))
                {
                    //Establecer el formato del documento e instancearlo.
                    Document facturaPdf = new Document(PageSize.A4, 25, 25, 25, 25);

                    //Creando el modificador que tiene como argumentos la factura y el espacio asignado en memoria.
                    PdfWriter modificador = PdfWriter.GetInstance(facturaPdf, stream);


                    facturaPdf.Open();
                    facturaPdf.Add(new Phrase());

                    //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.)

                    //transformar el string para poder usarlo.
                    using (StringReader sr = new StringReader(FacturaHtlml_Texto))
                    {
                        //Usar el modificador para editar el archivo pdf con el string que transformamos.
                        XMLWorkerHelper.GetInstance().ParseXHtml(modificador, facturaPdf, sr);
                    }

                    facturaPdf.Close();

                    stream.Close();

                }
            }
        }

        
    }


}
