using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_P05_Team04
{
    abstract class Product
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public Product() { }
        public Product(string n, double p)
        {
            Name = n;
            Price = p;
        }

        public abstract double GetPrice();

        public override string ToString()
        {
            return Name + " \n" + "$" + Price.ToString("0.00") + "\n";
        }
    }
}
