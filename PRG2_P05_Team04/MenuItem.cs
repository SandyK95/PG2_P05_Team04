using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_P05_Team04
{
    class MenuItem
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

        private MenuItem item;
        public MenuItem Item
        {
            get { return item; }
            set { item = value; }
        }

        //One-to-many association from MenuItem to Product
        private List<Product> productList = new List<Product>();
        public List<Product> ProductList
        {
            get { return productList; }
            set { productList = value; }
        }

        public MenuItem() { }
        public MenuItem(string n, double p)
        {
            Name = n;
            Price = p;
        }
        public double GetTotalPrice()
        {
            return Price += Price;
        }

        public override string ToString()
        {
            return Name + " \n" + "$" + Price.ToString("0.00");
        }
    }
}
