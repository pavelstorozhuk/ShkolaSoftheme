using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18_2
{
    class Program
    {
        static void Main(string[] args)
        {
            MobileAccount account1 = new MobileAccount("0668348842", new Dictionary<string, string>()
            {
                {"0637543684","user2"}, 
                {"0662342623", "user3"},

            });
            MobileAccount account2 = new MobileAccount("0637543684", new Dictionary<string, string>()
            {
                {"0668348842", "user1"},
                 {"0662342623", "user3"},

            });
            MobileAccount account3 = new MobileAccount("0662342623", new Dictionary<string, string>()
            {
                {"0668348842", "user1"},
                 {"0637543684", "user2"}
            });
            MobileAccount account4 = new MobileAccount("0662345643", new Dictionary<string, string>()
            {
                {"0668348842", "user1"},
                 {"0637543684", "user2"}
            });
            MobileAccount account5 = new MobileAccount("0662345623", new Dictionary<string, string>()
            {
                {"0668348842", "user1"},
                {"0637543684", "user2"}
            });
            MobileAccount account6 = new MobileAccount("0662342623", new Dictionary<string, string>()
            {
                {"0668348842", "user1"},
                 {"0637543684", "user2"}
            });
            MobileAccount account7 = new MobileAccount("0622342631", new Dictionary<string, string>()
            {
                {"0668348842", "user1"},
                 {"0637543684", "user2"}
            });

            account1.Call(account2);
            account2.SendSms(account1, "message");
            
            account3.Call(account1);
            account3.SendSms(account2,"Hello user2");
            account4.Call(account1);
            account4.Call(account7);
            account4.Call(account3);
            account5.SendSms(account6,"Message");
            account6.Call(account1);
            account7.Call(account3);
            account3.Call(account5);
           MobileOperator.PrintTopActivityUsers();
           MobileOperator.PrintTopCalledUsers();
            Console.ReadKey();
        }
    }
}
