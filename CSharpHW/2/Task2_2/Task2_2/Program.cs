using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{
    enum MathOperation
    {
        Add=1,
        Subtract=2,
        Multiply=3,
        Divide=4
    }

    class Program
    {
        static void Solve(double x, double y, MathOperation op)
        {
            double result=0;

            switch (op)
            {
                case MathOperation.Add:
                    result = x + y;
                    break;
                case MathOperation.Subtract:
                    result = x - y;
                    break;
                case MathOperation.Multiply:
                    result = x * y;
                    break;
                case MathOperation.Divide:
                    if (y == 0) throw new DivideByZeroException();
                    result = x / y;
                    break;
            }

            Console.WriteLine("Result {0}", result);
            if (result - Math.Truncate(result) == 0)
            {
                Console.WriteLine("Result 00 with two digits after decimal point");
            }
            else
            {
                result = Math.Truncate(100 * (result - Math.Truncate(result)));

                Console.WriteLine("Result {0} with two digits after decimal point",result);
            }
        }
 
        static void Main(string[] args)
        {
            int num1 = 3000;
            int num2 = 0;

           
            try
            {
                Console.WriteLine("Write the first number:");
                double number1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Write the second number:");
                double number2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine(
                @"Choose the operation 
                1 - Add
                2 - Sub 
                3 - Mul
                4 - Div");
                MathOperation operation = (MathOperation)Convert.ToInt32(Console.ReadLine());
                Solve(number1, number2, operation);
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Error, Invalid input");
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("Error, Devide by zero");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
           
            Console.ReadKey();
            
        }
    }
}
