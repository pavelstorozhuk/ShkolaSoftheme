using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_1
{
    class Validator:IValidator
    {
        private User[] _users;
        public Validator()
        {
            _users = new User[]
            {
                new User(){Email = @"user1@gmail.com", Name = "user1", Password = "1234"},
                new User() {Email = @"user2@gmail.com",Name = "user2",Password = "1234"},
                new User() {Email = @"user3@gmail.com",Name = "user3",Password = "1234"}
            };
        }
        
        public void ValidateUser(IUser user)
        {
            for (int i = 0; i < _users.Length; i++)
            {
                if ((_users[i].Name== user.Name && _users[i].Password==user.Password) ||
                    (_users[i].Email== user.Email && _users[i].Password==user.Password))
                {
                    Console.WriteLine("You are logged in");
                    Console.WriteLine(_users[i].GetFullInfo());
                 
                    
                    return;
                    
                }
            }
            Console.WriteLine("Error, not correct input");
        }
    }
}
