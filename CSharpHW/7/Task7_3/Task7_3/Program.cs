using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var descriptor  = new ShapeDescriptor(new Point(1,2), new Point(3,4) ,new Point(4,5));
            Console.WriteLine(descriptor.type);
                    
            var descriptor2  = new ShapeDescriptor(new Point(1,2), new Point(3,4) ,new Point(4,5),new Point(4,5));
            Console.WriteLine(descriptor2.type);
            Console.ReadKey();
        }
    }
}
