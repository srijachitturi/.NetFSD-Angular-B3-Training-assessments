using System;
using System.Threading.Tasks;

namespace ConcurrentReportApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Task task1 = Task.Run(() => GenerateSalesReport());
            Task task2 = Task.Run(() => GenerateInventoryReport());
            Task task3 = Task.Run(() => GenerateCustomerReport());

            await Task.WhenAll(task1, task2, task3);

            Console.WriteLine("All reports are completed.");
            Console.ReadLine();
        }

        static void GenerateSalesReport()
        {
            Console.WriteLine("Sales Report started.");
            Task.Delay(2000).Wait();
            Console.WriteLine("Sales Report finished.");
        }

        static void GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report started.");
            Task.Delay(3000).Wait();
            Console.WriteLine("Inventory Report finished.");
        }

        static void GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report started.");
            Task.Delay(2500).Wait();
            Console.WriteLine("Customer Report finished.");
        }
    }
}