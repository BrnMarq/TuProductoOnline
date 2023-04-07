using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuProductoOnline
{
    public class Product
    {
        // ---------------- Attributes ----------------
        private int _id;
        private string _name;
        private double _price;
        private string _brand;
        private string _description;
        private string _type;

        // ---------------- Constructor ----------------
        public Product(string name, double price, string brand, string description, string type, int id)
        {
            _name = name;
            _price = price;
            _brand = brand;
            _description = description;
            _type = type;
            _id = id;
            
        }

        // ---------------- Getters & Setters ----------------
        public int Id { get { return _id; } }
        public string Name { get { return _name; } set { _name = value; } }
        public double Price { get { return _price; } set { _price = value; } }
        public string Brand { get { return _brand; } set { _brand = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public string Type { get { return _type; } }
    }
}
