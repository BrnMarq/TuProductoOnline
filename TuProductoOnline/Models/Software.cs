using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuProductoOnline
{
    public class Software: Product
    {
        private string _license;

        // ---------------- Constructor ----------------
        public Software(string name, double price, string brand, string description, string license) : base(name, price, brand, description)
        {
            _license = license;
        }

        // ---------------- Getters & Setters ----------------
        public string License { get { return _license; } set { _license = value; } }
    }
}
