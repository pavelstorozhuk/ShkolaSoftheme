using System.Linq;

namespace Task18_1
{
    internal class MobileAccountsRepository
    {
        private MobileAccount[] array =
        {
            new MobileAccount("0668348842"),
            new MobileAccount("0637543684"),
            new MobileAccount("0662345623"),
            new MobileAccount("0662345643"),
            new MobileAccount("0662342623"),
        };

        public bool Containts(string phoneNumber)
        {
            if (array.ToList().Find(m => m.PhoneNumber.Equals(phoneNumber)) != null)
                return true;
            else return false;
        }
        

    }
}