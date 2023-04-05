using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuProductoOnline.Utils;
using TuProductoOnline.Consts;

namespace TuProductoOnline.Models
{
    internal class User
    {

        private int _id;
        private string _firstName;
        private string _lastName;
        private string _role;
        private string _email;
        private string _password;
        private string _phone;
        private string _address;
        private bool _deleted;

        public User(int id, string firstName, string lastName, string password, string role = "member", string email = "", string phone = "", string address = "")
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _role = role;
            _email = email;
            _phone = phone;
            _address = address;
            _password = password;
            _deleted = false;
    }

        // ---------------- Getters & Setters ----------------
        public int Id { get { return _id; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public bool Deleted { get { return _deleted; } set { _deleted = value; } }
        
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            List<List<string>> entries = DbHandler.LeerCSV(FileNames.Users);
            foreach (List<string> entry in entries)
            {
                User user = new User(int.Parse(entry[0]), entry[1], entry[2], entry[3], entry[4], entry[5], entry[6], entry[7]);
                users.Add(user);
            }
            return users;
        }
    }
}
