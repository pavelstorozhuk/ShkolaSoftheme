using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11_1
{
   
   public class ColorPrinter:Printer
    {
        public override void Print(string text)
        {
            Console.WriteLine("Color printer {0}",text);
        }

        public void Print(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("print {0} ",text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
