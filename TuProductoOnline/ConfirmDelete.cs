using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuProductoOnline
{
    public partial class ConfirmDelete : Form
    {
        //Atributos

        private bool _clic = false;
        //Get y Set

        public bool Clic { get { return _clic; } set { _clic = value; } }
        
        public ConfirmDelete()
        {
            InitializeComponent();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Funcion que regresa al Form de Products si el boton de confirmar fue pulsado.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Clic = true;
            this.Close();
        }
    }
}
