using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_P05_Team04
{
    class ValueMeal:Product
    {
        private DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        private DateTime endTime;
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public ValueMeal() { }
        public ValueMeal(string n, double p, DateTime s, DateTime e) : base(n, p)
        {
            StartTime = s;
            EndTime = e;
        }

        public override double GetPrice()
        {
            return Price += Price;
        }

        public bool IsAvailable()
        {
            bool ok;
            if (startTime.TimeOfDay <= DateTime.Now.TimeOfDay && endTime.TimeOfDay >= DateTime.Now.TimeOfDay)
            {
                ok = true;
            }
            else
                ok = false;
            return ok;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
