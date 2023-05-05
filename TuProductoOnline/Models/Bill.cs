using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TuProductoOnline.Consts;
using TuProductoOnline.Utils;
using TuProductoOnline.Views.Users;

namespace TuProductoOnline.Models
{
     public class Bill
     {
        // -------- Atributos ---------
        private int _billId;
        private string _cajero;
        private string _fecha;
        private string _fechadevencimiento;
        private string _divisa;
        private double _divisaPrice;


        public Customer Cliente { get; set; }
        public List<Product> ListaProductos { get; set; }

        //--------- constructores -----------

        public Bill()
        {

        }

        public Bill(int BillId, string Fecha, string Cajero)
        {
            _billId = BillId;
            _fecha = Fecha;
            _cajero = Cajero;

        }
         //--------------- Destructores -----------
        public Bill(string Cajero)
        {
            
            _cajero = Cajero;

        }
        // getters y setters.

        public int BillId { get { return _billId; } set { _billId = value; } }
        public string Fecha { get { return _fecha; } set { _fecha = value; } }
        public string Cajero { get { return _cajero; } set { _cajero = value; } }
        public string Divisa { get { return _divisa; } set { _divisa = value; } }
        public double DivisaPrice { get { return _divisaPrice; } set { _divisaPrice = value; } }
        public string FechaDeVencimiento { get { return _fechadevencimiento; } set { _fechadevencimiento = value; } }

        ~Bill()
        {

        }


    }
}
