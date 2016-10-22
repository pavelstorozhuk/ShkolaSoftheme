using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1
{
    class Program
    {
        public static void PrintTriangle(int count)
        {
            for (int i=1;i<count+1;i++)
            {
                for (int j=0;j<i;j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public static void PrintSquare(int count)
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public static void PrintRhomb(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                for (int j = 0; j < (number - i); j++)
                    Console.Write(" ");
                for (int j = 1; j <= i; j++)
                    Console.Write("*");
                for (int k = 1; k < i; k++)
                    Console.Write("*");
                Console.WriteLine();
            }

            for (int i = number - 1; i >= 1; i--)
            {
                for (int j = 0; j < (number - i); j++)
                    Console.Write(" ");
                for (int j = 1; j <= i; j++)
                    Console.Write("*");
                for (int k = 1; k < i; k++)
                    Console.Write("*");
                Console.WriteLine();
            }
               
        }
        

        
        static void Main(string[] args)
        {
            PrintTriangle(5);
            Console.WriteLine();
            PrintSquare(5);
            Console.WriteLine();
            PrintRhomb(7);
            Console.ReadKey();
        }
    }
}
