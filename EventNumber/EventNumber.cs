namespace CodingSkills.EventNumber
{
    public class EventNumber
    {
        public void GetEventNumber()
        {
            List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // Print event numbers

            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                    Console.WriteLine(number);
            }
        }

        public void GetEventNumberUsingLinq()
        {
            List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // Print event numbers

            var evenNumbers = numbers.Where(x=>x%2==0).ToList();
            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
