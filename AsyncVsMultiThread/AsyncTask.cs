using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSkills.AsyncVsMultiThread
{
    internal class AsyncTask
    {
        public static async Task FirstTaskAsync()
        {
            Console.WriteLine("First Async Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);
            Console.WriteLine("First Async Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
        }
        public static async Task SecondTaskAsync()
        {
            Console.WriteLine("Second Async Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);
            Console.WriteLine("Second Async Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
        }

        public static async Task ExecuteAsyncFunctions()
        {
            var firstAsync = FirstTaskAsync();
            var secondAsync = SecondTaskAsync();
            await Task.WhenAll(firstAsync, secondAsync);
        }
    }
}
