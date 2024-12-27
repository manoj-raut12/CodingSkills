using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSkills.ReverseString
{
    internal class StringManipulation
    {
        #region reverse string without using LINQ
        /// <summary>
        /// Reverse string using character index
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private static string ReverseStringUsingFor(string inputString)
        {
            if (string.IsNullOrEmpty(inputString)) return inputString;
            string result = string.Empty;
            for (int i = inputString.Length - 1; i >= 0; i--)

            {
                result += inputString[i];
            }
           
            return result;
        }

        /// <summary>
        /// Reverse string using Foreach 
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private static string ReverseStringUsingForeach(string inputString)
        {
            if (string.IsNullOrEmpty(inputString)) return inputString;
            string result = string.Empty;
            foreach (char ch in inputString)
            {
                result +=ch;
            }
            return result;
        }

        public void GetReverseString(string inputString)
        {
            string reverseString = ReverseStringUsingFor(inputString);
            Console.WriteLine($"ReverseString is : {reverseString}");
        }

        /// <summary>
        /// Reveser statement using stringbuilder and foreach
        /// </summary>
        /// <param name="inputString"></param>
        public void GetReverseStringStatement(string inputString)
        {
            StringBuilder stringBuilder = new StringBuilder();

            List<string> list = inputString.Split(" ")
                                           .ToList();

            foreach (string str in list)
            {
                stringBuilder.Append(ReverseStringUsingForeach(str));
                stringBuilder.Append(' ');
            }

            Console.WriteLine($"Reverse string is {stringBuilder}"); ;
        }

        /// <summary>
        /// Reveser string using LINQ
        /// </summary>
        /// <param name="inputString"></param>
        public void GetReverseStringUsingLinq(string inputString)
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
        #endregion
        #region Repeat character in string
        /// <summary>
        /// Get repeat character from string
        /// </summary>
        public void GetRepeatCharCount()
        {
            Console.WriteLine("Enter string to get the repeated character count");
            string inputString = Console.ReadLine();

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

        /// <summary>
        /// Get the count of pair from string
        /// </summary>
        public void PairRepeatCharacter()
        {
            Console.WriteLine("Enter string to pair characters");
            string inputString = Console.ReadLine();
            Dictionary<char, int> charCounts = new();
            foreach (Char ch in inputString)
            {
                //Dictonary for storing the character and its count
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
        #region Longest word in statement
        /// <summary>
        /// Get the longest word from statement
        /// </summary>
        public void LongestWord()
        {
            Console.WriteLine("Enter statement to check longest word");
            string inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString)) return;
            List<string> wordsInStatement = inputString.Split(" ").ToList();
            int maxLength = 0;
            string maxLengthWord = string.Empty;
            foreach (var word in wordsInStatement)
            {
                if (maxLength < word.Length)
                {
                    maxLength = word.Length;
                    maxLengthWord = word;
                }
            }
            Console.WriteLine($"longest word is {maxLengthWord}");
        }
        /// <summary>
        /// Get the longest word from statement without using split
        /// </summary>
        public void LongestWordWithoutSplit()
        {
            Console.WriteLine("Enter statement to check longest word");
            string inputString = Console.ReadLine();
            int currentWordLength = 0;
            int MaxWordLength = 0;
            string currentWord = string.Empty;
            string longestWord = string.Empty;

            for (int i = 0; i <= inputString.Length - 1; i++)
            {
                if (inputString[i] != ' ')
                {
                    currentWord += inputString[i];
                    currentWordLength++;
                }

                else
                {
                    if (currentWordLength > MaxWordLength)
                    {
                        longestWord = currentWord;
                        MaxWordLength = currentWordLength;
                    }
                    currentWord = "";
                    currentWordLength = 0;
                }

            }
            if (currentWordLength > MaxWordLength) //condition for last word check
            {
                longestWord = currentWord;
            }
            Console.WriteLine($"longest word is {longestWord}");
        }
        /// <summary>
        /// Get the longest word from statement without using split and length
        /// </summary>
        /// <returns></returns>
        public string LongestWordWithoutSplitAndLen()
        {
            Console.WriteLine("Enter statement to check longest word");
            string inputString = Console.ReadLine();
            int currentWordLength = 0;
            int MaxWordLength = 0;
            string currentWord = string.Empty;
            string longestWord = string.Empty;
            if (string.IsNullOrEmpty(inputString))
                return "input string is empty";
            
            foreach (char ch in inputString)
            {
                if (!char.IsWhiteSpace(ch))
                {
                    currentWord += ch;
                    currentWordLength++;
                }
                else
                {
                    if (currentWordLength > MaxWordLength)
                    {
                        longestWord = currentWord;
                        MaxWordLength = currentWordLength;
                    }
                    currentWord = "";
                    currentWordLength = 0;
                }
            }
            if (currentWordLength > MaxWordLength)
            {
                longestWord = currentWord;
            }
            Console.WriteLine($"longest word is {longestWord}");
            return longestWord;
        }
        #endregion
    }
}
