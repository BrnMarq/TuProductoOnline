using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuProductoOnline.Models
{
    internal class User
    {
        private int _id;
        private string _name;
        private string _email;
        private string _password;
        private string _phone;
        private string _address;
        private bool _deleted;

        public int Id { get { return _id; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public bool Deleted { get { return _deleted; } set { _deleted = value; } }

    }
}
