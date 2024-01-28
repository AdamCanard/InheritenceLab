using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritence
{
    public class Wages : Employee
    {
        private double rate;
        private double hours;
        public Wages()
        {

        }
        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.rate = rate;
            this.hours = hours;
        }

        public double Rate { get { return rate; } set { rate = value; } }
        public double Hours { get { return hours; } set { hours = value; } }

        public double GetPay()
        {
            //if they worked more than 40 hours
            if (this.hours > 40)
            {
                //calculate their pay for the first 40 hours
                double pay = 40 * this.rate;
                //calulate there overtime pay
                pay += (rate * 1.5) * (this.hours - 40);
                return pay;
            }
            //if they worked 40 hours or less
            else
            {
                double pay = this.hours * this.rate;
                return pay;
            }
        }

        public override string ToString()
        {
            string output = base.ToString() + ":" + this.rate + ":" + this.hours;
            return output;
        }

    }
}
