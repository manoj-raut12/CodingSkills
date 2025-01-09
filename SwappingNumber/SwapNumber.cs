using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSkills.SwappingNumber
{
    internal class SwapNumber
    {
        #region Without using third variable
        public void Swap() 
        {
            int a=10; 
            int b=15;
            Console.WriteLine($"Number before swapping {a} and {b}");
            a = a * b;
            b = a / b;
            a = a / b;

            Console.WriteLine($"Number after swapping {a} and {b}");
        }
        #endregion
    }
}
