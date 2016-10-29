using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10_2
{
    class Program
    {
        public static void ArrSort(int[] array)
        {
            int b = 0;
            int left = 0;
            int right = array.Length - 1;
            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        b = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = b;
                        b = i;
                    }
                }
                right = b;
                if (left >= right) break;
                for (int i = right; i > left; i--)
                {
                    if (array[i - 1] > array[i])
                    {
                        b = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = b;
                        b = i;
                    }
                }
                left = b;
            }
        }

     

      

        static void Main(string[] args)
        {
            var array = new int[10];
           var random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 10);
                Console.Write(array[i] + " ");
            }
            ArrSort(array);
            Console.WriteLine();
            foreach (var number in array)
            {
                  Console.Write(number + " ");
            }
          
            Console.ReadKey();

        }
    }
}
