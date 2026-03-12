using System;

namespace ConsoleApp35
{
    class Student
    {
        public double CalculateAverage(int m1, int m2, int m3)
        {
            return (m1 + m2 + m3) / 3.0;
        }

        public string GetGrade(double average)
        {
            if (average >= 80) return "A";
            else if (average >= 70) return "B";
            else return "C";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student();

            double avg = stu.CalculateAverage(80, 70, 90);
            string grade = stu.GetGrade(avg);

            Console.WriteLine($"Average = {avg}, Grade = {grade}");
            Console.ReadLine();
        }
    }
}