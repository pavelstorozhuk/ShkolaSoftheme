using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCollection = new Collection<int>(5);
            myCollection.Add(5);
            myCollection.Add(4);
            myCollection.Add(6);
            myCollection.Add(7);
            myCollection.Add(8);
            myCollection.Add(10);
            myCollection.Add(11);
            foreach (var value in myCollection )
            {
                Console.WriteLine(value);
            }
            Console.WriteLine(myCollection[3]);
            Console.WriteLine(myCollection.Contains(4));
            Console.ReadKey();
        }
    }
}
