using System;
using System.IO;

namespace Problem4_Level2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter root directory path: ");
            string rootPath = Console.ReadLine();

            try
            {
                if (!Directory.Exists(rootPath))
                {
                    Console.WriteLine("Invalid directory path.");
                    Console.ReadLine();
                    return;
                }

                DirectoryInfo rootDir = new DirectoryInfo(rootPath);
                DirectoryInfo[] subDirs = rootDir.GetDirectories();

                if (subDirs.Length == 0)
                {
                    Console.WriteLine("No subdirectories found.");
                }
                else
                {
                    foreach (DirectoryInfo dir in subDirs)
                    {
                        FileInfo[] files = dir.GetFiles();

                        Console.WriteLine("Folder Name : " + dir.Name);
                        Console.WriteLine("File Count  : " + files.Length);
                        Console.WriteLine("--------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}