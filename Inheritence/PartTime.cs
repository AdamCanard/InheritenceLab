using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritence
{
    public class PartTime : Employee
    {
        private double rate;
        private double hours;
        public PartTime()
        {

        }
        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.rate = rate;
            this.hours = hours;
        }
        public double Rate { get { return rate; } set {  rate = value; } }
        public double Hours { get { return hours; } set { hours = value; } }
        
        public double GetPay()
        {
            return rate * hours;
        }

        public override string ToString() {
            string output = base.ToString() + ":" + this.rate + ":" + this.hours;
            return output;
        }

    }
}
