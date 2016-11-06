using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task17_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteGenericAggregate<int> a = new ConcreteGenericAggregate<int>();
            a[0] = 0;
            a[1] = 1;
            a[2] = 2;
            a[3] = 3;
            a[4] = 4;
            ConcreteGenericIterator<int> i = new ConcreteGenericIterator<int>(a);

            Console.WriteLine("Iterating over collection:");

            var item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }

            Console.ReadKey();
        }
    }
}
