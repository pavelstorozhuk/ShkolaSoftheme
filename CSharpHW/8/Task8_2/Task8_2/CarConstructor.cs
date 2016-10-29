using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_2
{
    class CarConstructor
    {
        public Car Construct(Engine engine, Color color, Transmission transmission)
        {
            return  new Car(engine,color,transmission);
        }

        public void Reconstruction(Car car)
        {
            car.Engine= new Engine();
        }



    }
}
