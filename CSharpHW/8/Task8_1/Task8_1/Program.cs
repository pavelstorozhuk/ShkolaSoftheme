using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var user1 = new User("login1","password1");
            var user2 = new User("login1", "password1");
            Console.WriteLine("до копирования {0}",user1.Equals(user2));
            user1 = user2;
            Console.WriteLine("после копирования (сравниваються ссылки) {0}",user1.Equals(user2));
            Point point1= new Point();
            point1.X = 4;
            point1.y = 6;
            Point point2 = new Point();
            point2.X = 3;
            point2.y = 6;
            Console.WriteLine("до копирования {0}",point1.Equals(point2));
            point2 = point1;
            Console.WriteLine("после копирования(сравнивается значение){0}", point1.Equals(point2));
            Console.ReadKey();
        }
    }
}
