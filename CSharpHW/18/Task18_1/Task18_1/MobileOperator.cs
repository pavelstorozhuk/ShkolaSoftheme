using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task18_1
{
    static class  MobileOperator
    {
        private static MobileAccountsRepository _repository;


         static MobileOperator()
        {
            _repository = new MobileAccountsRepository();
        }

        public  static bool Connect(IMobileAccount account1, IMobileAccount account2)
        {
            if (account1.PhoneNumber == account2.PhoneNumber)
                return false;
            if (_repository.Containts(account1.PhoneNumber) && _repository.Containts(account2.PhoneNumber))
            {
                account2.GetCallEvent += ShowMessage;
                account2.GetCall(account1);
                return true;

            }
            return false;

        }
        public static bool SendSms(IMobileAccount account1, IMobileAccount account2,string message)
        {
            if (account1.PhoneNumber == account2.PhoneNumber)
                return false;
            if (_repository.Containts(account1.PhoneNumber) && _repository.Containts(account2.PhoneNumber))
            {
                account2.GetMessageEvent += ShowSms;
                account2.GetMessage(account1,message);
                return true;

            }
            return false;

        }

        public static void ShowMessage(object sender)
        {
            if (sender is IMobileAccount)
            {
                Console.WriteLine(String.Format("you were called from number {0}",
                            ((MobileAccount)sender).PhoneNumber));
            }
        }
        public static void ShowSms(object sender, string message)
        {
            if (sender is IMobileAccount)
            {
                Console.WriteLine(String.Format("you have received the message {0} from number {1}",message,
                            ((IMobileAccount)sender).PhoneNumber));
            }
        }
    }
}
