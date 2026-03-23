using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncFileLoggerApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Task t1 = WriteLogAsync("Application started");
            Task t2 = WriteLogAsync("User logged in");
            Task t3 = WriteLogAsync("Process completed");

            Console.WriteLine("Logging in progress...");

            await Task.WhenAll(t1, t2, t3);

            Console.WriteLine("All logs written.");
            Console.ReadLine();
        }

        static async Task WriteLogAsync(string message)
        {
            await Task.Delay(1000);

            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                await writer.WriteLineAsync(message);
            }

            Console.WriteLine(message);
        }
    }
}