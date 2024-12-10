﻿// See https://aka.ms/new-console-template for more information
using CodingSkills.AsyncVsMultiThread;
using CodingSkills.Palidrome;
using CodingSkills.ParkingBill;
using CodingSkills.ReverseString;
using CodingSkills.SwappingNumber;

Console.WriteLine("Hello, World!");

#region string Manipulation
StringManipulation stringManipulation = new();
stringManipulation.GetReverseString("Hello");
Console.ReadKey();

stringManipulation.GetReverseStringStatement("Good morning Manoj");
Console.ReadKey();

#endregion

#region ParkingBill
//Console.WriteLine("Calculate parkingbill");
//int parkingBill1 = ParkingBill.CalculateParkingBill("17:00", "18:48");
//int parkingBill = ParkingBill.CalculateParkingBill("00:31", "22:31");
//Console.WriteLine("Total ParkingBill is " + parkingBill);
#endregion

#region Palidrome
//Palidrome palidrome = new();
//palidrome.CheckPalidrome();
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

#endregion  

Console.ReadLine();