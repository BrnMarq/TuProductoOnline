using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuProductoOnline.Utils;
using TuProductoOnline.Consts;
using System.Windows.Forms;

namespace TuProductoOnline.Models
{
    public class Customer
    {
        private int _code;
        private string _name;
        private string _last_name;
        private string _document;
        private string _phone_number;
        private string _address;
        private string _email;
        private string _type;
        private bool _deleted;


        private static List<Customer> customers;

        public Customer()
        {

        }

        public Customer(List<string> customerValues)
        {
            _code = int.Parse(customerValues[0]);
            _name = customerValues[1];
            _last_name = customerValues[2];
            _document = customerValues[3];
            _phone_number = customerValues[4];
            _address = customerValues[5];
            _email = customerValues[6];
            _type = customerValues[7];
            _deleted = bool.Parse(customerValues[8]);
        }

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
            _deleted = false;

            List<string> values = new List<string> {
                code.ToString(),
                name,
                last_name,
                document,
                phone_number,
                address,
                email,
                type,
                "false",
            };

            DbHandler.EscribirCSV(FileNames.Customers, values);

            GetCustomers();
            customers.Add(this);
        }

        // ---------------- Getters & Setters ----------------
        public int Code { get { return _code; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string LastName { get { return _last_name; } set { _last_name = value; } }
        public string Document { get { return _document; } set { _document = value; } }
        public string PhoneNumber { get { return _phone_number; } set { _phone_number = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public bool Deleted { get { return _deleted; } set { _deleted = value; } }

        // --------------- Funcionalidades ------------------
        public static List<Customer> GetCustomers()
        {
            if (customers != null) return customers;

            customers = new List<Customer>();
            List<List<string>> entries = DbHandler.LeerCSV(FileNames.Customers);

            foreach (List<string> entry in entries)
            {
                if (entry[0] == "") return customers;
                Customer customer = new Customer(int.Parse(entry[0]), entry[1], entry[2], entry[3], entry[4], entry[5], entry[6], entry[7]);
                customers.Add(customer);
            }

            return customers;
        }

        public static Customer GetCustomerById(int id)
        {
            List<Customer> customers = GetCustomers();
            Customer customer = customers.Find(targetCustomer => targetCustomer.Code == id);
            return customer;
        }

        public static void UpdateCustomer(int id, List<string> customerValues)
        {
            Customer customer = GetCustomerById(id);
            customer.Name = customerValues[1];
            customer.LastName = customerValues[2];
            customer.Document = customerValues[3];
            customer.PhoneNumber = customerValues[4];
            customer.Address = customerValues[5];
            customer.Email = customerValues[6];
            customer.Type = customerValues[7];
            customer.Deleted = bool.Parse(customerValues[8]);

            DbHandler.EditCSV(FileNames.Customers, id.ToString(), customerValues);
        }
    }
}
