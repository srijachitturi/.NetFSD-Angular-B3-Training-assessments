using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter First Number: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Second Number: ");
        double num2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Operator [ + - * / ]: ");
        char op = char.Parse(Console.ReadLine());

        double result = 0;

        switch (op)
        {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':

                if (num2 == 0)
                {
                    Console.WriteLine("Error: Cannot divide by zero.");
                    return;
                }
                result = num1 / num2;
                break;
            default:
                Console.WriteLine("Invalid Operation");
                return;
        }

        Console.WriteLine("Result: " + result);
        Console.ReadLine();
    }
}