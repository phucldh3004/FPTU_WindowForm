using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectLibrary.utils
{
    public class Validates
    {
        public bool CheckTextEmpty(string text)
        {
            bool check = true;
            if (text.Length < 1)
            {
                check = false;
            }
            return check;
        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }


            return true;
        }
       
        public bool checkText1(string text)
        {
            bool check = false;

            Regex regex = new Regex("^[A-Za-z0-9-_]{3,10}$");
            if (regex.IsMatch(text))
            {
                check = true;
            }
            else
            {
                check = false;
            }


            return check;

        }
        public bool checkPhone(string text)
        {
            bool check = false;
            Regex regex = new Regex("^[0-9]{10}$");
            if (regex.IsMatch(text))
            {
                check = true;
            }
            else
            {
                check = false;
            }


            return check;
        }

       

        public bool CheckFormat(String id, Regex rg)
        {
            if (!rg.IsMatch(id))
            {
                return false;
            }
            return true;
        }
    }
}
