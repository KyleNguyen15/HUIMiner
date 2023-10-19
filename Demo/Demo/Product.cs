using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Product
    {
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public Product(string name, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
        }
        

    }
}
