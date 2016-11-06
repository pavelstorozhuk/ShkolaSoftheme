using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18_1
{
       internal delegate void AccountSmsStateHandler(object sender, string message);
       internal  delegate void AccountCallStateHandler(object sender);
    internal class MobileAccount:IMobileAccount
    {
        private event AccountSmsStateHandler _getMessage;
        private event AccountCallStateHandler _getCall;
        public MobileAccount(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
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

       

        public void GetMessage(IMobileAccount account,string message)
        {
            if (_getMessage != null)
            {
                _getMessage.Invoke(account, message);
                _getMessage -= MobileOperator.ShowSms;
            }
        }
        public void GetCall(IMobileAccount account)
        {
            if (_getCall != null)
            {
                _getCall.Invoke(account);
                _getCall -= MobileOperator.ShowMessage;
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

    }
}
