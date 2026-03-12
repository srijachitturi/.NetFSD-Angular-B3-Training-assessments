using System;

namespace ConsoleApp4
{
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            int res1 = calc.Add(10, 5);
            int res2 = calc.Subtract(10, 5);

            Console.WriteLine($"Addition = {res1}, Subtraction = {res2}");
            Console.ReadLine();
        }
    }
}