using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritence
{
    public class Salaried : Employee
    {
        private double salary;
        public Salaried()
        {

        }
        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary) : base(id, name, address, phone, sin, dob, dept)
        {
            this.salary = salary;
        }

        public double Salary { get { return salary; } set {  salary = value; } }

        public double GetPay()
        {
            return salary;
        }
        public override string ToString() 
        {
            string output = base.ToString() + ":" + this.salary;
            return output;
        }
    }
}
