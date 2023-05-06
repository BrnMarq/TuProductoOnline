using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TuProductoOnline.Models;
using TuProductoOnline.Utils;
using TuProductoOnline.Consts;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static iTextSharp.text.pdf.hyphenation.TernaryTree;
using System.Linq;
using TuProductoOnline.Views.Billing;

namespace TuProductoOnline.Views
{

    public partial class Facturacion : Form
    {
        List<Customer> Clientes = new List<Customer>();
        List<Product> Productos = new List<Product>();
        List<Product> ProductosCarrito = new List<Product>();
        Customer ClienteSelect = new Customer();

        DolarToDay DolarToDayAPI = new DolarToDay()
        {
             Dolar = new DolarToDay.USD(){},
             Euro = new DolarToDay.EUR(){},
             PesosCol = new DolarToDay.COL(){},
        };

        public int contador = 0;
        double DivisaPrice = 1;

        public Facturacion()
        {
            InitializeComponent();
            //Crear Json de registro si no existe.
            bool fileExists = File.Exists(FileNames.BillRegister);
            if (!fileExists) File.Create(FileNames.BillRegister).Close();
            ProductosCarrito.Clear();
            GetPriceDollar();
            Refield();

            //Rellenar combobox divisas.
            DivisasBox.Items.Add(" Bs.S");
            DivisasBox.Items.Add(" .USD");
            DivisasBox.Items.Add(" .EUR");
            DivisasBox.Items.Add(" .COP");

            DivisasBox.Text = " Bs.S";

        }

        private void btnAñadirClient_Click(object sender, EventArgs e)
        {
            new CustomerProperties(CreateCustomer).ShowDialog();
            Clientes.Clear();
            Refield();
        }


        private void btnFacturar_Click_1(object sender, EventArgs e)
        {

            if (ProducTable.Rows.Count == 0) {
                MessageBox.Show("Elcarrito esta vacio. Agregue algun producto");
            }
            else
            {


            Bill factura = new Bill(User.ActiveUser.Id.ToString())
            {
                BillId = DbHandler.GetNewId(FileNames.BillId),
                Fecha = DateTime.Now.ToString("dd/MM/yyyy. HH:mm:ss"),
                FechaDeVencimiento = DateTime.Now.AddDays(15).ToString("dd/MM/yyyy."),
                Divisa = DivisasBox.Text,
                DivisaPrice = DivisaPrice,

                    Cliente = ClienteSelect, 
                    ListaProductos = ProductosCarrito

            };

                string fileName = FileNames.BillRegister;
                string jsonString = File.ReadAllText(fileName);

                List<Bill> BillsRegister = new List<Bill>();
                try //adquirirfactura
                {
                    BillsRegister = JsonConvert.DeserializeObject<List<Bill>>(jsonString);
                    BillsRegister.Add(factura);
                }
                catch (Exception) //Capturar json vacio.
                {
                    //Crear y agregar primera dactura a la lista 
                    BillsRegister = new List<Bill>();
                    BillsRegister.Add(factura);
                    jsonString = JsonConvert.SerializeObject(BillsRegister);
                    BillsRegister = JsonConvert.DeserializeObject<List<Bill>>(jsonString);
                    File.WriteAllText(fileName, jsonString);
                }
                //guardar Json actualizado.
                jsonString = JsonConvert.SerializeObject(BillsRegister);
                File.WriteAllText(fileName, jsonString);

                //Imprimir Pdf
                ToPdf(factura);

                //Reset del carrito, datagridview y contadores.
                ProductosCarrito.Clear();
                ProducTable.Rows.Clear();
                contador = 0;
                CantidadBox.Text = "0 Bs.S";
                CantidadBox.Text = "";

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
            bool verificar = string.IsNullOrEmpty(CantidadBox.Text);



            //evaluar campos vacios. 
            
            if (TextBox.Text == string.Empty || ProductBox2.Text == string.Empty || verificar == true || int.Parse(CantidadBox.Text) == 0)
            {
                //campo de seleccion de cliente vacio.
                if (TextBox.Text == string.Empty)
                {

                    MessageBox.Show("Por favor selecciona un cliente valido.");

                }
                //campo de seleccion de producto vacio.
                else if (ProductBox2.Text == string.Empty)
                {

                    MessageBox.Show("Por favor selecciona un producto valido.");

                }
                else
                {

                    MessageBox.Show("Por favor introduce una cantidad mayor que 0");

                }

            }

            else
            {

                SetClient(TextBox.Text);
                SetProduct(ProductBox2.Text, CantidadBox.Text);
                try
                {

                

                if ((ClienteSelect.Document == null) || ProductosCarrito[contador].Name == null)
                {
                    //campo de seleccion de cliente vacio.
                    if (ClienteSelect.Document == null)
                    {

                        MessageBox.Show("El cliente ingresado no existe.");

                    }
                    else
                    {

                        MessageBox.Show("El producto ingresado no existe.");

                    }

                } else {

                        //Agregar al DataGridView
                
                ProducTable.Rows.Add(ProductosCarrito[contador].Id, ProductosCarrito[contador].Name, Math.Round(ProductosCarrito[contador].Price/DivisaPrice, 2).ToString() + DivisasBox.Text, ProductosCarrito[contador].Amount);
               
                contador++;
                actualizarPrecio();
                CantidadBox.Text = "";
                }
                }
                catch (Exception)
                {
                    MessageBox.Show("El producto ingresado no existe.");
                   // throw;
                }
                ProductBox2.Text = "";
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
                    ProductosCarrito[e.RowIndex].Amount = cantidad;
                }
            }

        }
        private void bntAñadirProduct_Click(object sender, EventArgs e)
        {

        }

        public void Refield()
        {
            List<List<string>> CsvClientes = new List<List<string>>(DbHandler.LeerCSV(FileNames.Customers));
            List<List<string>> CsvProductos = new List<List<string>>(DbHandler.LeerCSV(FileNames.Products));
           

            //Llenar Textbox clientes.
            //La excepcion controla el caso en que no hayan clientes en el csv.
         
           
            foreach (List<string> item in CsvClientes)
            {
                if (item[8] != "true")
                {
                    Clientes.Add(new Customer() { Code = int.Parse(item[0]), Name = item[1], LastName = item[2], Document = item[3], PhoneNumber = item[4], Address = item[5], Email = item[6], Type = item[7]});
                    
                }
                
            }
            

            //llenar textbox productos.
            
            foreach (List<string> item in CsvProductos)
            {
                if (item[6] != "true")
                {
                    Productos.Add(new Product() { Id = int.Parse(item[0]), Price = double.Parse(item[2]), Amount = item[7], Name = item[1], Description = item[4] });

                }
            }

            AutoCompleteStringCollection datosClientes = new AutoCompleteStringCollection();
            AutoCompleteStringCollection datosProductos = new AutoCompleteStringCollection();
            //Añadir items de busqueda(Clientes).
            foreach (var item in Clientes)
            {
                datosClientes.Add(item.Document);
                datosClientes.Add(item.Name);

            }

            TextBox.AutoCompleteCustomSource = datosClientes;
            TextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            TextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            
            //Añadir items de busqueda(Clientes).
            foreach (var item in Productos)
            {
                datosProductos.Add(item.Name);
                //ProductBox2.DataSource


            }

            

            ProductBox2.AutoCompleteCustomSource = datosProductos;
            ProductBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            ProductBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }
        
        public void actualizarPrecio()
        {
            double Precio = 0;
            double PrecioFinal;
            //compaginar lo obtenido en el selectbox con el index de la lista.
            foreach (var item in ProductosCarrito)
            {
                Precio += (item.Price * double.Parse(item.Amount));
            }

            txtSubTotal.Text = Math.Round(Precio / DivisaPrice, 2).ToString() + DivisasBox.Text;

            double PrecioIva = 16 * Precio / 100;

            if (ClienteSelect.Type == "Contribuyente especial") { PrecioFinal = (PrecioIva * 75 / 100) + Precio; } else { PrecioFinal = PrecioIva + Precio;}
            
            txtTotal.Text = Math.Round(PrecioFinal / DivisaPrice, 2).ToString() + DivisasBox.Text;
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
                        addCell(TablaBody, Math.Round(item.Price/factura.DivisaPrice,2).ToString() + factura.Divisa, 1);
                        addCell(TablaBody, Math.Round(priceProduct / factura.DivisaPrice, 2).ToString() + factura.Divisa, 1);

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
                    addCell(TablaTotal, Math.Round(MontoExentoDelIVA / factura.DivisaPrice,2).ToString() + factura.Divisa, 1);

                    addCellColor(TablaTotal, "Monto Total de la Base Imponible según Alicuota 16,00%:", 1);
                    addCell(TablaTotal, Math.Round(TotalSinIVA / factura.DivisaPrice,2).ToString() + factura.Divisa, 1);

                    addCellColor(TablaTotal, "Monto Total del Impuesto según Alicuota 16, 00 %:", 1);
                    addCell(TablaTotal, Math.Round(PrecioFinal/factura.DivisaPrice,2).ToString() + factura.Divisa, 1);

                   
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

        public void GetPriceDollar()
        {
            
            using (var client = new HttpClient())
            {
                string url = "https://s3.amazonaws.com/dolartoday/data.json";

                client.DefaultRequestHeaders.Clear();

                var response = client.GetAsync(url).Result;

                var res = response.Content.ReadAsStringAsync().Result;
                dynamic r = JObject.Parse(res);
                
                DolarToDayAPI.Dolar.sicad2 = r.USD.sicad2;
                DolarToDayAPI.Euro.sicad2 = r.EUR.sicad2;
                DolarToDayAPI.PesosCol.compra = r.COL.compra;
            }
            
        }

        public void SetClient(string text)
        {
            

            var search = from s in Clientes
                         where s.Document.ToLower() == text.ToLower() || s.Name.ToLower() == text.ToLower()
                         select new { s.Document, s.PhoneNumber, s.Address, s.Name, s.Type, s.LastName };

            try
            {
                foreach (var item in search)
                {
                    ClienteSelect.Document = item.Document;
                    ClienteSelect.PhoneNumber = item.PhoneNumber;
                    ClienteSelect.Address = item.Address;
                    ClienteSelect.Name = item.Name;
                    ClienteSelect.LastName = item.LastName;
                    ClienteSelect.Type = item.Type;

                }
            }
            catch (Exception)
            {

                throw;
            } 
        }

        public void SetProduct(string text, string amount)
        {

            var search = from s in Productos
                         where s.Name.ToLower() == text.ToLower()
                         select new { s.Name, s.Price, s.Description, s.Id};

            try
            {
                foreach (var item in search)
                {
                   

                    ProductosCarrito.Add(new Product() { Id = item.Id, Price = item.Price, Amount = amount, Name = item.Name, Description = item.Description });

                }
                
            }
            catch (Exception)
            {

                throw;
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

        private void DivisasBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            double precio = 1;

            if (DivisasBox.Text == " Bs.S")
            {
                precio = 1;
            } else if(DivisasBox.Text == " .USD")
            {
                precio = DolarToDayAPI.Dolar.sicad2;
            } else if(DivisasBox.Text == " .EUR")
            {
                precio = DolarToDayAPI.Euro.sicad2;
            }
            else if (DivisasBox.Text == " .COP")
            {
                double a = DolarToDayAPI.PesosCol.compra;
                precio = 1 / a;
            }


            ProducTable.Rows.Clear();
            try
            {
                int i = 0;
                foreach (var item in ProductosCarrito)
                {
                    ProducTable.Rows.Add(item.Id, item.Name, Math.Round(item.Price / precio, 2).ToString() + DivisasBox.Text, item.Amount);
                    i++;
                }
                
                DivisaPrice = precio;
            }
            catch (Exception)
            {
                throw;
                
            }

            AlCambio.Text = DivisaPrice.ToString() + " Bs.S";
            
            actualizarPrecio();
           
        }


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

            if (e.ColumnIndex == ProducTable.Columns["DeleteCell"].Index && e.RowIndex != -1 && i != -1)
            {
                ShowDeleteProduct(ref ProducTable, i);
                /*if (ProductDelete._eliminated == true)
                {
                    //ProducTable.Rows.Remove(ProducTable.CurrentRow);
                    ProductosCarrito.RemoveAt(i);
                    contador--;
                    //MessageBox.Show("Producto eliminado con exito");
                    actualizarPrecio();
                }*/
            }


            if (e.ColumnIndex == ProducTable.Columns["Cantidad"].Index && e.RowIndex != -1)
            {
                //Asignar cantidad a variable.
                string cantidad = Microsoft.VisualBasic.Interaction.InputBox("Ingresa cantidad", "Cambio de monto", "1");
                bool validacion = false;
                bool pass = true;
                i = 0;
                foreach (char item in cantidad)
                {

                    if (item == '0' && i == 0) { pass = false; }
                    else if (item < '0' || item > '9') { pass = false; }
                    if (pass == true)
                    {
                        validacion = true;
                    }

                    i++;

                }

                if (validacion == false)
                {
                    MessageBox.Show("Error Valor Invalido: Ingrese numeros mayores a 0 y Naturales");
                }
                else if (validacion == true)
                {
                    //Modificar cantidad en DataGridView.
                    ProducTable.Rows[e.RowIndex].Cells[3].Value = cantidad;
                    //Modificar cantidad en la lista de listas.
                    ProductosCarrito[e.RowIndex].Amount = cantidad;
                }
            }
        }

        private void ShowDeleteProduct(ref DataGridView dgv, int index) 
        {
            new ProductDelete(ref dgv).Show();
            if (ProductDelete._eliminated == true)
            {
                ProductosCarrito.RemoveAt(index);
                contador--;
                actualizarPrecio();
            }
        }
    }


}
