using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exercise_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the path of the directory to search: ");
            string dirPath = Console.ReadLine();

            // Check directory is present
            if (Directory.Exists(dirPath))
            {
                string[] files = Directory.GetFiles(dirPath); // return names of files including path

                // Check files are present
                if (files.Length != 0)
                {
                    // 1. Number of text files in the directory
                    int totalTextFiles = files.Count(f => Path.GetExtension(f) == ".txt");
                    Console.WriteLine("\nNumber of text files in the directory: {0}", totalTextFiles);

                    // 2. Number of files per extension type
                    var filesByExt = files.GroupBy(f => Path.GetExtension(f)).Select(g => new { Extension = g.Key, Count = g.Count() });
                    Console.WriteLine("\nFiles by extension:");
                    foreach (var file in filesByExt) Console.WriteLine(" {0}: {1}", file.Extension, file.Count);

                    // 3. Top 5 largest files with their file size
                    var top5Files = files.OrderByDescending(f => new FileInfo(f).Length).Take(5).Select(f => new { Name = Path.GetFileName(f), Size = new FileInfo(f).Length });
                    Console.WriteLine("\nTop 5 largest files with their size:");
                    foreach (var file in top5Files) Console.WriteLine(" {0} having size {1} bytes", file.Name, file.Size);

                    // 4. File with maximum length
                    var maxLengthFile = files.OrderByDescending(f => new FileInfo(f).Length).First();
                    Console.WriteLine("\nFile with maximum size: \n {0} having size {1} bytes", Path.GetFileName(maxLengthFile), new FileInfo(maxLengthFile).Length);
                }

                else
                {
                    Console.WriteLine("No file is present in the given directory.");
                }
            }

            else
            {
                Console.WriteLine("The directory does not exist.");
            }
            Console.ReadLine();
        }
    }
}
