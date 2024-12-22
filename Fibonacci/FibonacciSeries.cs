using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CodingSkills.Fibonacci
{
    internal class FibonacciSeries
    {
        public void GetFibonacciSeries()
        {
            Console.WriteLine("Enter the number of terms :");
            var number =  int.Parse(Console.ReadLine());
            int first = 0, second = 1;
            for (int i = 0; i < number; i++) { 
                Console.Write($"{first} ");
                int temp = first + second;
                first = second;
                second = temp;
            }

            
        }

        public void GetFibonacciSeriesRecursive()
        {
            Console.WriteLine("Enter the number of terms :");
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                Console.Write($"{Fibonacci(i)} ");
            }
        }
        public static int Fibonacci(int number)
        {
            if (number == 0)
                return 0;
            else if (number == 1)
                return 1;
            return Fibonacci(number-1) + Fibonacci(number-2);
        }
    }
}
