using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuProductoOnline
{
    public class Software: Product
    {

        // ---------------- Constructor ----------------
        public Software(string name, double price, string brand, string description, string type) : base(name, price, brand, description, type)
        {
            
        }

    }
}
