using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18_2
{
    internal delegate void AccountSmsStateHandler(object sender, string message);
    internal delegate void AccountCallStateHandler(object sender);

    internal class MobileAccount : IMobileAccount
    {
        private event AccountSmsStateHandler _getMessage;
        private event AccountCallStateHandler _getCall;
        private  readonly Dictionary<string, string> _addressBook;
        public MobileAccount(string phoneNumber)
        {
            _addressBook= new Dictionary<string, string>();
            PhoneNumber = phoneNumber;
           
        }
        public MobileAccount(string phoneNumber, Dictionary<string,string> addressBook )
        {
            PhoneNumber = phoneNumber;
            _addressBook = addressBook;
        }

        public string FindNameFromAddressBook(string number)
        {
            if (_addressBook.ContainsKey(number))
                return _addressBook[number];
            return null;
        }

        public string PhoneNumber { get; set; }

        public event AccountSmsStateHandler GetMessageEvent
        {
            add { _getMessage += value; }
            remove { _getMessage -= value; }
        }

        public event AccountCallStateHandler GetCallEvent
        {
            add { _getCall += value; }
            remove { _getCall -= value; }
        }



        public void GetMessage(IMobileAccount account, string message)
        {
            if (_getMessage != null)
            {
                if (this.FindNameFromAddressBook(account.PhoneNumber) != null)
                {
                    this.GetMessageEvent -= MobileOperator.ShowSms;
                    this.GetMessageEvent+=this.ShowSmsFromKnowNumber;
                }
                _getMessage.Invoke(account, message);
                _getMessage = null;
            }
        }

        public void GetCall(IMobileAccount account)
        {
            if (_getCall != null)
            {
                if (this.FindNameFromAddressBook(account.PhoneNumber) != null)
                {
                    this.GetCallEvent -= MobileOperator.ShowMessage;
                    this.GetCallEvent += this.ShowCallFromKnowNumber;
                }
                _getCall.Invoke(account);
                _getCall = null;
            }
        }

        public void Call(IMobileAccount account)
        {

            MobileOperator.Connect(this, account);
            

        }

        public void SendSms(IMobileAccount account, string message)
        {

            MobileOperator.SendSms(this, account, message);
        }
        private void ShowSmsFromKnowNumber(object sender, string message)
        {
            if (sender is IMobileAccount)
            {
                Console.WriteLine(String.Format("you have received the message {0} from name {1}", message,
                            FindNameFromAddressBook(((IMobileAccount)sender).PhoneNumber)));
            }
        }
        private void ShowCallFromKnowNumber(object sender)
        {
            if (sender is IMobileAccount)
            {
                Console.WriteLine(String.Format("you were called from name {0}",
                    FindNameFromAddressBook(((IMobileAccount) sender).PhoneNumber)));
            }
        }
    }
}
