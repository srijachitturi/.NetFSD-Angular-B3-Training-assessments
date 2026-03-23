using System;
using System.IO;
using System.Text;

namespace Problem1_Level1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "messages.txt";

            try
            {
                while (true)
                {
                    Console.Write("Enter message: ");
                    string message = Console.ReadLine();

                    using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                    {
                        byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);
                        fs.Write(data, 0, data.Length);
                    }

                    Console.WriteLine("Message written successfully.");

                    Console.Write("Do you want to add another message? (yes/no): ");
                    string choice = Console.ReadLine();

                    if (choice.ToLower() != "yes")
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("File error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}