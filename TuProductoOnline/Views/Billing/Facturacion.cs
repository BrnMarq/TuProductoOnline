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
using System.Reflection;
using static iTextSharp.text.pdf.hyphenation.TernaryTree;
using com.itextpdf.text.pdf;
using Org.BouncyCastle.Asn1;
using System.Runtime.InteropServices;
using iTextSharp.tool.xml.html.table;
using System.Security.Cryptography;
using System.Threading;
using System.Xml.Linq;


namespace TuProductoOnline.Views
{

    public partial class Facturacion : Form
    {
        List<List<string>> Clientes = new List<List<string>>(DbHandler.LeerCSV(FileNames.Customers));
        List<List<string>> Productos = new List<List<string>>(DbHandler.LeerCSV(FileNames.Products));
        List<List<string>> ProductosCarrito = new List<List<string>>();
        public int contador = 0;

        public Facturacion()
        {
            InitializeComponent();
            //Crear Json de registro si no existe.
            bool fileExists = File.Exists(FileNames.BillRegister);
            if (!fileExists) File.Create(FileNames.BillRegister).Close();
            Refield();
            
        }

        private void btnAñadirClient_Click(object sender, EventArgs e)
        {
            new CustomerProperties(CreateCustomer).ShowDialog();
            Clientes.Clear();
            Clientes = DbHandler.LeerCSV(FileNames.Customers);
            Refield();
        }


        private void btnFacturar_Click_1(object sender, EventArgs e)
        {

            if (ProducTable.Rows.Count == 0) return;

                List<Product> prueba = new List<Product>(TransformarCarritoAProducto(ProductosCarrito));
                //compaginar lo obtenido en el selectbox con el index de la lista.
                int iterador = -1;
                int Verificadorfalse = 0;
                foreach (List<string> item in Clientes)
                {
                    iterador++;
                    if (Clientes[iterador][8] == "true") { Verificadorfalse++; }
                    if (ClientBox1.SelectedIndex == iterador - Verificadorfalse && Clientes[iterador][8] == "false") { break; }
                }


            Bill factura = new Bill(User.ActiveUser.Id.ToString())
            {
                BillId = DbHandler.GetNewId(FileNames.BillId),
                Fecha = DateTime.Now.ToString("dd/MM/yyyy. HH:mm:ss"),
                FechaDeVencimiento = DateTime.Now.AddDays(15).ToString("dd/MM/yyyy."),
                Usd = 0,

                    Cliente = TransformarSeleccionACliente(Clientes[iterador]),
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

                //Reset del carrito, datagridview y contadores.
                ProductosCarrito.Clear();
                ProducTable.Rows.Clear();
                contador = 0;
                CantidadBox.Text = "0 Bs.S";
                ClientBox1.SelectedIndex = -1;
                ProductBox2.SelectedIndex = -1;
                CantidadBox.Text = "";
            

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
            bool verificar = string.IsNullOrEmpty(CantidadBox.Text);

            //evaluar campos vacios. 

            if (ClientBox1.SelectedItem == null || ProductBox2.SelectedItem == null || verificar == true || int.Parse(CantidadBox.Text) == 0)
            {
                //campo de seleccion de cliente vacio.
                if (ClientBox1.SelectedItem == null)
                {

                    MessageBox.Show("Por favor selecciona un cliente.");
                    
                }
                //campo de seleccion de producto vacio.
                else if (ProductBox2.SelectedItem == null)
                {

                    MessageBox.Show("Por favor selecciona un producto.");
                    
                }
                else
                {

                    MessageBox.Show("Por favor introduce una cantidad mayor que 0");
                  
                }

            }

            else
            {
                //Agregar a una lista

                ProductosCarrito.Add(new List<string>());
                int Verificadorfalse = 0;
                int iterador = -1;
                foreach (List<string> item in Productos)
                {
                    iterador++;
                    foreach (var sublist in item)
                    {
                        //Compaginar el index del combobox con la posicion de la lista de lista
                        if (ProductBox2.SelectedIndex == iterador - Verificadorfalse && Productos[iterador][6] == "false") { ProductosCarrito[contador].Add(sublist); }
             
                    }
                    if (Productos[iterador][6] == "true") { Verificadorfalse++; }
                    if (ProductBox2.SelectedIndex == iterador - Verificadorfalse && Productos[iterador][6] == "false") { break; }
                }


                ProductosCarrito[contador][7] = CantidadBox.Text;

                //Agregar al DataGridView

                ProducTable.Rows.Add(ProductosCarrito[contador][0], ProductosCarrito[contador][1], ProductosCarrito[contador][2] + " Bs.S", CantidadBox.Text);

                contador++;
                actualizarPrecio();
                CantidadBox.Text = "";
            }


        }

        // Eliminar producto del data gridview y el carrito al clickear en el simbolo.
        private void ProducTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                MessageBox.Show("Producto eliminado con exito");
                actualizarPrecio(); 
            }


            if (e.ColumnIndex == ProducTable.Columns["Cantidad"].Index && i != -1)
            {
                //Asignar cantidad a variable.
                string cantidad = Microsoft.VisualBasic.Interaction.InputBox("Ingresa cantidad", "Cambio de monto", "1");
                bool validacion = false;
                bool pass = true;
                i = 0;
                foreach (char item in cantidad)
                {
                    
                    if (item == '0' && i == 0){ pass = false; }
                    else if (item < '0' || item > '9'){ pass = false; }
                    if(pass == true)
                    {
                        validacion = true;
                    }

                    i++;

                }

                if(validacion == false)
                {
                    MessageBox.Show("Error Valor Invalido: Ingrese numeros mayores a 0 y Naturales");
                }
                else if (validacion == true)
                {
                    //Modificar cantidad en DataGridView.
                    ProducTable.Rows[e.RowIndex].Cells[3].Value = cantidad;
                    //Modificar cantidad en la lista de listas.
                    ProductosCarrito[e.RowIndex][7] = cantidad;
                }
            }

        }
        private void bntAñadirProduct_Click(object sender, EventArgs e)
        {

        }

        public void Refield()
        {
            //Llenar combobox clientes.
            //La excepcion controla el caso en que no hayan clientes en el csv.
            ClientBox1.Items.Clear();
            foreach (List<string> subList in Clientes)
            {
                if (subList[8] != "true")
                {
                    try { ClientBox1.Items.Add(subList[1]); } catch (Exception) { }
                }
                
            }
            //llenar combobox productos
            ProductBox2.Items.Clear();
            foreach (List<string> subList in Productos)
            {

                if (subList[6] != "true")
                {
                    try { ProductBox2.Items.Add(subList[1]); } catch (Exception) { }
                }
            }


        }
        
        public void actualizarPrecio()
        {
            double Precio = 0;
            double PrecioFinal;
            //compaginar lo obtenido en el selectbox con el index de la lista.
            foreach (var item in ProductosCarrito)
            {
                Precio += (double.Parse(item[2]) * double.Parse(item[7]));
            }

            txtSubTotal.Text = Precio.ToString() + " Bs.S";

            double PrecioIva = 16 * Precio / 100;
            int Verificadorfalse = 0;
            int iterador = -1;
            int posicion = 0;
            foreach (List<string> item in Clientes)
            {
                iterador++;
                if (Clientes[iterador][8] == "true") { Verificadorfalse++; }
                if (ClientBox1.SelectedIndex == iterador - Verificadorfalse && Clientes[iterador][8] == "false"){ posicion = iterador; }
            }
            
            if (Clientes[posicion][7] == "Contribuyente especial") { PrecioFinal = (PrecioIva * 75 / 100) + Precio; } else { PrecioFinal = PrecioIva + Precio;}
            
            txtTotal.Text = PrecioFinal.ToString() + " Bs.S";
        }
        

        public List<Product> TransformarCarritoAProducto(List<List<string>> list)
        {
            List<Product> ListaProductos = new List<Product>();
            int i = 0;
            foreach (var producto in list)
            {
                ListaProductos.Add(new Product() { Id = int.Parse(list[i][0]), Price = double.Parse(list[i][2]), Amount = list[i][7], Name = list[i][1], Description = list[i][4] });
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
            string FacturaHeader_Texto = Properties.Resources.Header.ToString();

            //Replace de la factura y otros calculos.

            //Empresa
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@NOMBREEMPRESA", "TuProductoOnline");
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@RAZONSOCIAL", "TuProductoOnline C.A.");
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@DOMICILIOFISCAL", "Caracas, Venezuela");
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@NUMERO", "0800-12345678");

            //Datos de la factura.
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@NRODEFACTURA", factura.BillId.ToString());
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@IDCAJERO", factura.Cajero);
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@FECHA", factura.Fecha);
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@DATE", factura.FechaDeVencimiento);


            //Cliente
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@IDENTIDAD", factura.Cliente.Document.ToString());
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@CONDICION", factura.Cliente.Type);
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@REASON", factura.Cliente.Name);
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@ADDRES", factura.Cliente.Address);
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@PHONE", factura.Cliente.PhoneNumber);
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@IVA", "16 %");

            string FacturaContent_Texto = Properties.Resources.Content.ToString();


            if (guardarFactura.ShowDialog() == DialogResult.OK)
            {
                //Asignar espacio de memoria y crear el documento.
                using (FileStream stream = new FileStream(guardarFactura.FileName, FileMode.Create))
                {
                    //Establecer el formato del documento e instancearlo.
                    Document facturaPdf = new Document(PageSize.A4, 25, 25, 25, 35);

                    //Creando el modificador que tiene como argumentos la factura y el espacio asignado en memoria.
                    PdfWriter modificador = PdfWriter.GetInstance(facturaPdf, stream);

                    var pe = new PageEventHelper();
                    modificador.PageEvent = pe;
                    pe.Title = FacturaHeader_Texto;

                    facturaPdf.Open();
                    facturaPdf.Add(new Phrase());     

                    //Tabla (Cuerpo) de producto.

                    PdfPTable TablaBody = new PdfPTable(6);

                    double iva = 16;
                    double Total = 0;
                    double TotalSinIVA = 0;
                    string moneda = " Bs.S";
                    if (factura.Usd != 0){ moneda = " USD"; }
                    
                    if (factura.Cliente.Type == "Ordinario") { iva = 16; }

                    TablaBody.HorizontalAlignment = 0;
                    TablaBody.TotalWidth = 545f;
                    TablaBody.LockedWidth = true;
                    float[] widths = new float[] { 75f, 110f, 160f, 40f, 100f, 115f };
                    TablaBody.SetWidths(widths);
                    
                    foreach (var item in factura.ListaProductos)
                    {
     
                        double priceProduct = 0;
                        priceProduct = item.Price * double.Parse(item.Amount);

                        addCell(TablaBody, item.Amount, 1);
                        addCell(TablaBody, item.Name, 1);
                        addCell(TablaBody, item.Description, 1);
                        addCell(TablaBody, iva.ToString(), 1);
                        addCell(TablaBody, item.Price.ToString() + moneda, 1);
                        addCell(TablaBody, priceProduct.ToString() + moneda, 1);

                        Total += priceProduct;
                        TotalSinIVA += item.Price * double.Parse(item.Amount);
                    }

                    facturaPdf.Add(TablaBody);

                    Paragraph saltoDeLinea = new Paragraph(" ");
                    facturaPdf.Add(saltoDeLinea);

                    //Calculos finales y tabla de montos.

                    PdfPTable TablaTotal = new PdfPTable(2);

                    TablaTotal.HorizontalAlignment = 0;
                    TablaTotal.TotalWidth = 545f;
                    TablaTotal.LockedWidth = true;
                    float[] width = new float[] { 295f, 250f };
                    TablaTotal.SetWidths(width);

                    double TotalDelIVA = Total * iva / 100;
                    double MontoExentoDelIVA = 0;

                    if (factura.Cliente.Type != "Ordinario")
                    {
                        MontoExentoDelIVA = (TotalDelIVA * 75 / 100);
                    }

                    double PrecioFinal = (TotalSinIVA + TotalDelIVA) - MontoExentoDelIVA;

                    addCellColor(TablaTotal, "Monto Total Exento o Exonerado del IVA:", 1);
                    addCell(TablaTotal, MontoExentoDelIVA.ToString() + moneda, 1);

                    addCellColor(TablaTotal, "Monto Total de la Base Imponible según Alicuota 16,00%:", 1);
                    addCell(TablaTotal, TotalSinIVA.ToString() + moneda, 1);

                    addCellColor(TablaTotal, "Monto Total del Impuesto según Alicuota 16, 00 %:", 1);
                    addCell(TablaTotal, PrecioFinal.ToString() + moneda, 1);

                   
                    facturaPdf.Add(TablaTotal);

                    facturaPdf.Close();

                    stream.Close();

                }

                void addCellColor(PdfPTable table, string text, int rowspan)
                {
                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
                    iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE);
                   
                    PdfPCell cell = new PdfPCell(new Phrase(text));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(51, 153, 255);//(169, 169, 169);
                    cell.Rowspan = rowspan;
                    cell.Padding = 7;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cell);
                }

                void addCell(PdfPTable table, string text, int rowspan)
                {
                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
                    iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE);

                    PdfPCell cell = new PdfPCell(new Phrase(text));
                    cell.Rowspan = rowspan;
                    cell.Padding = 7;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cell);
                }
            }
        }

        public void CreateCustomer(List<string> customerValues)
        {
            new Customer(
                customerValues[1],
                customerValues[2],
                customerValues[3],
                customerValues[4],
                customerValues[5],
                customerValues[6],
                customerValues[7]
                );
        }
        
    }


}
