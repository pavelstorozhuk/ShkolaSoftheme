using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Task18_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            MobileAccount account1 = new MobileAccount("0668348842");
            MobileAccount account2 = new MobileAccount("0637543684");
            account1.Call(account2);
            account2.SendSms(account1, "message");

            stopWatch.Start();
            for (int i = 0; i < 100; i++)
            {
                MobileOperator.Serialization(SerializationType.Binary);
            }
            stopWatch.Stop();
            Console.WriteLine("Serialization type binary {0} ms",stopWatch.ElapsedMilliseconds);
            Console.WriteLine("Serialization type binary {0} ms", stopWatch.Elapsed);
            stopWatch.Reset();
            
            stopWatch.Start();
            for (int i = 0; i < 100; i++)
            {
                MobileOperator.Deserialization(SerializationType.Binary);
            }
              stopWatch.Stop();
              Console.WriteLine("Deserialization type binary {0} ms", stopWatch.ElapsedMilliseconds);
              Console.WriteLine("Deserialization type binary {0} ms", stopWatch.Elapsed);
            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 0; i < 100; i++)
            {
                MobileOperator.Serialization(SerializationType.Json);
            }
            stopWatch.Stop();
            Console.WriteLine("Serialization type JSON {0} ms", stopWatch.ElapsedMilliseconds);
            Console.WriteLine("serialization type JSon {0} ms", stopWatch.Elapsed);
            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 0; i < 100; i++)
            {
                MobileOperator.Deserialization(SerializationType.Json);
            }
            stopWatch.Stop();
           
            Console.WriteLine("Deserialization type JSON {0} ms", stopWatch.ElapsedMilliseconds);
            Console.WriteLine("Deserialization type JSon {0} ms", stopWatch.Elapsed);
             stopWatch.Reset();
            stopWatch.Start();
             for (int i = 0; i < 100; i++)
             {
                 MobileOperator.Serialization(SerializationType.Xml);
             }
            stopWatch.Stop();
            Console.WriteLine("Serialization type XML {0} ms", stopWatch.ElapsedMilliseconds);
            Console.WriteLine("serialization type XML {0} ms", stopWatch.Elapsed);

            stopWatch.Start();
            for (int i = 0; i < 100; i++)
            {
                MobileOperator.Deserialization(SerializationType.Xml);
            }
            stopWatch.Stop();
            Console.WriteLine("Deserialization type XML {0} ms", stopWatch.ElapsedMilliseconds);
            Console.WriteLine("Deserialization type XML {0} ms", stopWatch.Elapsed);
            stopWatch.Reset();
            
            stopWatch.Start();
            for (int i = 0; i < 100; i++)
            {
                MobileOperator.Serialization(SerializationType.Proto);
            }
            stopWatch.Stop();
            
            Console.WriteLine("Serialization type Proto {0} ms", stopWatch.ElapsedMilliseconds);
            Console.WriteLine("serialization type Proto {0} ms", stopWatch.Elapsed);
            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 0; i < 100; i++)
            {
                MobileOperator.Deserialization(SerializationType.Proto);
            }
            stopWatch.Stop();
            Console.WriteLine("Deserialization type Proto {0} ms", stopWatch.ElapsedMilliseconds);
            Console.WriteLine("Deserialization type Proto {0} ms", stopWatch.Elapsed);

            Console.ReadKey();
        }
    }
}
