using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_1
{
    
    class Car
    {
        public Car(string model, int year, Color color)
        {
            Model = model;
            Year = year;
            Color = color;
        }
        public string Model{ get; set; }
        public int Year { get; set; }
        public Color Color { get; set; }
    }
}
