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

        public void GetReverseStringUsingFun(string inputString)
        {
            StringBuilder stringBuilder = new();

            var lstChar = inputString.Reverse().ToList();
            string reverseString = string.Empty;
            foreach (var ch in lstChar)
            {
                reverseString += ch;
            }
            Console.WriteLine($"Reverse string is {reverseString}");
        }

        public void GetRepeatCharCount()
        {
            Console.WriteLine("Enter string to calculate the repeated character");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string inputString = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            Dictionary<char, int> charCounts = new();
            foreach (char ch in inputString)
            {
                if (charCounts.TryGetValue(ch, out int value))
                    charCounts[ch] = ++value;
                else
                    charCounts[ch] = 1;
            }

            foreach (var item in charCounts)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
        }

        public void PairRepeatCharacter()
        {
            Console.WriteLine("Enter string to pair characters");
            string inputString = Console.ReadLine();
            Dictionary<char, int> charCounts = new();
            foreach (Char ch in inputString)
            {
                //Dictonary for storing thhe character and its count
                if (!charCounts.TryGetValue(ch, out int value))
                    charCounts[ch] = 1;
                else
                    charCounts[ch] = ++value;
            }

            foreach (var ch in charCounts)
            {

                int totalPair = ch.Value / 2; //divided by 2 as we need to calculate the pair.
                Console.WriteLine($"Total pairs for character {ch.Key} - {totalPair}");
            }
        }
        #endregion
    }
}
