using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        double salary = double.Parse(Console.ReadLine());

        Console.Write("Enter Experience: ");
        int experience = int.Parse(Console.ReadLine());

        double bonusRate;

        if (experience < 2)
            bonusRate = 0.05;
        else if (experience <= 5)
            bonusRate = 0.10;
        else
            bonusRate = 0.15;

        double bonus = (salary > 0) ? (salary * bonusRate) : 0;

        double finalSalary = salary + bonus;

        Console.WriteLine($"Employee: {name}");
        Console.WriteLine($"Bonus: {bonus}");
        Console.WriteLine($"Final Salary: {finalSalary}");

        Console.ReadLine();
    }
}