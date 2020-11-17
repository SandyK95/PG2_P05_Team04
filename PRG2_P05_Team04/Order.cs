using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_P05_Team04
{
    class Order
    {
        private int OrderNo;
        public int orderNo
        {
            get { return OrderNo; }
            set { OrderNo = value; }
        }

        private List<OrderItem> itemList = new List<OrderItem>();
        public List<OrderItem> ItemList { get; set; }

        public Order() { }
        public void Add(OrderItem item)
        {
            ItemList.Add(item);
        }

        public void Remove(OrderItem item)
        {
            ItemList.Remove(item);
        }

        public double GetTotalAmt()
        {
            double v = 0.00;
            foreach (OrderItem o in ItemList)
            {
                v += o.GetItemTotalAmt();
            }
            return v;
        }

        public override string ToString()
        {
            string receipt = "";
            orderNo += 1;
            receipt = "Tom's Cafe \n\nReceipt #" + orderNo.ToString("00000") + "\n";


            receipt += DateTime.Now.ToString() + "\n================================";

            foreach (OrderItem o in ItemList)
            {
                if (o.Item.ProductList.Count() == 0)
                {
                    receipt += "\n" + o.Quantity + "x\t" + o.Item.Name + "\t\t\t$" + o.GetItemTotalAmt().ToString("0.00");

                }
                else
                {
                    receipt += "\n" + o.Quantity + "x\t" + o.Item.Name + "\t$" + o.GetItemTotalAmt().ToString("0.00");
                }
            }
            receipt += "\n--------------------------------------------------------";
            receipt += "\n" + "Total:\t\t\t\t\t$" + GetTotalAmt().ToString("0.00");

            return receipt;
        }
    }
}
