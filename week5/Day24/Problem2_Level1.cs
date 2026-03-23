using System;
using System.IO;

namespace Problem2_Level1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter folder path: ");
            string folderPath = Console.ReadLine();

            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("Invalid directory path.");
                    Console.ReadLine();
                    return;
                }

                string[] files = Directory.GetFiles(folderPath);
                int count = 0;

                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    Console.WriteLine("File Name       : " + fi.Name);
                    Console.WriteLine("File Size       : " + fi.Length + " bytes");
                    Console.WriteLine("Creation Date   : " + fi.CreationTime);
                    Console.WriteLine("-----------------------------------");
                    count++;
                }

                Console.WriteLine("Total Files: " + count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}