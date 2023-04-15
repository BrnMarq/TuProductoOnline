using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProductoOnline.Utils;

namespace TuProductoOnline
{
    public partial class Edit_Id_Verification : Form
    {
        private int _id;
        public int Id { get { return _id; } set { _id = value; } }

        public Edit_Id_Verification()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(txtCode.Text);
            this.Close();
        }
        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
            Validar.Tab_Enter(e);
        }
        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void Edit_Id_Verification_Load(object sender, EventArgs e)
        {

        }
    }
}
