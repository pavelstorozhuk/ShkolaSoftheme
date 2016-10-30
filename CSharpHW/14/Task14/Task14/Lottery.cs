using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task14
{
    class Lottery
    {
        private readonly int[] _array= new int[6];
        private Random _random;

        public Lottery()
        {
            _random = new Random();
            for (int i = 0; i < 6; i++)
            {
                _array[i] = _random.Next(1, 11);
            }
        }

        public int this[int index]
        {
            get { return _array[index]; }
        }
    }
}
