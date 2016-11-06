using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task16_2
{

    public class MyStack<T>
    {
        private class Node
        {
            public T _data { get; set; }
            public Node _next { get; set; }

            public Node(T data, Node next)
            {
                _data = data;
                _next = next;
            }
        }

        private Node _top;
        private int _count;

        public int Count
        {
            get { return _count; }
        }

        public MyStack()
        {
            _top = null;
            _count = 0;
        }

        public void Push(T item)
        {
            _top = new Node(item, _top);

            _count++;
        }

        public T Pop()
        {
            T result = _top._data;
            _top = _top._next;
            _count--;
            return result;
        }

        public T Peek()
        {
            return _top._data;
        }

    }

}
