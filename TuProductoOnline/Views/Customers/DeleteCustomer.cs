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

namespace TuProductoOnline.Views.Customers
{
    public partial class DeleteCustomer : Form
    {
        private readonly int _id;

        private readonly Action<int> acceptFunction;
        public DeleteCustomer(int id, Action<int> callback)
        {
            InitializeComponent();
            _id = id;
            acceptFunction = callback;
        }

        private void DeleteCustomer_Load(object sender, EventArgs e)
        {
            Customer customer = Customer.GetCustomerById(_id);
            lblWarning.Text += $" {customer.Name} {customer.LastName}?";
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            acceptFunction(_id);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
