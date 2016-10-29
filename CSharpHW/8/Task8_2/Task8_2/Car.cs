using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_2
{
    class Car
    {
        public Car(Engine engine, Color color, Transmission transmission)
        {
            Engine = engine;
            Color = color;
            Transmission = transmission;
        }
        public Engine Engine { get; set; }
        public Color Color { get; set; }
        public Transmission Transmission { get; set; }

    }
}
