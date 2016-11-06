using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18_2
{
    internal class MobileAccountsRepository
    {
        private  readonly MobileAccount[] array =
        {
            new MobileAccount("0668348842"),
            new MobileAccount("0637543684"),
            new MobileAccount("0662345623"),
            new MobileAccount("0662345643"),
            new MobileAccount("0662342623"),
            new MobileAccount("0622342631"),
            new MobileAccount("0642342653")
        };

        public bool Containts(string phoneNumber)
        {
            if (array.ToList().Find(m => m.PhoneNumber.Equals(phoneNumber)) != null)
                return true;
            else return false;
        }

        public IEnumerator GetEnumerator()
        {
           return array.GetEnumerator();
        }
    }

}
