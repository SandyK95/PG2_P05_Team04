using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_P05_Team04
{
    class OrderItem
    {
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        //You cannot have two variables with the same name in your class
        //For one-to-one association no list should in your class
        // one-to-one assoication from OrderItem to MenuItem
        public OrderItem() { }
        public OrderItem(MenuItem M)
        {
            item = M;
        }

        private MenuItem item;
        public MenuItem Item
        {
            get { return item; }
            set { item = value; }
        }

        public void AddQty()
        {
            Quantity += Quantity;
        }

        public void RemoveQty()
        {
            Quantity = Quantity - 1;
        }
        public double GetItemTotalAmt()
        {
            return Quantity * Item.Price;
        }

        public override string ToString()
        {
            return Item.Name + " x" + Quantity + "\n$" + GetItemTotalAmt().ToString("0.00");
        }
    }
}
