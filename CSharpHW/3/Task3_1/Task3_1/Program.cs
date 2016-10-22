using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_1
{
    enum Date
    {
        Day,
        Month,
        Year
    }
  
    enum Month
    {
        January=1,
        Fabruary,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December,

    }
    class Program
    {
        private static string GetZodiacSigns(int day,Month month)
        {
            switch (month)
            {
                case Month.January:
                    if (day <= 19)
                        return "Capricorn";
                    else
                        return "Aquarius";

                case Month.Fabruary:
                    if (day <= 18)
                        return "Aquarius";
                    else
                        return "Pisces";
                case Month.March:
                    if (day <= 20)
                        return "Pisces";
                    else
                        return "Aries";
                case Month.April:
                    if (day <= 19)
                        return "Aries";
                    else
                        return "Taurus";
                case Month.May:
                    if (day <= 20)
                        return "Taurus";
                    else
                        return "Gemini";
                case Month.June:
                    if (day <= 20)
                        return "Gemini";
                    else
                        return "Cancer";
                case Month.July:
                    if (day <= 22)
                        return "Cancer";
                    else
                        return "Leo";
                case Month.August:
                    if (day <= 22)
                        return "Leo";
                    else
                        return "Virgo";
                case Month.September:
                    if (day <= 22)
                        return "Virgo";
                    else
                        return "Libra";
                case Month.October:
                    if (day <= 22)
                        return "Libra";
                    else
                        return "Scorpio";
                case Month.November:
                    if (day <= 21)
                        return "Scorpio";
                    else
                        return "Sagittarius";
                case Month.December:
                    if (day <= 21)
                        return "Sagittarius";
                    else
                        return "Capricorn";
                default: throw new Exception("Zodiac sign does not exist");
            }
        }
        private static int GetNumberOfDaysInTheMonth(Month month)
        {

            switch(month)
            {
                case Month.January:
                    return 31;
                case Month.Fabruary:
                    return 28;
                case Month.March:
                    return 31;
                case Month.April:
                    return 30;
                case Month.May:
                    return 31;
                case Month.June:
                    return 30;
                case Month.July:
                    return 31;
                case Month.August:
                    return 31;
                case Month.September:
                    return 30;
                case Month.October:
                    return 31;
                case Month.November:
                    return 30;
                case Month.December:
                    return 31;
                default: throw new Exception("the month does not exist");
            }
        }
        private static bool RecursiveValidation(string[] parts, Date date)
        {
            int day = Convert.ToInt32(parts[0]);
            int month = Convert.ToInt32(parts[1]);
            int year = Convert.ToInt32(parts[2]);

             switch (date)
             {
                 case  Date.Year:

                     if (year >= 1 && year <= 2016)
                         return RecursiveValidation(parts, Date.Month);
                     else
                     {
                         Console.WriteLine("Incorrect year");
                         return false;
                     }
                 
                 case Date.Month:

                     if (month >= 1 && month <= 12)
                         return RecursiveValidation(parts, Date.Day);
                     else
                     {
                         Console.WriteLine("Incorrect month");
                         return false; 
                     }
                   
                 case Date.Day:
                     if (day >= 1 && day <= GetNumberOfDaysInTheMonth((Month)month))
                         return true;
                     else
                     {
                         Console.WriteLine("Incorrect day");
                         return false;
                     }
                    
             }
             return false;
        }
        private static bool Validation (string date)
        {
            try
            {
                string[] parts = date.Split('/');
                return RecursiveValidation(parts, Date.Year);
            }
           
            catch (Exception ex)
            {
                Console.WriteLine("incorrect input");
                return false;
            }
        }
        static void Main(string[] args)
        {
            string date;


            bool validation;
            do
            {
                Console.WriteLine("Enter your date of birth:");
                date = Console.ReadLine();
                validation = Validation(date);
                if ((Validation(date)))
                {
                    string[] parts = date.Split('/');
                    string zodiacSign = GetZodiacSigns(Int32.Parse(parts[0]), (Month)(Int32.Parse(parts[1])));
                    Console.WriteLine(zodiacSign);
                }

            }
            while (!validation);
           
       
           
            
           
            Console.ReadKey();
        }
    }
}
