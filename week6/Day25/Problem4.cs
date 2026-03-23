using System;
using System.Threading.Tasks;

namespace AsyncOrderProcessingApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Order processing started...");

            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();

            Console.WriteLine("Order processing completed.");
            Console.ReadLine();
        }

        static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("Verifying payment...");
            await Task.Delay(2000);
            Console.WriteLine("Payment verified.");
        }

        static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Checking inventory...");
            await Task.Delay(2000);
            Console.WriteLine("Inventory checked.");
        }

        static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Confirming order...");
            await Task.Delay(2000);
            Console.WriteLine("Order confirmed.");
        }
    }
}