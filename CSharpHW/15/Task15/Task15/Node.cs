using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task15
{
    public class  Node<T> where T:new()
    {
      

        public T Value { get; set; }

        public Node(T Data)
        {
            Value = Data;
        }

        public Node<T> Next { get; set; }

        public Node<T> Prev { get; set; }
    }

    
}
