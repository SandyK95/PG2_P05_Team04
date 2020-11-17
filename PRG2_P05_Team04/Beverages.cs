using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_P05_Team04
{
    class Beverages:Product
    {
        private double tradeIn;
        public double TradeIn { get; set; }

        public Beverages() { }
        public Beverages(string n, double p, double t) : base(n, p)
        {
            TradeIn = t;
        }

        public override double GetPrice()
        {
            return Price += Price;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
