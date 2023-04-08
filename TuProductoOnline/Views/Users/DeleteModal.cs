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

namespace TuProductoOnline.Views.Users
{
    public partial class DeleteModal : Form
    {
        private readonly int _id;

        private readonly Action<int> acceptFunction;
        public DeleteModal(int id, Action<int> callback)
        {
            InitializeComponent();
            _id = id;
            acceptFunction = callback;
        }

        private void DeleteModal_Load(object sender, EventArgs e)
        {
            User user = User.GetUserById(_id);
            WarningText.Text += $" {user.FirstName} {user.LastName}?";
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            acceptFunction(_id);
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
