using System;
using System.Collections;
using System.Collections.Generic;


namespace Task10_3
{
    class Collection<T>:IEnumerable<T>,IEnumerator<T> where T : new()
    {
        private T[] _array;
        private int _position = -1;
        private int _count=-1;

        public Collection()
        {
            _array = new T[0];
        }

        public Collection(int length)
        {
            _array = new T[length];
        }

        public int Count
        {
            get { return _count; }
        }

        public void Add(T newElement)
        {
            if (Count < _array.Length - 1)
            {
                _count++;
                _array[Count] = newElement;

            }
            else
            {
                var arr = new T[_array.Length + 1];
                _array.CopyTo(arr, 0);
                arr[_array.Length] = newElement;
                _array = arr;
            }
        }

        public bool Contains(T element)
        {
            foreach (var value in this)
            {
                if (value.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

       /* public T GetByIndex(int index)
        {
            return _array[index];
        } есть индексатор :)
        */

        public T this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }



        public void Reset()
        {
            _position = -1;
        }

        bool IEnumerator.MoveNext()
        {
            if (_position < _array.Length-1)
            {
                _position++;
                return true;
            }
            return false;
        }

      
        void IEnumerator.Reset()
        {
            _position = -1;
        }

    
        object IEnumerator.Current
        {
            get { return _array[_position]; }
        }

      
        T IEnumerator<T>.Current
        {
            get { return _array[_position]; }
        }

     
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
      
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this;
        }

       
        void IDisposable.Dispose()
        {
            ((IEnumerator)this).Reset();
        }
    }
}

