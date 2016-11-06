using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task16_2
{
    class Program
    {
        static void Main(string[] args)
        {
          var  myStack = new MyStack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            Console.WriteLine("Pop {0}", myStack.Pop());
            Console.WriteLine(myStack.Peek());
            Console.ReadKey();
        }
    }
}
