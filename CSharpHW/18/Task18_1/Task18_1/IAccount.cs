using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18_1
{
    interface IMobileAccount
    {
        string PhoneNumber { get; set; }
        void Call(IMobileAccount account);
        void SendSms(IMobileAccount account, string message);
        void GetMessage(IMobileAccount account, string message);
        void GetCall(IMobileAccount account);
        event AccountSmsStateHandler GetMessageEvent;
        event AccountCallStateHandler GetCallEvent;

    }

    
}
