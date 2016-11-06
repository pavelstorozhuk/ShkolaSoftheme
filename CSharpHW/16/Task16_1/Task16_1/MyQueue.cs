using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task16_1
{
   public class MyQueue<T>
    {
        private class Node
        {
            public T data { get; set; }
            public Node next { get; set; }

            public Node(T data, Node next)
            {
                this.data = data;
                this.next = next;
            }
        }

        private Node _head;
        private Node _tail;
        private int _count;


        public MyQueue()
        {
            _head = _tail = null;
            _count = 0;
        }

        public int Count
        {
            get { return _count; }
        }

        public void Enqueue(T item)
        {
            if (_tail == null)
            {
                _tail = _head = new Node(item,null);
            }
            else
            {
                _tail.next = new Node(item,null);
                _tail = _tail.next;

            }
            _count++;
        }

        public T Dequeue()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Queue is empty");
                
            }

            T result = _head.data;
            _head = _head.next;
            _count--;
            return result;
        }

        public bool Containts( T item)
        {
            if (_head.data.Equals(item))
            {
                return true;
            }
            else
            {

                Node node = _head;
                while (node.next != null)
                {
                    node = node.next;
                    if (node.data.Equals(item))
                        return true;
                }
                return false;


            }
        }

        public T Peek()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Queue is empty");

            }
            return _head.data;
        }
    }
}
