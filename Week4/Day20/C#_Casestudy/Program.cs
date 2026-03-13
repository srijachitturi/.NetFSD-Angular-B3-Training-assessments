using System;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emp = new Employee("Marko Horvat", 4500m, 35);

            Console.WriteLine(emp.Salary);        // 4500

            emp.GiveRaise(15);                    // OK
            // emp.GiveRaise(40);                 // throws exception

            emp.FullName = "Marko Horvat Jr.";    // OK
            Console.WriteLine(emp.FullName);      // Marko Horvat Jr.
            Console.WriteLine(emp.Age);           // 35

            bool success = emp.DeductPenalty(3000);
            Console.WriteLine(success);           // true

            Console.ReadLine();
        }
    }
}