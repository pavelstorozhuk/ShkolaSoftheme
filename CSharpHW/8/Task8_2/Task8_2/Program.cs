using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            CarConstructor constructor = new CarConstructor();
            Car car = constructor.Construct(new Engine(), new Color(), new Transmission());
            constructor.Reconstruction(car);
            
        }
    }
}
