using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace Hi_Tech_Management_FINAL_PROJECT.VALIDATION
{
    public  class Validator
    {
        public static bool IsEmpty(string input)
        {
            if (input == "")
            {
                return true;
            }
            return false;
        }

        public static bool IsEmpty1(int input)
        {
            if (input == 0)
            {
                return true;
            }
            return false;
        }

        //Set validation for data enter leght
        public static bool IsValidId(string input, int length)
        {
            if (!Regex.IsMatch(input, @"^\d{" + length + "}$"))
            {
                return false;
            }
            return true;
        }

        //firstname lastname validation
        public static bool IsValidString(string input)
        {
            foreach (char i in input)
            {
                if (!Char.IsWhiteSpace(i) && !Char.IsLetter(i))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidDate(string input)
        {
            if (!Regex.IsMatch(input, @"^(0[1-9]|1[0-2])/(0[1-9]|[1-2][0-9]|3[0-1])/(20[0-2][0-9])$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidEmail(string input)
        {
            if (!Regex.IsMatch(input, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidPostal_Code(string input)
        {
            if (!Regex.IsMatch(input, @"^[A-Z]{1}\d{1}[A-Z]{1}[- ]{0,1}\d{1}[A-Z]{1}\d{1}$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidNumber(string input)
        {
            foreach (char i in input)
            {
                if (!Char.IsDigit(i))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
