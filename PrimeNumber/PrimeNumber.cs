using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSkills.PrimeNumber
{
    public class PrimeNumber
    {
         // 2, 3, 5, 7, 11....
        private bool IsPrimeNumber(int number)
        {
            for( int i=2; i*i<=number; i ++)
            {
                if (number%i == 0) return false;
            }
            return true;
        }

        public void CheckPrimeNumber()
        {
            Console.WriteLine("Enter number to check prime");
            int number = int.Parse(s: Console.ReadLine());
            Console.WriteLine($"Is Number prime : {IsPrimeNumber(number)}");
        }
    }
}
