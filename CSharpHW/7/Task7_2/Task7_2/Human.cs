using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_2
{
    class Human
    { 
        public Human( string firstName, string lastName, int age,DateTime birthDay)
        {
            BirthDay = birthDay;
            FirstName = firstName;
            LastName = lastName;
            _age = age;
        }
        public Human()
        {
            BirthDay = default(DateTime);
            FirstName = String.Empty;
            LastName = String.Empty;
            _age = 0;
        }
        private readonly int _age;
        public DateTime BirthDay
        { get;set; }
        public string FirstName
        { get; set; }
        public string LastName
        { get; set; }
        public  int Age
        { 
            get { return _age; }
        }
        
        public override bool Equals(Object obj )
        {
            if (obj is Human)
            {
                return (this.Age == ((Human)obj).Age && this.BirthDay == ((Human)obj).BirthDay && this.FirstName == ((Human)obj).FirstName
                    && this.LastName == ((Human)obj).LastName);
            }
            return false;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", this.FirstName, this.LastName, this.BirthDay, this.Age);
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(Human human1, Human human2)
        {
            return human1.Equals(human2);
        }
        public static bool operator !=(Human human1, Human human2)
        {
            return (!human1.Equals(human2));
        }
    }
}
