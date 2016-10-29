using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human1 = new Human("Pavel","Storozhuk",22,DateTime.Parse("09/13/1994"));
            Human human2 = new Human("Pavel", "Storozhuk", 22, DateTime.Parse("09/13/1994"));
            Human human3 = new Human("Pavel", "Storozhuk", 22, DateTime.Parse("09/12/1994"));
            Console.WriteLine(human1==human2);
            Console.WriteLine(human2==human3);
            Console.ReadKey();
           
        }
    }
}
