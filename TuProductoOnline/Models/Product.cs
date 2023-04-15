using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuProductoOnline.Utils;
using TuProductoOnline.Consts;

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
        private string _amount = "Amount";
        private bool _deleted = false;

        private static List<Product> _products;

        // ---------------- Constructor ----------------

        public Product()
        {
    
        }

        public Product(string name, double price, string brand, string description, string type)
        {
            int id = DbHandler.GetNewId(FileNames.ProductsId);

            _id = id;
            _name = name;
            _price = price;
            _brand = brand;
            _description = description;
            _type = type;

            GetProducts();

            List<string> values = new List<string> {
                id.ToString(),
                name,
                price.ToString(),
                brand,
                description,
                type,
                "false",
            };
            DbHandler.EscribirCSV(FileNames.Products, values);

            _products.Add(this);
        }

        public Product(List<string> productValues)
        {
            _id = int.Parse(productValues[0]);
            _name = productValues[1];
            _price = Convert.ToDouble(productValues[2]);
            _brand = productValues[3];
            _description = productValues[4];
            _type = productValues[5];
            _deleted = bool.Parse(productValues[6]);
        }

        public Product(int id, double price, string Amount, string name)
        {
            _name = name;
            _price = price;
            _id = id;
            _amount = Amount;

        }

        // ---------------- Getters & Setters ----------------
        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public double Price { get { return _price; } set { _price = value; } }
        public string Brand { get { return _brand; } set { _brand = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public string Amount { get { return _amount; } set { _amount = value; } }
        public bool Deleted { get { return _deleted; } set { _deleted = value; } }

        public static List<Product> GetProducts()
        {
            if (_products != null) return _products;

            _products = new List<Product>();
            List<List<string>> entries = DbHandler.LeerCSV(FileNames.Products);
            foreach (List<string> entry in entries)
            {
                Product product = new Product(entry);
                _products.Add(product);
            }

            return _products;
        }

        public static Product GetProductById(int id)
        {
            List<Product> products = GetProducts();
            Product product = products.Find(targetUser => targetUser.Id == id);
            return product;
        }

        public static void UpdateProduct(int id, List<string> productValues)
        {
            Product product = GetProductById(id);
            product.Name = productValues[1];
            product.Price = Convert.ToDouble(productValues[2]);
            product.Brand = productValues[3];
            product.Description = productValues[4];
            product.Type = productValues[5];
            product.Deleted = bool.Parse(productValues[6]); 

            DbHandler.EditCSV(FileNames.Products, id.ToString(), productValues);

        }
    }
}
