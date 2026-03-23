using System;

namespace Problem3_Level1
{
    class Program
    {
        static (decimal SalesAmount, int Rating) GetPerformanceData(decimal salesAmount, int rating)
        {
            return (salesAmount, rating);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter Employee Name: ");
            string employeeName = Console.ReadLine();

            Console.Write("Enter Monthly Sales Amount: ");
            bool isSalesValid = decimal.TryParse(Console.ReadLine(), out decimal salesAmount);

            Console.Write("Enter Customer Feedback Rating (1-5): ");
            bool isRatingValid = int.TryParse(Console.ReadLine(), out int rating);

            if (!isSalesValid || !isRatingValid || rating < 1 || rating > 5)
            {
                Console.WriteLine("Invalid input. Please enter valid numeric values.");
                Console.ReadLine();
                return;
            }

            var performanceData = GetPerformanceData(salesAmount, rating);

            string performanceCategory = performanceData switch
            {
                ( >= 100000, >= 4) => "High Performer",
                ( >= 50000, >= 3) => "Average Performer",
                _ => "Needs Improvement"
            };

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Employee Name: " + employeeName);
            Console.WriteLine("Sales Amount: " + performanceData.SalesAmount);
            Console.WriteLine("Rating: " + performanceData.Rating);
            Console.WriteLine("Performance: " + performanceCategory);

            Console.ReadLine();
        }
    }
}