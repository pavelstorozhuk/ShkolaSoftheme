﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10001];
          
            int count = 0;
            int buf = 0;
            for (int i = 0; i < array.Length; i++)
            {

                if (i == 4)
                {
                    array[i] = 100500;
                }
                else
                {


                    if (count == 2)
                    {
                        count = 0;
                        buf = 0;
                    }

                    if (count != 2)
                    {
                        if (count == 0)
                        {
                            buf = i;
                        }
                        array[i] = buf;
                      //  Console.WriteLine(array[i]);
                        count++;
                    }
                }
            }
           
            long sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum ^= array[i];
              
               
            }
            Console.WriteLine("число:{0}",sum);
            Console.ReadKey();
        }
    }
}
