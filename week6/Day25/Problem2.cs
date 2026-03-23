using System;

namespace DiscountCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Discount Percentage: ");
            double discount = Convert.ToDouble(Console.ReadLine());

            double finalPrice = price - (price * discount / 100);

            Console.WriteLine("Product Name: " + productName);
            Console.WriteLine("Product Price: " + price);
            Console.WriteLine("Discount Percentage: " + discount);
            Console.WriteLine("Final Price: " + finalPrice);

            Console.ReadLine();
        }
    }
}