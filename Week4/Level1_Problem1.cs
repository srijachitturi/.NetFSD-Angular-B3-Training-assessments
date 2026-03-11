using System;

class Program
{
    static void Main()
    {

        Console.WriteLine("Enter Name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Marks: ");
        int marks = int.Parse(Console.ReadLine());

        if (marks < 0 || marks > 100)
        {
            Console.WriteLine("Invalid Marks. Please enter between 0-100.");
        }
        else
        {
            string grade;

            if (marks >= 90)
                grade = "A";
            else if (marks >= 75)
                grade = "B";
            else if (marks >= 50)
                grade = "C";
            else if (marks >= 35)
                grade = "D";
            else
                grade = "Fail";

            Console.WriteLine($"Student: {name}");
            Console.WriteLine($"Grade: {grade}");
        }

        Console.ReadLine();
    }
}