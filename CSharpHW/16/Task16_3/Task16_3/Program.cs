using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task16_3
{
    class Program
    {
        static void Main(string[] args)
        {

            var dictionary = new MyDictionary<int, string>(5);
            dictionary.Add(1, "value1");
            dictionary.Add(2, "value2");
            dictionary.Add(3, "value3");
            dictionary.Add(4, "value4");
            dictionary.Add(5, "value5");
            // Console.WriteLine(dictionary.GetValue(10));
            dictionary.Remove(3);
            Console.WriteLine(dictionary[1]);
            Console.WriteLine(dictionary[2]);
            Console.WriteLine(dictionary[4]);
            Console.WriteLine(dictionary[5]);

            try
            {
                Console.WriteLine(dictionary[3]);
            }
            catch (KeyNotFoundException ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
