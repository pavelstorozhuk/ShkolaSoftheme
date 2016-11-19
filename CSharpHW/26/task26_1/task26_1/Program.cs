using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task26_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var editor = new FilesEditor(@"D:\test", "txt");
            editor.AsyncChange("text", "replaceText");
            editor.Dispose(); 
            Console.ReadKey();
        }
    }
}
