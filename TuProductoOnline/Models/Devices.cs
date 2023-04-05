using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuProductoOnline
{
    public class Devices: Product
    {
        // ---------------- Attributes ----------------
        private string _model;

        // ---------------- Constructor ----------------
        public Devices(string name, double price, string brand, string description, string model) : base(name, price, brand, description)
        {
            _model = model;
        }

        // ---------------- Getters & Setters ----------------
        public string Model { get { return _model; } set { _model = value; } }
    }
}
