using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("BMW",1994,Color.Blue);
            TuningAtelier.TuneCar(car);
            Console.WriteLine(car.Color);
            Console.ReadKey();
        }
    }
}
