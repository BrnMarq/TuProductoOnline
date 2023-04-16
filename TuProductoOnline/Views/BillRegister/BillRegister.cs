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
    }
}