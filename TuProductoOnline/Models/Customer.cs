using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuProductoOnline.Utils;
using TuProductoOnline.Consts;

namespace TuProductoOnline.Models
{
    class Customer
    {
        private int _code;
        private string _name;
        private string _last_name;
        private string _document;
        private string _phone_number;
        private string _address;
        private string _email;
        private string _type;

        private static List<Customer> customers;

        public Customer(int code, string name, string last_name, string document, string phone_number, string address, string email, string type)
        {
            _code = code;
            _name = name;
            _last_name = last_name;
            _document = document;
            _phone_number = phone_number;
            _address = address;
            _email = email;
            _type = type;

        }
        public Customer(string name, string last_name, string document,string phone_number,string address, string email, string type)
        {
            int code = DbHandler.GetNewId(FileNames.CustomersId);

            _code = code;
            _name = name;
            _last_name = last_name;
            _document = document;
            _phone_number = phone_number;
            _address = address;
            _email = email;
            _type = type;

            List<string> values = new List<string> {
                code.ToString(),
                name,
                last_name,
                document,
                phone_number,
                address,
                email,
                type,
            };

            DbHandler.EscribirCSV(FileNames.Customers, values);

            GetCustomers();
            customers.Add(this);
        }

        

        public int Code { get { return _code; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string LastName { get { return _last_name; } set { _last_name = value; } }
        public string Document { get { return _document; } set { _document = value; } }
        public string PhoneNumber { get { return _phone_number; } set { _phone_number = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Type { get { return _type; } set { _type = value; } }

        public static List<Customer> GetCustomers()
        {
            if (customers != null) return customers;

            customers = new List<Customer>();
            List<List<string>> entries = DbHandler.LeerCSV(FileNames.Customers);
            foreach (List<string> entry in entries)
            {
                Customer customer = new Customer(int.Parse(entry[0]), entry[1], entry[2], entry[3], entry[4], entry[5], entry[6], entry[7]);
                customers.Add(customer);
            }

            return customers;
        }
    }
}
