using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_P05_Team04
{
    class Sides:Product
    {
        public Sides() { }
        public Sides(string n, double p) : base(n, p) { }

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
