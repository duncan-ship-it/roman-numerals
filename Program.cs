using System;
using ExtensionMethods;

namespace Roman
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter an integer or Roman numeral: ");
                var input = Console.ReadLine();

                try
                {
                    if (int.TryParse(input, out int number))
                    {
                        Console.WriteLine(number.ToNumeral());   // convert integer to Roman numerals
                        // Console.WriteLine(number.ToWords());  // convert number to worded number
                    }
                    else
                    {
                        Console.WriteLine(input.ToArabic());     // convert assumed numerals to integer (will throw exception if invalid)
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Exception: {0}", e.Message);
                }             
            }
        }
    }
}