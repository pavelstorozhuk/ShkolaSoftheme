using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Authorization();
            Console.ReadKey();
        }

        private static void Authorization()
        {
            User user = new User();
          
         
            var login = String.Empty;
            var password = String.Empty;
            while (login != "exit" && password != "exit")
            {
                Console.WriteLine("Enter your username or email:");
                login = Console.ReadLine();
                Console.WriteLine("Enter your password:");
                password = Console.ReadLine();
                var validator = new Validator();
                if (login.Contains("@"))
                {
                    validator.ValidateUser(new User() {Email = login, Password = password});
                }
                else
                {
                    validator.ValidateUser(new User() {Name = login, Password = password});
                }
            }
        }
    }
}
