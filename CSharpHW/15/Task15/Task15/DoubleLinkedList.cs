using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task15
{
    class DoubleLinkedList<T> where T:new()
    {
        private Node<T> First;
        private Node<T> Current;
        private Node<T> Last;
        private uint size;

        public DoubleLinkedList()
        {
            size = 0;
      
        }

        public bool isEmpty //проверка на пустоту
        {
            get
            {
                return size == 0;
            }
        }

        public void Insert_Index(T newElement, uint index) //вставить по индекусу
        {
            if (index < 1 || index > size) //вброс ошибки, если неправильный индекс
            {
                throw new InvalidOperationException();
            }
            else if (index == 1) //если начало
            {
               Add_First(newElement);
            }
            else if (index == size) //если конец
            {
               Add_Last(newElement);
            }
            else //иначе ищем элемент с таким индексом
            {
                uint count = 1;
                Current = First;
                while (Current != null && count != index)
                {
                    Current = Current.Next;
                    count++;
                }
               var  newNode = new Node<T>(newElement); //создаем объект
                Current.Prev.Next = newNode; 
                newNode.Prev = Current.Prev;
                Current.Prev = newNode;
                newNode.Next = Current;
            }
        }

        public void Add_First(T newElement)
        {
            Node<T> newNode=new Node<T>(newElement);

            if (First == null)
            {
                First = Last = newNode;
            }
            else
            {
                newNode.Next = First; 
                First = newNode; //First и newNode указывают на один и тот же объект
                newNode.Next.Prev = First;
            }
            Count++;
        }

        public Node<T> Remove_First()
        {
            if (First == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                var temp = First;
                if (First.Next != null)
                {
                    First.Next.Prev = null;
                }
                First = First.Next;
                Count--;
                return temp;
            }
        }

        public void Add_Last(T newElement)
        {
            var newNode = new Node<T>(newElement);

            if (First == null)
            {
                First = Last = newNode;
            }
            else
            {
                Last.Next = newNode;
                newNode.Prev = Last;
                Last = newNode;
            }
            Count++;
        }

        public  Node<T> Remove_Last()
        {
            if (Last == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                var temp = Last;
                if (Last.Prev != null)
                {
                    Last.Prev.Next = null;
                }
                Last = Last.Prev;
                Count--;
                return temp;
            }
        }

        public void ClearList() 
        {
            while (!isEmpty)
            {
                Remove_First();
            }
        }

        public uint Count 
        {
            get { return size; }
            set { size = value; }
        }

        public void Display() 
        {
            if (First == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            Current = First;
            uint count=0;
            while (Current != null)
            {
                Console.WriteLine(  count.ToString()+" : " + Current.Value.ToString());
                count++;
                Current = Current.Next;
            }
        }

        public T[] ToArray()
        {
            var array = new T[size];
            Current = First;
            uint count = 0;
            while (Current != null)
            {
                array[count] = Current.Value;
                count++;
                Current = Current.Next;
            }
           
            return array;
        }

        public void RemoveByValue(T value)
        {
         
            RemoveByIndex(GetIndex(value));

        }
        public void RemoveByIndex(int index)
        { 
            if (index < 0 || index > size-1)
            {
                throw new InvalidOperationException();
            }
            else if (index == 0)
            {
                Remove_First();
            }
            else if (index == size-1)
            {
                Remove_Last();
            }
            else
            {
                int count = 0;
                Current = First;
                while (Current != null && count != index)
                {
                    Current = Current.Next;
                    count++;
                }

                if (index == count)
                {
                    Current.Prev.Next = Current.Next;
                    Current.Next.Prev = Current.Prev;
                    size--;
                }

            }
        }

      

        public int GetIndex(T value) 
        {
            Current = First;
            int index = 0;
            while (Current != null)
            {
                if (Current.Value.Equals(value))
                {
                    return index;
                }
                Current = Current.Next;
                index++;
            }
            return -1;

        }

        public bool Contains(T value)
        {
            if (GetIndex(value) != -1)
                return true;
            else
                return false;
        }

    }
}
