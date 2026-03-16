using System;

namespace SalaryCalculatorApp
{

    public class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }

        public Employee(string name, double baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
        }

        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }

    public class Manager : Employee
    {
        public Manager(string name, double baseSalary) : base(name, baseSalary) { }
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.20);
        }
    }
    public class Developer : Employee
    {
        public Developer(string name, double baseSalary) : base(name, baseSalary) { }
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.10);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double baseAmt = 50000;

            Employee emp1 = new Manager("Alice", baseAmt);
            Employee emp2 = new Developer("Bob", baseAmt);

            Console.WriteLine($"Manager Salary = {emp1.CalculateSalary()}");
            Console.WriteLine($"Developer Salary = {emp2.CalculateSalary()}");

            Console.ReadLine();
        }
    }
}