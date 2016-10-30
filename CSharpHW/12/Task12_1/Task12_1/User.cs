using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_1
{
    class User:IUser
    {
        private List<DateTime> list;
        public User(string name, string password)
        {
            Name = name;
            Password = password;
         
            
        }

        public User()
        {
           
        }
        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    

        public string GetFullInfo()
        {

            return string.Format("Name: {0} Password: {1} Email: {2} \n LastIn:{3}", Name, Password, Email, DateTime.Now);




        }

        public override bool Equals(object obj)
        {
            if (obj is User)
                return Name == ((User) obj).Name && Password == ((User) obj).Password && Email == ((User) obj).Email;
                      
          
            
            return false;
        }

        public override int GetHashCode()
        {
            return GetFullInfo().GetHashCode();
        }
    }
}
