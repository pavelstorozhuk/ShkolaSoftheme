using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task11_1
{

     public  class  Printer
    {
        public virtual void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
