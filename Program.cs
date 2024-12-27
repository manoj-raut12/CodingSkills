// See https://aka.ms/new-console-template for more information
using CodingSkills.ArithmaticOperations;
using CodingSkills.AsyncVsMultiThread;
using CodingSkills.Fibonacci;
using CodingSkills.Middleware;
using CodingSkills.Palidrome;
using CodingSkills.ParkingBill;
using CodingSkills.PrimeNumber;
using CodingSkills.ReverseString;
using CodingSkills.SwappingNumber;
using Microsoft.AspNetCore.Builder;

Console.WriteLine("Hello, World!");


//#region PrimeNumber
//PrimeNumber primeNumber = new PrimeNumber();
//primeNumber.CheckPrimeNumber();
//Console.ReadLine();
//#endregion

//#region Fibonacci
////FibonacciSeries fibonacciSeries = new();
////fibonacciSeries.GetFibonacciSeries();
////fibonacciSeries.GetFibonacciSeriesRecursive();
////Console.ReadKey();
//#endregion
//#region Sorting
//SortList sortList = new SortList();
////sortList.SecondHighestNumber();
//sortList.SecondHighestNumberWithoutFun();
//sortList.SecondHighestNumberWithFun();
//Console.ReadKey();
//#endregion

#region string Manipulation
StringManipulation stringManipulation = new();
stringManipulation.LongestWord();
stringManipulation.LongestWordWithoutSplit();
var longestString= stringManipulation.LongestWordWithoutSplitAndLen();
stringManipulation.GetReverseString("Welcome to C#");
Console.ReadKey();

stringManipulation.GetReverseStringStatement("Good morning Manoj");
stringManipulation.GetReverseStringUsingLinq("Good morning Manoj");
stringManipulation.GetRepeatCharCount();

stringManipulation.PairRepeatCharacter();

Console.ReadKey();

#endregion

#region ParkingBill
Console.WriteLine("Calculate parkingbill");
int parkingBill1 = ParkingBill.CalculateParkingBill("17:00", "18:48");
int parkingBill = ParkingBill.CalculateParkingBill("00:31", "22:31");
Console.WriteLine("Total ParkingBill is " + parkingBill);
#endregion

#region Palidrome
Palidrome palidrome = new();
palidrome.CheckPalidrome();
#endregion

#region Swapping Number
SwapNumber number = new SwapNumber();
number.Swap();
#endregion

#region Async Vs Mutlithreading

await AsyncTask.ExecuteAsyncFunctions();
Console.WriteLine();


MultiThread multithreading = new();
multithreading.ExecuteMultithreading();

Console.WriteLine();

SequentialVsParallelAsync sequentialVsParallel = new();
sequentialVsParallel.ExecuteParalleTask();
Console.WriteLine();
sequentialVsParallel.ExecuteAsyncTask();

#endregion  

Console.ReadLine();

#region CustomMiddleWare

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseCustomeMiddleware();
app.RunAsync();
#endregion
Console.ReadKey();  