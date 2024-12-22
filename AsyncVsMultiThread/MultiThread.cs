using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSkills.AsyncVsMultiThread
{
    internal class MultiThread
    {
        public void FirstMethod()
        {
            Console.WriteLine("First Method on Thread with Id: " + Environment.CurrentManagedThreadId);
            Thread.Sleep(10);
            Console.WriteLine("First Method Continuation on Thread with Id: " + Environment.CurrentManagedThreadId);
        }
        public void SecondMethod()
        {
            Console.WriteLine("Second Method on Thread with Id: " + Environment.CurrentManagedThreadId);
            Thread.Sleep(10);
            Console.WriteLine("Second Method Continuation on Thread with Id: " + Environment.CurrentManagedThreadId);
        }

        public void ExecuteMultithreading()
        {
            Thread t1 = new(new ThreadStart(FirstMethod));
            Thread t2 = new(new ThreadStart(SecondMethod));

            t1.Start();
            t2.Start();

        }
    }
}
