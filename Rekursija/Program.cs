using System;
using System.Collections.Generic;
using System.IO;

namespace Rekursija
{
   
    class Program
    {
        
        private static long checkLocationSize(string dirPath)
        {
            long SizeOfTheFolder = CountSize(dirPath);
            var dirs = Directory.EnumerateDirectories(dirPath);
            foreach (string path in dirs)
            {
                SizeOfTheFolder += checkLocationSize(path);
            }
            return SizeOfTheFolder;
        }

        private static long CountSize(string dir)
        {
            long size = 0;
            var files = Directory.EnumerateFiles(dir);
            foreach (string file in files)
            {
                var info = new FileInfo(file);
                size += info.Length;
            }
            return size;

        }
        static void Main(string[] args)
        {
            string directoryPath = @"C:\temp\";
            var folderCount = checkLocationSize(directoryPath);
            var kylobites = folderCount / 1024;
            Console.WriteLine($"Kylobites: {kylobites}");
            if (kylobites >= 1024)
            {
                var megabytes = kylobites / 1024;
                Console.WriteLine($"Megabytes: {megabytes}");
                if (megabytes >= 1024)
                {
                    double diskSpace = Convert.ToDouble(megabytes);
                    var gygabites = diskSpace / 1000;
                    Console.WriteLine($"Gygabites: {gygabites}");
                }
            }
        }
    }
}
