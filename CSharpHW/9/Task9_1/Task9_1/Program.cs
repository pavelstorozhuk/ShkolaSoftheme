using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9_1
{
    class Program
    {
  
        static void Main(string[] args)
        {
            var result = FileOperations.OpenFile(@"D:\output.txt",FileAccessEnum.OpenForRead|FileAccessEnum.OpenForWrite);

            Console.WriteLine("FileName {0} FileAccess {1} FileSize {2} Path {3}", result.FileName, result.FileAccess, result.FileSize, result.Path);
            result = FileOperations.OpenForWrite(@"D:\output.txt");

            Console.WriteLine("FileName {0} FileAccess {1} FileSize {2} Path {3}", result.FileName, result.FileAccess, result.FileSize, result.Path);
            Console.ReadKey();
        }
    }
}

