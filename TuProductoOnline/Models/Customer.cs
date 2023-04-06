using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuProductoOnline.Models
{
    class Customer
    {
        private int _code = 1;
        private string _name;
        private string _last_name;
        private string _document;
        private string _phone_number;
        private string _direction;
        private string _email;
        private string _type;

        public Customer()
        {

        }
        public Customer(string name, string last_name, string document,string phone_number,string direction, string email, string type)
        {
            _name = name;
            _last_name = last_name;
            _document = document;
            _phone_number = phone_number;
            _direction = direction;
            _email = email;
            _type = type;
        }

        public int Code { get { return _code; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string LastName { get { return _last_name; } set { _last_name = value; } }
        public string Document { get { return _document; } set { _document = value; } }
        public string PhoneNumber { get { return _phone_number; } set { _phone_number = value; } }
        public string Direction { get { return _direction; } set { _direction = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public void IncrementarCode()
        {
            _code++;
        }
    }
}
