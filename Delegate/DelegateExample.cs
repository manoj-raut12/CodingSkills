namespace CodingSkills.Delegate
{
    public class DelegateExample
    {
        Func<int, int, int> func = (a,b)=> a+b;
        public void Delegatesample()
        {
            Console.WriteLine(func(5,10));
        }
    }
}
