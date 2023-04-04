using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuProductoOnline
{
    public class Hardware: Product
    {
        // ---------------- Attributes ----------------
        private string _dimensions;

        // ---------------- Constructor ----------------
        public Hardware(string name, double price, string brand, string description, string dimensions) : base(name, price, brand, description)
        {
            _dimensions = dimensions;
        }

        // ---------------- Getters & Setters ----------------
        public string Dimensions { get { return _dimensions; } set { _dimensions = value; } }
    }
}
