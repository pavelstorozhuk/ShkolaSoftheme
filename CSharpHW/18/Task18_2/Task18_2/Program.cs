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
                {"0637543684","user2"}

            });
            MobileAccount account2 = new MobileAccount("0637543684", new Dictionary<string, string>()
            {
                {"0668348842", "user1"}
            });
            account1.Call(account2);
       
            account2.SendSms(account1, "message");
            Console.ReadKey();
        }
    }
}
