using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task15
{
    class Program
    {
        static void Main(string[] args)
        {
         
           DoubleLinkedList<int> list = new DoubleLinkedList<int>();
           list.Add_First(5);
           list.Add_First(6);
           list.Add_First(7);
           list.Add_Last(8);
           list.Add_Last(9);
           list.RemoveByValue(6);
           list.RemoveByIndex(3);
            Console.WriteLine(list.Contains(7));
            Console.WriteLine(list.Count);
            list.Display();
            var array = list.ToArray();
            foreach (var value in  array)
            {
                Console.WriteLine(value);
            }
            Console.ReadKey();

        }
    }
}
