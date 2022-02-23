using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace ExtensionMethods
{
    public static class ExtensionMethods
    {
        private static readonly Dictionary<char, int> numerals = new Dictionary<char, int>
        {
            { 'I',    1 },
            { 'V',    5 },
            { 'X',   10 },
            { 'L',   50 },
            { 'C',  100 },
            { 'D',  500 },
            { 'M', 1000 },     
        };

        private static readonly Regex numeralRegex = 
            new Regex(@"^M{0,3}D{0,3}(CD|DC|C{0,3})(LX|X?L{0,2}|X{0,3})(IX|IV|V?I{0,3})$");  // still WIP, might be buggy

        private enum Single { zero, one, two, three, four, five, six, seven, eight, nine }

        private enum Two { zero, ten, eleven, twelve, thirteen, fourteen, fifteen, sixteen, seventeen, eighteen, nineteen }

        private enum Tens { zero, ten, twenty, thirty, forty, fifty, sixty, seventy, eighty, ninety }

        private enum Powers { hundred, thousand, million}

        public static List<int> Digits(int num)
        {
            List<int> digits = new List<int>();
            int count = num.ToString().Length-1;

            foreach(char d in num.ToString())
            {
                int digit = int.Parse(d.ToString());
                digits.Add(Convert.ToInt32(digit * Math.Pow(10, count)));
                count--;
            }

            //
            return digits;
        }

        public static string ToNumeral(this int num)
        {
            if (num < 0 | num > 3999)
            {
                throw new ArgumentException("Integer outside range 0 and 3999 for numeral conversion");
            }

            string total = "";

            int index = 6;

            foreach (int digit in Digits(num))
            {
                if (digit > numerals.Values.ToArray()[index])
                {
                    total += digit / numerals.Keys.ToArray()[index];
                }
                index--;
            }

            return total;
        }

        public static int ToArabic(this string str)
        {
            str = str.ToUpper();

            if (!numeralRegex.IsMatch(str)) 
            {
                throw new ArgumentException("Invalid syntax for Roman numeral");         
            }

            int total = 0;
            
            if (str.Length > 0)
            {
                char prev = str[0];
                foreach (char element in str)
                {
                    if (numerals[element] > numerals[prev])
                    {
                        // subtract previous amount and do 1 less than current
                        // i.e for IV (4): add 1, then add (5 - 1*2), getting 1 + 3
                        total += numerals[element] - numerals[prev] * 2;
                    }
                    else
                    {
                        total += numerals[element];
                    }
                    prev = element;  // update previous element to use in next iteration
                }
            }
            return total;
        }

        public static string ToWords(this int num)
        {         
            List<int> deez = Digits(num);
            List<string> words = new List<string>();

            foreach (int d in deez)
            {
                
            }

            return "WIP";
        }
    }
}