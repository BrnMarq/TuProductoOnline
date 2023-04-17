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
                register = JsonSerializer.Deserialize<List<Bill>>(jsonString);
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
                    dgvBillRegister.Rows.Add(billn.BillId, billn.Fecha, billn.Cajero, sumProducts(billn.ListaProductos));
                }
            }
        }

        private double sumProducts(List<Product> listaProductos)
        {
            double productsAddedUp = 0;

            foreach (Product product in listaProductos)
            {
                productsAddedUp += product.Price * int.Parse(product.Amount);
            }

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
            string FacturaHtlml_Texto = Properties.Resources.plantillaFactura.ToString();

            //Replace de la factura y otros calculos.

            //Empresa
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@NOMBREEMPRESA", "TuProductoOnline");
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@RAZONSOCIAL", "TuProductoOnline C.A.");
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@DOMICILIOFISCAL", "Caracas, Venezuela");
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@NUMERO", "0800-12345678");

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
            double TotalSinIVA = 0;
            if (factura.Cliente.Type == "Ordinario") { iva = 16; }

            foreach (var item in factura.ListaProductos)
            {
                double priceProduct = 0;
                priceProduct = item.Price * double.Parse(item.Amount);
                filas += "<tr>";
                filas += "<td>" + item.Amount + "</td>";
                filas += "<td>" + item.Name + "</td>";
                filas += "<td>" + iva.ToString() + " %" + "</td>";
                filas += "<td>" + item.Price + " Bs.S" + "</td>";
                filas += "<td>" + priceProduct.ToString() + " Bs.S" + "</td>";
                filas += "</tr>";
                Total += priceProduct;
                TotalSinIVA += item.Price * double.Parse(item.Amount);
            }

            //Calculos finales.

            double TotalDelIVA = Total * iva / 100;
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@Filas", filas);
            double MontoExentoDelIVA = 0;

            if (factura.Cliente.Type != "Ordinario")
            {
                MontoExentoDelIVA = (TotalDelIVA * 75 / 100);
            }

            double PrecioFinal = (TotalSinIVA + TotalDelIVA) - MontoExentoDelIVA;

            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@MONTO1", MontoExentoDelIVA.ToString());
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@MONTO2", TotalSinIVA.ToString());
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@MONTO3", TotalDelIVA.ToString());
            FacturaHtlml_Texto = FacturaHtlml_Texto.Replace("@MONTOTOTAL", PrecioFinal.ToString());


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

                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.LogoCompleto, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(200, 120);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(facturaPdf.LeftMargin, facturaPdf.Top - 60);
                    facturaPdf.Add(img);


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