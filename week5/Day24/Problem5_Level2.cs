using System;
using System.IO;

namespace Problem5_Level2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 1. Retrieve all system drives
                DriveInfo[] drives = DriveInfo.GetDrives();

                // Loop through drives
                foreach (DriveInfo drive in drives)
                {
                    // Ensure drive is ready
                    if (drive.IsReady)
                    {
                        Console.WriteLine("Drive Name           : " + drive.Name);
                        Console.WriteLine("Drive Type           : " + drive.DriveType);
                        Console.WriteLine("Total Size           : " + drive.TotalSize);
                        Console.WriteLine("Available Free Space : " + drive.AvailableFreeSpace);

                        // Calculate free space %
                        double freePercent =
                            (double)drive.AvailableFreeSpace / drive.TotalSize * 100;

                        // Warning if below 15%
                        if (freePercent < 15)
                        {
                            Console.WriteLine("WARNING: Low disk space!");
                        }

                        Console.WriteLine("-----------------------------------");
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