using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task16_3
{
    public class MyDictionary<TKey, TValue>
    {
        private class DictionaryEntry<TKey, TValue>
        {
            public TKey Key { get; private set; }
            public TValue Value { get; private set; }

            public DictionaryEntry(TKey key, TValue val)
            {
                Key = key;
                Value = val;
            }
        }

        private LinkedList<DictionaryEntry<TKey, TValue>>[] _array;
        private int _capacity;
        private int _size;
        private const double LoadFactor = 0.75;

        public MyDictionary(int size)
        {
            _capacity = size;
            _array = new LinkedList<DictionaryEntry<TKey, TValue>>[_capacity];
        }
        public MyDictionary()
        {
            _capacity = 5;
            _array = new LinkedList<DictionaryEntry<TKey, TValue>>[_capacity];
        }
        private int hash(TKey key)
        {

            return Math.Abs(key.GetHashCode()) % _capacity;
        }

        private double GetLoadFactor()
        {
            return _size/_capacity;
        }

        private void Resize()
        {
            _capacity = _capacity*2;
            var oldArray = _array;
            _size = 0;
            _array = new LinkedList<DictionaryEntry<TKey, TValue>>[_capacity];

            foreach (var item in oldArray)
            {
                if (item != null)
                {
                    foreach (var pair in item)
                    {
                        if (pair != null)
                            Add(pair.Key, pair.Value);
                    }
                }
            }
        }

        public void Add(TKey key, TValue val)
        {
            if (GetLoadFactor() >= LoadFactor)
            {
                Resize();
            }

            var index = hash(key);

            if (_array[index] == null)
            {
                _array[index] = new LinkedList<DictionaryEntry<TKey, TValue>>();
            }

            var hashTableItem = new DictionaryEntry<TKey, TValue>(key, val);

            var listNode = new LinkedListNode<DictionaryEntry<TKey, TValue>>(hashTableItem);

            _array[index].AddFirst(listNode);

            _size++;
        }

        public bool Remove(TKey key)
        {
            var index = hash(key);
            if (_array[index] == null)
                return false;

            foreach (var item in _array[index])
            {
                if (item.Key.Equals(key))
                {
                    _array[index].Remove(item);
                    break;
                }
            }
            return true;
        }

        public TValue GetValue(TKey key)
        {
            var index = hash(key);

            if (_array[index].ToList().Find(x=>x.Key.Equals(key))==null)
                throw new KeyNotFoundException("Key does not exist in the dictionary");

            foreach (var item in _array[index])
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(TValue);
        }

        public void Clear()
        {
            _size = 0;
            _array = new LinkedList<DictionaryEntry<TKey, TValue>>[_capacity];
        }

        public TValue this[TKey key]
        {
            get { return GetValue(key); }
           
        }
    }
}
