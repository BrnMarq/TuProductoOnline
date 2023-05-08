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
using System.Runtime.InteropServices;

namespace TuProductoOnline.Views.BillRegister
{
    public partial class BillingRegistercs : Form
    {
        int acum = 1;
        private bool Buscar = false;
        private bool Ascendente = true;
        private List<Bill> globalRegister = new List<Bill>();
        private List<Bill> filterRegister;
        private List<Bill> Ordenado;
        private int registerForPage = 25;
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
            lblPageNum.Text = "1";
            fillRegisters();
            VerifyButtons();
            //renderTable();
        }

        private void renderTable()
        {
            hideImportExportButton();
            dgvBillRegister.Rows.Clear();
            dgvBillRegister.Refresh();
            if (globalRegister != null)
            {
                foreach (Bill billn in globalRegister)
                {
                    dgvBillRegister.Rows.Add(billn.BillId, billn.Fecha, billn.Cajero, sumProducts(billn.ListaProductos, billn.Cliente));
                }
            }
        }

        public void renderTable(List<Bill> registersN)
        {
            hideImportExportButton();
            dgvBillRegister.Rows.Clear();
            dgvBillRegister.Refresh();
            foreach (Bill r in registersN)
            {
                dgvBillRegister.Rows.Add(r.BillId, r.Fecha, r.Cajero, sumProducts(r.ListaProductos, r.Cliente));
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
            VerifyButtons();
            //renderTable(Paginar(acum, billFAdd));
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            JsonHandler.saveJsonFile(globalRegister);
        }

        //"T" means to.
        public void addBillsTRegister(List<Bill> listOfBills)
        {
            if (listOfBills != null) 
            {
                if (globalRegister == null)
                {
                    globalRegister = listOfBills;
                }
                else
                {
                    foreach (Bill nBill in listOfBills)
                    {
                        globalRegister.Add(nBill);
                    }
                }
            }
        }

        //Oculta y/o muestra los botones de importar y exportar, dependiendo de si hay datos en register o no.
        public void hideImportExportButton()
        {
            if (globalRegister.Count == 0)
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
            if (e.ColumnIndex == dgvBillRegister.Columns["print"].Index && e.RowIndex != -1)
            {
                try
                {
                    if (e.ColumnIndex == dgvBillRegister.Columns["print"].Index)
                    {
                        ToPdf(globalRegister[dgvBillRegister.CurrentCell.RowIndex]);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {

                }
            }
        }

        //Crear el archivo para guardar la base de datos de registro de facturas.
        public void saveDataBase()
        {
            string fileName = FileNames.BillRegister;
            string jsonString = JsonSerializer.Serialize(globalRegister);
            File.WriteAllText(fileName, jsonString);
        }

        void ToPdf(Bill factura)
        {
            SaveFileDialog guardarFactura = new SaveFileDialog();
            guardarFactura.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss");
            guardarFactura.DefaultExt = ".pdf";
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
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@REASON", factura.Cliente.Name + " " + factura.Cliente.LastName);
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@ADDRES", factura.Cliente.Address);
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@PHONE", factura.Cliente.PhoneNumber);
            FacturaHeader_Texto = FacturaHeader_Texto.Replace("@IVA", "16 %");

            try
            {


                if (guardarFactura.ShowDialog() == DialogResult.OK)
                {

                    if (File.Exists(guardarFactura.FileName))
                    {

                        File.Delete(guardarFactura.FileName);
                        EscribirArchivoPdf(guardarFactura, FacturaHeader_Texto, factura);
                    }
                    else
                    {

                        EscribirArchivoPdf(guardarFactura, FacturaHeader_Texto, factura);
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar el archivo.");
                throw;
            }


        }

        private void EscribirArchivoPdf(SaveFileDialog guardarFactura, string FacturaHeader_Texto, Bill factura)
        {
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
                    string PrecioUnitario = Math.Round(item.Price / factura.DivisaPrice, 2).ToString() + factura.Divisa;
                    string PrecioSumado = Math.Round(priceProduct / factura.DivisaPrice, 2).ToString() + factura.Divisa;

                    addCell(TablaBody, item.Amount, 1);
                    addCell(TablaBody, item.Name, 1);
                    addCell(TablaBody, item.Description, 1);
                    addCell(TablaBody, iva.ToString(), 1);
                    addCell(TablaBody, PrecioUnitario, 1);
                    addCell(TablaBody, PrecioSumado, 1);

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

                string aux = Math.Round(MontoExentoDelIVA / factura.DivisaPrice, 2).ToString() + factura.Divisa;
                string aux1 = Math.Round(TotalSinIVA / factura.DivisaPrice, 2).ToString() + factura.Divisa;
                string aux2 = Math.Round(PrecioFinal / factura.DivisaPrice, 2).ToString() + factura.Divisa;

                addCellColor(TablaTotal, "Monto Total Exento o Exonerado del IVA:", 1);
                addCell(TablaTotal, aux, 1);

                addCellColor(TablaTotal, "Monto Total de la Base Imponible según Alicuota 16,00%:", 1);
                addCell(TablaTotal, aux1, 1);

                addCellColor(TablaTotal, "Monto Total del Impuesto según Alicuota 16, 00 %:", 1);
                addCell(TablaTotal, aux2, 1);


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

        public void OrdenarGridAscendente(DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex > 2) return;

            List<string> searchParams = new List<string> { "BillId", "Fecha", "Cajero" };
            string searchParam = searchParams[e.ColumnIndex];
            int pageNum = Convert.ToInt32(lblPageNum.Text);

            List<Bill> paginated = Paginar(pageNum, globalRegister);

            Ordenado = paginated.OrderBy(l => Searcher(l, searchParam)).ToList();

            renderTable(Ordenado);
        }
        public void OrdenarGridDescendente(DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex > 2) return;

            List<string> searchParams = new List<string> { "BillId", "Fecha", "Cajero" };
            string searchParam = searchParams[e.ColumnIndex];
            int pageNum = Convert.ToInt32(lblPageNum.Text);

            List<Bill> paginated = Paginar(pageNum, globalRegister);

            Ordenado = paginated.OrderByDescending(l => Searcher(l, searchParam)).ToList();

            renderTable(Ordenado);

        }

        private List<Bill> Paginar(int num, List<Bill> registersN)
        {
            var lista = registersN.Skip((num - 1) * registerForPage).Take(registerForPage).ToList();

            return lista;
        }

        public object Searcher(Bill registerN, string searchParam)
        {
            return registerN.GetType().GetProperty(searchParam).GetValue(registerN, null);
        }

        private void VerifyButtons()
        {
            int lastPage;
            if (acum == 1)
            {
                btnprimero.Enabled = false;
                btnantes.Enabled = false;
            }
            if (!Buscar)
            {
                botones(acum + 1, btn2, globalRegister);
                botones(acum + 2, btn3, globalRegister);
                botones(acum + 3, btn4, globalRegister);
                lastPage = LastPage(globalRegister);
                renderTable(Paginar(acum, globalRegister));
                if (btn2.Enabled == false)
                {
                    btnultimo.Enabled = false;
                    btnsiguiente.Enabled = false;
                }
                else
                {
                    btnultimo.Enabled = true;
                    btnsiguiente.Enabled = true;
                }
            }
            else
            {
                botones(acum + 1, btn2, filterRegister);
                botones(acum + 2, btn3, filterRegister);
                botones(acum + 3, btn4, filterRegister);
                lastPage = LastPage(filterRegister);
                renderTable(Paginar(acum, filterRegister));
                if (btn2.Enabled == false)
                {
                    btnultimo.Enabled = false;
                    btnsiguiente.Enabled = false;
                }
                else
                {
                    btnultimo.Enabled = true;
                    btnsiguiente.Enabled = true;
                }
            }
        }

        public void botones(int acum, Button btn, List<Bill> registersN)
        {
            int block = LastPage(registersN);
            if (acum > block)
            {
                btn.Enabled = false;
            }
            else
            {
                btn.Enabled = true;
            }
        }

        private int LastPage(List<Bill> billN)
        {
            float numClientes;
            numClientes = (float)(billN.ToList().Count) / registerForPage;

            double numPaginas = Math.Ceiling(numClientes);
            if (numPaginas < numClientes)
                numPaginas++;
            return (int)numPaginas;
        }

        private void fillRegisters()
        {
            try
            {
                string jsonString = File.ReadAllText(FileNames.BillRegister);
                try
                {
                    globalRegister = JsonSerializer.Deserialize<List<Bill>>(jsonString);
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
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string pattern = txtSearch.Text.ToLower();
            Buscar = true;

            if (pattern.Length != 0)
            {
                lblPageNum.Text = "1";
                acum = 1;
                btn1.Text = Convert.ToString(acum);
                btn2.Text = Convert.ToString(acum + 1);
                btn3.Text = Convert.ToString(acum + 2);
                btn4.Text = Convert.ToString(acum + 3);
                btnprimero.Enabled = false;
                btnantes.Enabled = false;
            }

            var filtrado = globalRegister.Where(i => i.BillId.ToString().StartsWith(pattern) || i.BillId.ToString().Contains(pattern)).ToList();
            filterRegister = filtrado;

            botones(acum + 1, btn2, filterRegister);
            botones(acum + 2, btn3, filterRegister);
            botones(acum + 3, btn4, filterRegister);

            if (btn2.Enabled == false)
            {
                btnultimo.Enabled = false;
                btnsiguiente.Enabled = false;
            }
            else
            {
                btnultimo.Enabled = true;
                btnsiguiente.Enabled = true;
            }

            renderTable(Paginar(Convert.ToInt32(lblPageNum.Text), filterRegister));
        }

        private void btnantes_Click(object sender, EventArgs e)
        {
            acum -= 1;
            lblPageNum.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnultimo.Enabled = true;
            btnsiguiente.Enabled = true;

            if (acum == 1)
            {
                btnprimero.Enabled = false;
                btnantes.Enabled = false;
            }

            SumarBotones();
            if (btn2.Enabled == false)
            {
                btnultimo.Enabled = false;
                btnsiguiente.Enabled = false;
            }
            else
            {
                btnultimo.Enabled = true;
                btnsiguiente.Enabled = true;
            }
        }
        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            acum += 1;
            lblPageNum.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = true;
            btnantes.Enabled = true;

            if (!Buscar)
            {
                if (acum == LastPage(globalRegister))
                {
                    btn2.Enabled = false;
                    btnultimo.Enabled = false;
                    btnsiguiente.Enabled = false;
                }
                renderTable(Paginar(acum, globalRegister));
                botones(acum + 2, btn3, globalRegister);
                botones(acum + 3, btn4, globalRegister);
            }
            else
            {
                if (acum == LastPage(filterRegister))
                {
                    btn2.Enabled = false;
                    btnultimo.Enabled = false;
                    btnsiguiente.Enabled = false;
                }
                renderTable(Paginar(acum, filterRegister));
                botones(acum + 2, btn3, filterRegister);
                botones(acum + 3, btn4, filterRegister);
            }

        }

        public void SumarBotones()
        {
            if (!Buscar)
            {
                renderTable(Paginar(acum, globalRegister));
                botones(acum + 1, btn2, globalRegister);
                botones(acum + 2, btn3, globalRegister);
                botones(acum + 3, btn4, globalRegister);
            }
            else
            {
                renderTable(Paginar(acum, filterRegister));
                botones(acum + 1, btn2, filterRegister);
                botones(acum + 2, btn3, filterRegister);
                botones(acum + 3, btn4, filterRegister);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btnsiguiente_Click(sender, e);
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            acum += 2;
            lblPageNum.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = true;
            btnantes.Enabled = true;

            SumarBotones();

            if (btn2.Enabled == false)
            {
                btnsiguiente.Enabled = false;
                btnultimo.Enabled = false;
            }
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            acum += 3;
            lblPageNum.Text = Convert.ToString(acum);
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = true;
            btnantes.Enabled = true;

            SumarBotones();
        }

        private void btnprimero_Click(object sender, EventArgs e)
        {
            lblPageNum.Text = "1";
            acum = 1;
            btn1.Text = Convert.ToString(acum);
            btn2.Text = Convert.ToString(acum + 1);
            btn3.Text = Convert.ToString(acum + 2);
            btn4.Text = Convert.ToString(acum + 3);
            btnprimero.Enabled = false;
            btnantes.Enabled = false;
            btnultimo.Enabled = true;
            btnsiguiente.Enabled = true;

            SumarBotones();
        }

        private void btnultimo_Click(object sender, EventArgs e)
        {
            int lastPage;
            if (!Buscar)
            {
                lastPage = LastPage(globalRegister);
                renderTable(Paginar(lastPage, globalRegister));
            }
            else
            {
                lastPage = LastPage(filterRegister);
                renderTable(Paginar(lastPage, filterRegister));
            }
            acum = lastPage;
            lblPageNum.Text = lastPage.ToString();
            btnultimo.Enabled = false;
            btnsiguiente.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btnprimero.Enabled = true;
            btnantes.Enabled = true;
            if (!Buscar)
            {
                btn1.Text = Convert.ToString(LastPage(globalRegister));
                btn2.Text = Convert.ToString(LastPage(globalRegister) + 1);
                btn3.Text = Convert.ToString(LastPage(globalRegister) + 2);
                btn4.Text = Convert.ToString(LastPage(globalRegister) + 3);
            }
            else
            {
                btn1.Text = Convert.ToString(LastPage(filterRegister));
                btn2.Text = Convert.ToString(LastPage(filterRegister) + 1);
                btn3.Text = Convert.ToString(LastPage(filterRegister) + 2);
                btn4.Text = Convert.ToString(LastPage(filterRegister) + 3);
            }
        }

        private void dgvCustomers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Ascendente)
                OrdenarGridDescendente(e);
            else
                OrdenarGridAscendente(e);
            Ascendente = !Ascendente;
        }
    }
}