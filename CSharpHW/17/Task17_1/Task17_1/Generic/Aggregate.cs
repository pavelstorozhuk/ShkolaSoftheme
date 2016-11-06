using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task17_1
{
    abstract class Aggregate<T>:Aggregate
    {

         public abstract Iterator<T> CreateGenericIterator();
    }
}
