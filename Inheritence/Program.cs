using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using System.Diagnostics.Metrics;

namespace Inheritence;
class Program { 

    public static void Main(string[] args)
    {
        //Read the file as sw
        using (StreamReader sw = new StreamReader(@"..\..\..\employees.txt"))
        {
            //Set up variables and lists
            string line;
            List<Employee> employees = new List<Employee>();
            //loop through the file until line == null
            while ((line = sw.ReadLine()) != null)
            {
                //split the line into its attributes
                string[] strings = line.Split(":");
                //get the first number of the id to determine what kind of employee. Create the appropriate employee object
                int tempID = (int)char.GetNumericValue(strings[0][0]);

                //Salary
                if (tempID <= 4)
                {
                    Salaried newSalaried = new Salaried(strings[0], strings[1], strings[2], strings[3], long.Parse(strings[4]), strings[5], strings[6], double.Parse(strings[7]));
                    employees.Add(newSalaried);
                }
                //Wage
                else if (tempID <= 7)
                {
                    Wages newWages = new Wages(strings[0], strings[1], strings[2], strings[3], long.Parse(strings[4]), strings[5], strings[6], double.Parse(strings[7]), double.Parse(strings[8]));
                    employees.Add(newWages);
                }
                //Part-Time
                else
                {
                    PartTime newPartTime = new PartTime(strings[0], strings[1], strings[2], strings[3], long.Parse(strings[4]), strings[5], strings[6], double.Parse(strings[7]), double.Parse(strings[8]));
                    employees.Add(newPartTime);
                }
            }


            double averagePay = averageWeeklyPay(employees);
            Console.WriteLine(String.Format("Average weekly pay of all employess is: {0:C2}", averagePay));
            Wages highestWage = highestWagePay(employees);
            Console.WriteLine(String.Format("Highest payed Wage Employess is: {0} making {1:C2}", highestWage.Name, highestWage.GetPay()));
            Salaried lowestSalary = lowestSalaryPay(employees);
            Console.WriteLine(String.Format("Lowest payed Salary Employess is: {0} making {1:C2}", lowestSalary.Name, lowestSalary.Salary));
            percentageEmployess(employees);

        }
        Console.ReadKey();
    }
    private static double averageWeeklyPay(List<Employee> employees)
    {
        double sum = 0;
        int count = 0;
        foreach (Employee employee in employees)
        {
            count++;
            //Find out what kind of employee 
            //Add that employees weekly pay to the sum
            if (employee is Salaried tempSalary)
            {
                sum += tempSalary.GetPay();
            }
            else if (employee is Wages tempWages)
            {
                sum += tempWages.GetPay();
            }
            else if (employee is PartTime tempPartTime)
            {
                sum += tempPartTime.GetPay();
            }
        }
        //return the weekly sum pay divided by the ammount of employees
        return sum / count;
    }
    private static Wages highestWagePay(List<Employee> employees)
    {
        Wages highest = new Wages();
        foreach (Employee employee in employees)
        {
            //if the employee is a wage employee
            if (employee is Wages wageEmployee)
            {
                //if the new wage employee has a higher pay that the previous highest
                if (wageEmployee.GetPay() > highest.GetPay())
                {
                    //this employee becomes the new highest
                    highest = wageEmployee;
                }
            }
        }
        return highest;
    }

    private static Salaried lowestSalaryPay(List<Employee> employees)
    {
        bool first = true;
        Salaried lowest = new Salaried();
        foreach (Employee employee in employees)
        {
            if (employee is Salaried salariedEmployee)
            {
                //if this employee is the first salaried employee
                if (first)
                {
                    //set this employee to be the lowest
                    lowest = salariedEmployee;
                    first = false;
                }
                //if this employee has a lower pay than the current lowest
                else if (lowest.GetPay() > salariedEmployee.GetPay())
                {
                    //this employee becomes the new lowest
                    lowest = salariedEmployee;
                }
            }
        }
        return lowest;
    }

    private static void percentageEmployess(List<Employee> employees)
    {
        //count all the employees, and count each kind of employee
        double fullCount = 0;
        double salaryCount = 0;
        double wageCount = 0;
        double partTimeCount = 0;
        foreach (Employee employee in employees)
        {
            fullCount++;
            if (employee is Salaried tempSalary)
            {
                salaryCount++;
            }
            else if (employee is Wages tempWage)
            {
                wageCount++;
            }
            else if (employee is PartTime tempPartTime)
            {
                partTimeCount++;
            }
        }
        Console.WriteLine(String.Format("Out of {0} employees\n{1:P2} are Salaried Employees\n{2:P2} are Wage Employees\n{3:P2} are Part-Time Empolyees", fullCount, salaryCount / fullCount, wageCount / fullCount, partTimeCount / fullCount));
    }
}
