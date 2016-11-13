using System.Linq;

namespace Task18_1
{
    internal class MobileAccountsRepository
    {
        private MobileAccount[] array =
        {
            new MobileAccount("0668348842", 4m),
            new MobileAccount("0637543684", 4m),
            new MobileAccount("0662345623", 4m),
            new MobileAccount("0662345643", 4m),
            new MobileAccount("0662342623", 4m),
        };

        public bool Containts(string phoneNumber)
        {
            if (array.ToList().Find(m => m.PhoneNumber.Equals(phoneNumber)) != null)
                return true;
            else return false;
        }

        public MobileAccount GetMobileAccountByPhoneNumber(string number)
        {
            return array.ToList().Find(m => m.PhoneNumber.Equals(number));
        }

        public void SetMobileAccountChanges(MobileAccount account)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].PhoneNumber == account.PhoneNumber)
                {
                    array[i] = account;
                }
            }
        }

    }
}