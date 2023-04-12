using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TuProductoOnline.Utils;
using TuProductoOnline.Consts;
using System.Windows.Forms;
using TuProductoOnline.Views;

namespace TuProductoOnline.Models
{
    public class User
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _password;
        private string _role;
        private string _email;
        private string _phone;
        private string _address;
        private bool _deleted;

        private static User _activeUser;
        private static List<User> _users;

        public User(List<string> userValues)
        {
            _id = int.Parse(userValues[0]);
            _firstName = userValues[1];
            _lastName = userValues[2];
            _password = userValues[3];
            _role = userValues[4];
            _email = userValues[5];
            _phone = userValues[6];
            _address = userValues[7];
            _deleted = bool.Parse(userValues[8]);
        }

        public User(string firstName, string lastName, string password, string role = "member", string email = "", string phone = "", string address = "")
        {
            int id = DbHandler.GetNewId(FileNames.UsersId);

            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _password = password;
            _role = role;
            _email = email;
            _phone = phone;
            _address = address;
            _deleted = false;

            GetUsers();

            List<string> values = new List<string> {
                id.ToString(),
                firstName,
                lastName,
                password,
                role,
                email,
                phone,
                address,
                "false",
            };
            DbHandler.EscribirCSV(FileNames.Users, values);

            _users.Add(this);
        }

        // ---------------- Getters & Setters ----------------
        public int Id { get { return _id; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string Role { get { return _role; } set { _role = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public bool Deleted { get { return _deleted; } set { _deleted = value; } }
        public static User ActiveUser { get { return _activeUser; } }
        
        public static List<User> GetUsers()
        {
            if (_users != null) return _users;

            _users = new List<User>();
            List<List<string>> entries = DbHandler.LeerCSV(FileNames.Users);
            foreach (List<string> entry in entries)
            {
                User user = new User(entry);
                _users.Add(user);
            }

            return _users;
        }

        public static User GetUserById(int id)
        {
            List<User> users = GetUsers();
            User user = users.Find(targetUser => targetUser.Id == id);
            return user;
        }

        public static void UpdateUser(int id, List<string> userValues)
        {
            User user = GetUserById(id);
            user.FirstName = userValues[1];
            user.LastName = userValues[2];
            user.Password = userValues[3];
            user.Role = userValues[4];
            user.Email = userValues[5];
            user.Phone = userValues[6];
            user.Address = userValues[7];
            user.Deleted = bool.Parse(userValues[8]);

            DbHandler.EditCSV(FileNames.Users, id.ToString(), userValues);
            
        }

        public static void Login(User user)
        {
            _activeUser = user;
        }
    }
}
