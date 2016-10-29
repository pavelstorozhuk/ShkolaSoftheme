using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_3
{
    class ShapeDescriptor
    {
        public ShapeDescriptor(Point point1,Point point2,Point point3)
        {
            type = Shape.Triangle;
        }
        public ShapeDescriptor(Point point1, Point point2, Point point3, Point point4)
        {
            type = Shape.Rectungle;
        }
        public ShapeDescriptor(Point point1, Point point2, Point point3, Point point4,Point point5)
        {
            type = Shape.Pentagon;
        }


       
    
        public Shape type { get; private set; }
    }
}
