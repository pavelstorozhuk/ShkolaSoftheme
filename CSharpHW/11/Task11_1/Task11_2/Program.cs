using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using  Task11_1;

namespace Task11_2
{
    class Program
    {
        static void Main(string[] args)
        {
             var  colorPrinter = new ColorPrinter();
           colorPrinter.ExtendPrint(new string[] { "message1", "message2" }, ConsoleColor.Cyan);
           var photoPrinter = new PhotoPrinter();
          
            
            photoPrinter.ExtendPrint(new Photo[]{new Photo(), new Photo() });
            photoPrinter.ExtendPrint(new string[]{"text1","text2","text3"});
            Console.ReadKey();
        }
    }
}
