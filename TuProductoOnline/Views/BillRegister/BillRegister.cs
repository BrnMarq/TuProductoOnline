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
            string jsonString = File.ReadAllText(FileNames.BillRegister);
            register = JsonSerializer.Deserialize<List<Bill>>(jsonString);
            renderTable();
        }

        private void renderTable()
        {
            dgvBillRegister.Rows.Clear();
            dgvBillRegister.Refresh();
            foreach (Bill billn in register)
            {
                dgvBillRegister.Rows.Add(billn.BillId, billn.Fecha, billn.Cajero, sumProducts(billn.ListaProductos));
            }
        }

        private double sumProducts(List<Product> listaProductos)
        {
            double productsAddedUp = 0;

            foreach (Product product in listaProductos)
            {
                productsAddedUp += product.Price;
            }

            return productsAddedUp;
        }
    }
}