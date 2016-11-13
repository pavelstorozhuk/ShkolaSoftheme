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
            MobileOperator.Deserialization(SerializationType.Xml);
            MobileAccount account1 = new MobileAccount("0668348842");
            MobileAccount account2 = new MobileAccount("0637543684");
          
            account1.Call(account2);

            account2.SendSms(account1, "message");
            MobileOperator.Serialization(SerializationType.Binary);
           MobileOperator.Serialization(SerializationType.Json);
            MobileOperator.Serialization(SerializationType.Xml);
            MobileOperator.Deserialization(SerializationType.Xml);
            MobileOperator.Deserialization(SerializationType.Json);
            MobileOperator.Deserialization(SerializationType.Binary);
            
           
            Console.ReadKey();
        }
    }
}
