using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MobileAccount account1 = new MobileAccount("0668348842");
            MobileAccount account2 = new MobileAccount("0637543684");
            account1.Call(account2);
            account2.SendSms(account1,"message");
            account2.Call(account1);
           account1.SendSms(account2,"message2");
            Console.ReadKey();
        }
    }
}
