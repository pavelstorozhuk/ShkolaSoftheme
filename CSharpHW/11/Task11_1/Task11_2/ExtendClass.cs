using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task11_1;
using  Task11_2;

namespace Task11_2
{
    static class ExtendClass
    {
        public static void ExtendPrint(this Printer printer, string[] text)
        {
            foreach (var line in text)
            {
                printer.Print(line);
            }
        }
        public static void ExtendPrint(this ColorPrinter printer, string[] text, ConsoleColor color)
        {
            foreach (var line in text)
            {
                printer.Print(line,color);
            }
        }
        public static void ExtendPrint(this PhotoPrinter printer,Photo[] photos)
        {
            foreach (var photo in photos)
            {
                printer.Print(photo);
            }
        }
    }
}
