using System;
using System.Diagnostics;

namespace OrderTracingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriterTraceListener listener = new TextWriterTraceListener("OrderTraceLog.txt");
            Trace.Listeners.Add(listener);
            Trace.AutoFlush = true;

            Trace.WriteLine("Order processing started.");

            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();

            Trace.WriteLine("Order processing completed.");

            Console.WriteLine("Trace log written to file.");
            Console.ReadLine();
        }

        static void ValidateOrder()
        {
            Console.WriteLine("Validate Order");
            Trace.TraceInformation("Validate Order");
        }

        static void ProcessPayment()
        {
            Console.WriteLine("Process Payment");
            Trace.TraceInformation("Process Payment");
        }

        static void UpdateInventory()
        {
            Console.WriteLine("Update Inventory");
            Trace.TraceInformation("Update Inventory");
        }

        static void GenerateInvoice()
        {
            Console.WriteLine("Generate Invoice");
            Trace.TraceInformation("Generate Invoice");
        }
    }
}