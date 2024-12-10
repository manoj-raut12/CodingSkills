using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSkills.Palidrome
{
    internal class Palidrome
    {
        
        public void CheckPalidrome()
        {
            int number=0;
            Console.WriteLine("Enter number to check palidrome number");
            if (int.TryParse(Console.ReadLine(),CultureInfo.CurrentCulture, out int inptNumber))
                number =inptNumber;
            if(IsPalidrome(number))
                Console.WriteLine($"Number {number} is palidrome");
            else
                Console.WriteLine($"Number {number} is not palidrome");
        }
        private static bool IsPalidrome(int number)
        {
            int temp = number;
            if (temp == ReverseNumber(number))
                return true;
            return false;
        }
        private static int ReverseNumber(int number)
        {
            int remainder;
            int sum = 0;
            
            while (number > 0)
            {
                remainder = number % 10;
                sum = (sum * 10) + remainder;
                number = number / 10;
            }
            return sum;
        }
    }
}
