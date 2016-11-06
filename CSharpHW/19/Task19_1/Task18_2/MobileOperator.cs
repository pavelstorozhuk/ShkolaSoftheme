using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task18_2
{
    static class MobileOperator
    {
        private static MobileAccountsRepository _repository;
        private static MagazineOfCalls _magazineOfCalls;

        static MobileOperator()
        {
            _repository = new MobileAccountsRepository();
            _magazineOfCalls = new MagazineOfCalls();
            foreach (MobileAccount value in _repository)
            {
                _magazineOfCalls.Add(value.PhoneNumber);
            }
            
        }

        public static bool Connect(IMobileAccount account1, IMobileAccount account2)
        {
            if (account1.PhoneNumber == account2.PhoneNumber)
                return false;
            if (_repository.Containts(account1.PhoneNumber) && _repository.Containts(account2.PhoneNumber))
            {
                account2.GetCallEvent += ShowMessage;
                account2.GetCall(account1);
                
                    _magazineOfCalls.AddCall(account1.PhoneNumber,account2.PhoneNumber);
                
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
                account2.GetMessageEvent += ShowSms;
                account2.GetMessage(account1, message);
                _magazineOfCalls.AddSms(account1.PhoneNumber);
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
                Console.WriteLine(String.Format("you have received the message {0} from number {1}", message,
                            ((MobileAccount)sender).PhoneNumber));
            }
        }

        public static void PrintTopCalledUsers()
        {
            Console.WriteLine("--------TOP Called Users--------");
            foreach (var user in _magazineOfCalls.GetTopCalledyUsers())
            {
                Console.WriteLine(user.Key+" "+user.Value.CountOfCalled);
            }
          
        }
        public static void PrintTopActivityUsers()
        {
            Console.WriteLine("--------TOP Activity Users--------");
            foreach (var user in _magazineOfCalls.GetTopActivityUsers())
            {
                Console.WriteLine(user.Key + " " + user.Value.ActivityPoint);
            }

        }
    }
}
