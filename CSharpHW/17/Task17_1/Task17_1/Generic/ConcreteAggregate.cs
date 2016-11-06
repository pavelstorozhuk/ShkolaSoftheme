using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task17_1
{
    class ConcreteGenericAggregate<T>:Aggregate<T> 
    {
        private readonly  List<T> _items = new List<T>();

        public override Iterator CreateIterator()
        {
            return new ConcreteGenericIterator<T>(this);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public T this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }

        public override Iterator<T> CreateGenericIterator()
        {
            return new ConcreteGenericIterator<T>(this);
        }

       
    }
}
