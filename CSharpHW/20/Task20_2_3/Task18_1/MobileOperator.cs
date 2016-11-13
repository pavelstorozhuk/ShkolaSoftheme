using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task18_1
{
    static class MobileOperator
    {
        private static MobileAccountsRepository _repository;


        static MobileOperator()
        {
            _repository = new MobileAccountsRepository();
        }

        public static bool Connect(IMobileAccount account1, IMobileAccount account2)
        {
            account1 = _repository.GetMobileAccountByPhoneNumber(account1.PhoneNumber);
            account2 = _repository.GetMobileAccountByPhoneNumber(account2.PhoneNumber);
            if (account1.PhoneNumber == account2.PhoneNumber)
                return false;
            if (_repository.Containts(account1.PhoneNumber) && _repository.Containts(account2.PhoneNumber))
            {
                SendInfoMessage(account1, 1m);
                account2.GetCallEvent += ShowMessage;
                account2.GetCall(account1);
                _repository.SetMobileAccountChanges((MobileAccount) account1);
                return true;
            }
            return false;

        }
        public static bool SendSms(IMobileAccount account1, IMobileAccount account2, string message)
        {
            if (account1.PhoneNumber == account2.PhoneNumber)
                return false;
            if (_repository.Containts(account1.PhoneNumber) && _repository.Containts(account2.PhoneNumber))
            {
                SendInfoMessage(account1, 0.5m);
                account2.GetMessageEvent += ShowSms;
                account2.GetMessage(account1, message);
                _repository.SetMobileAccountChanges((MobileAccount)account1);

                return true;

            }
            return false;

        }

        public static void SendInfoMessage(IMobileAccount account1, decimal money)
        {
            account1.Money -= money;
            if (account1.Money < 2)
            {
                account1.GetMessageFromOperator(new OperatorWarnMessage());
            }
            else
            {

                account1.GetMessageFromOperator(new OperatorInfoMessage());
            }
        }
        public static void ShowMessage(object sender)
        {
            if (sender is IMobileAccount)
            {
                Console.WriteLine(String.Format("you were called from number {0}",
                            ((IMobileAccount)sender).PhoneNumber));
            }
        }
        public static void ShowSms(object sender, string message)
        {
            if (sender is IMobileAccount)
            {
                Console.WriteLine(String.Format("you have received the message {0} from number {1}", message,
                            ((IMobileAccount)sender).PhoneNumber));
            }
        }

        public static decimal GetBalance(IMobileAccount account)
        {
            return _repository.GetMobileAccountByPhoneNumber(account.PhoneNumber).Money;
        }
    }
}
