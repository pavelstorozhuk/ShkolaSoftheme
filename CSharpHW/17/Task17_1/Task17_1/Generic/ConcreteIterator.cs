using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task17_1
{
    class ConcreteGenericIterator<T> : Iterator<T>
    {
        private readonly ConcreteGenericAggregate<T> _aggregate;
        private int _current;

        public ConcreteGenericIterator(ConcreteGenericAggregate<T> aggregate)
        {
            _aggregate = aggregate;
        }

        public override object First()
        {
            return _aggregate[0];
        }

        public override object Next()
        {
            object ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }

        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }

        public override T CurrentGenericItem()
        {
           return _aggregate[_current];
        }
    }
}
