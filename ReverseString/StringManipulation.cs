using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSkills.ReverseString
{
    internal class StringManipulation
    {
        #region reverse string without using method
        private static  string ReverseString(string inputString)
        {
            if(string.IsNullOrEmpty(inputString)) return inputString;
            string result = string.Empty;
            for (int i = inputString.Length-1; i >= 0; i-- )

            {
                result += inputString[i];
            } 
            
            return result;
        }

        public void GetReverseString(string inputString) { 
        string reverseString = ReverseString(inputString);
            Console.WriteLine($"ReverseString is : {reverseString}");
        }

        public void GetReverseStringStatement(string inputString)
        {
            StringBuilder stringBuilder = new StringBuilder();

            List<string> list = inputString.Split(" ")
                                           .ToList();

            foreach (string str in list)
            {
                stringBuilder.Append(ReverseString(str));
                stringBuilder.Append(' ');
            }

            Console.WriteLine($"Reverse string is {stringBuilder}"); ;
        }
#endregion
    }
}
