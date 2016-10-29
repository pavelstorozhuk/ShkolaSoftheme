using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11_1
{
   public class Photo
   {
       
       
    }
   public class PhotoPrinter:Printer
    {
      
       
        public override void Print(string text)
        {
            Console.WriteLine("PhotoPrinter {0}",text);
        }

        public  void Print(Photo photo)
        {
            Console.WriteLine("Print photo ");
          
           
        }
    }
}
