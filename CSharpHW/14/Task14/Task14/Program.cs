using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task14
{
    class Program
    {
        static void Main(string[] args)
        {
            StartLottery();
            Console.ReadKey();
        }

        private static void StartLottery()
        {
            var lottery = new Lottery();

            Console.WriteLine("Enter number ranging from 1 to 9");
            try
            {
                var array = new int[6];
                for (int i = 0; i < 6; i++)
                {
                    array[i] = int.Parse(Console.ReadLine());
                    if (array[i] > 9 || array[i] < 1)
                        throw new Exception("Числа должны быть в диапазоне от 1 до 9");
                }

                for (int i = 0; i < 6; i++)
                    if (lottery[i] == array[i])
                    {
                        Console.WriteLine("you guessed {0}", lottery[i]);
                    }
                    else
                    {
                        Console.WriteLine("you not guessed {0}", lottery[i]);
                    }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("invalid input");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
