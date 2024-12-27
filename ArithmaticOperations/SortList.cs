namespace CodingSkills.ArithmaticOperations
{
    public class SortList
    {
        public void SecondHighestNumber() 
        {
            List<int> numbers = new() { 1, 2, 6, 57, 48 };
            int maxNumber = numbers.Max(x => x);
           numbers =numbers.Where(x=>x!=maxNumber).ToList();
            maxNumber = numbers.Max(x => x);
            Console.WriteLine($"second highest number is {maxNumber}");
            //foreach (int i in numbers)
            //{
            //    Console.WriteLine($"{i},");
            //}
        }

        /// <summary>
        /// Get the secondHighest number from list without using any in built mathods
        /// </summary>
        public void SecondHighestNumberWithoutLinq()
        {
            List<int> numbers = new() { 50, 1, 45,75,2, 6,99, 57, 48 };

            int highestNumber = int.MinValue;
            int secondHighestNumber = int.MinValue;
            foreach (int num in numbers) 
            {

                if (num > highestNumber)
                {
                    secondHighestNumber = highestNumber;
                    highestNumber = num;
                }
                else if (num > secondHighestNumber && num != highestNumber)
                {
                    secondHighestNumber = num;
                }
            }
            Console.WriteLine($"Second highest number {secondHighestNumber}");
        }

        public void SecondHighestNumberWithLinq()
        {
            List<int> numbers = [50, 1, 45, 75, 2, 6, 99, 57, 48];
            var secondHighestNumber = numbers.Where(x => x != numbers.Max())
                                             .AsEnumerable()
                                             .Max();
            
            Console.WriteLine($"Second highest number {secondHighestNumber}");
        }
    }
}
