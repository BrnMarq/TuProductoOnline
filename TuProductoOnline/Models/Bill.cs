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
     class Bill : Customer
    {
        // -------- Atributos ---------
        private int _billId;
        private string _fecha;
        private string _cajero;

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


        //Metodos.

        //imprimir PDF

        ~Bill()
        {

        }


    }
}
