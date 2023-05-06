using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProductoOnline.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using TuProductoOnline.Consts;
using TuProductoOnline.Utils;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;

namespace TuProductoOnline.Views.BillRegister
{
    public partial class BillingRegistercs : Form
    {
        private List<Bill> register = null;

        public BillingRegistercs()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.ShowDialog();
        }

        private void BillingRegistercs_Load(object sender, EventArgs e)
        {
            try
            {
                string jsonString = File.ReadAllText(FileNames.BillRegister);
                try
                {
                    register = JsonSerializer.Deserialize<List<Bill>>(jsonString);
                }
                catch (JsonException)
                {
                    ;
                }
            }
            catch (FileNotFoundException)
            {
                ;
            }
            renderTable();
        }

        private void renderTable()
        {
            hideImportExportButton();
            dgvBillRegister.Rows.Clear();
            dgvBillRegister.Refresh();
            if (register != null)
            {
                foreach (Bill billn in register)
                {
                    dgvBillRegister.Rows.Add(billn.BillId, billn.Fecha, billn.Cajero, sumProducts(billn.ListaProductos, billn.Cliente));
                }
            }
        }

        private double sumProducts(List<Product> listaProductos, Customer randomCustomer)
        {
            double productsAddedUp = 0;
            double vat = 0;
            double retention = 0;

            foreach (Product product in listaProductos)
            {
                productsAddedUp += product.Price * int.Parse(product.Amount);
            }
            vat = (productsAddedUp * 16) / 100;
            retention = randomCustomer.Type == "Contribuyente especial" ? (vat * 75) / 100 : 0; 
            productsAddedUp = productsAddedUp + vat - retention;

            return productsAddedUp;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //"F" means for.
            List<Bill> billFAdd = JsonHandler.openJsonFile();
            addBillsTRegister(billFAdd);
            saveDataBase();
            renderTable();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            JsonHandler.saveJsonFile(register);
        }

        //"T" means to.
        public void addBillsTRegister(List<Bill> listOfBills)
        {
            if (listOfBills != null) 
            {
                if (register == null)
                {
                    register = listOfBills;
                }
                else
                {
                    foreach (Bill nBill in listOfBills)
                    {
                        register.Add(nBill);
                    }
                }
            }
        }

        //Oculta y/o muestra los botones de importar y exportar, dependiendo de si hay datos en register o no.
        public void hideImportExportButton()
        {
            if (register == null)
            {
                btnExport.Visible = false;
                btnImport.Visible = true;
            }
            else
            {
                btnExport.Visible = true;
                btnImport.Visible = false;
            }
        }

        private void dgvBillRegister_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvBillRegister.Columns["print"].Index)
                {
                    ToPdf(register[dgvBillRegister.CurrentCell.RowIndex]);
                }
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        //Crear el archivo para guardar la base de datos de registro de facturas.
        public void saveDataBase()
        {
            string fileName = FileNames.BillRegister;
            string jsonString = JsonSerializer.Serialize(register);
            File.WriteAllText(fileName, jsonString);
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
                        addCell(TablaBody, Math.Round(item.Price / factura.DivisaPrice, 2).ToString() + factura.Divisa, 1);
                        addCell(TablaBody, priceProduct.ToString() + factura.Divisa, 1);

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
                    addCell(TablaTotal, Math.Round(MontoExentoDelIVA / factura.DivisaPrice, 2).ToString() + factura.Divisa, 1);

                    addCellColor(TablaTotal, "Monto Total de la Base Imponible según Alicuota 16,00%:", 1);
                    addCell(TablaTotal, Math.Round(TotalSinIVA / factura.DivisaPrice, 2).ToString() + factura.Divisa, 1);

                    addCellColor(TablaTotal, "Monto Total del Impuesto según Alicuota 16, 00 %:", 1);
                    addCell(TablaTotal, Math.Round(PrecioFinal / factura.DivisaPrice, 2).ToString() + factura.Divisa, 1);


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
    }
}