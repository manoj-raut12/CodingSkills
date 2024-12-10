using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodingSkills.ParkingBill
{
    public class ParkingBill
    {
       
        public static int CalculateParkingBill(string entryTime, string leftTime)
        {
            int entryFees = 2;
            int parkingChargeprHr = 4;
            int parkingChargeFirstHr = 3;
            int totalParkingBill;

            // Check Format 
            if (!IsValidInput(entryTime, leftTime))
                return 0;
            //Convert Time into int
            //using split method
            List<string> splitEntryTime = entryTime.Split(":").ToList();
            List<string> splitLeftTIme =leftTime.Split(":").ToList();
            int entryHours = Convert.ToInt32(splitEntryTime[0]);
            int leftHours = Convert.ToInt32(splitLeftTIme[0]);

            //Get hours and minute using Timespan method
            if (TimeSpan.TryParse(entryTime,CultureInfo.CurrentCulture, out TimeSpan entryResult))
            {
             
                Console.WriteLine("Using Time span entry hrs: " + entryResult.Hours);
                Console.WriteLine("Using Time span entry minutes: " + entryResult.Minutes);
            }
            if (TimeSpan.TryParse(leftTime, CultureInfo.CurrentCulture, out TimeSpan leftResult))
            {

                Console.WriteLine("Using Time span entry hrs: " + leftResult.Hours);
                Console.WriteLine("Using Time span entry minutes: " + leftResult.Minutes);
            }
            TimeSpan differenceTiemspan = leftResult - entryResult;

            //TimeSpan calculation
            if (differenceTiemspan.TotalHours > 2)
            {
                totalParkingBill = entryFees + parkingChargeFirstHr;
                int totalHrToBeConsider = Convert.ToInt16(differenceTiemspan.TotalHours);

                totalParkingBill = +(totalHrToBeConsider - 1 * parkingChargeprHr);
            }
            else
            {
                totalParkingBill = entryFees + parkingChargeFirstHr;
            }

            int difference = leftHours - entryHours;
            if (entryHours == leftHours || difference == 1)
            {
                totalParkingBill = entryFees + parkingChargeFirstHr;
                if ((differenceTiemspan.TotalHours%1) > 0)
                {
                    int totalHr = Convert.ToInt32(differenceTiemspan.TotalHours);
                    totalParkingBill = totalParkingBill + (totalHr - 1) * 4;
                }
            }
            else
            {
                int totalHr = Convert.ToInt32(differenceTiemspan.TotalHours);
                double minutes =  differenceTiemspan.TotalHours%1;
                if (minutes < 0.5 && minutes > 0 )
                {
                    totalHr += 1;
                }
                totalParkingBill = entryFees + parkingChargeFirstHr + ((totalHr - 1) * parkingChargeprHr);
            }

            return totalParkingBill;
        }

        private static bool IsValidInput(string entryTime, string leftTime)
        {
            if (string.IsNullOrEmpty(entryTime)) return false;
            if (string.IsNullOrEmpty(leftTime)) return false;
            string pattern = @"^([01]?[0-9]|2[0-3]):[0-5][0-9]$";
            if (!Regex.IsMatch(entryTime,pattern)) return false;
            if (!Regex.IsMatch(leftTime, pattern)) return false;
            if (TimeSpan.Parse(entryTime,CultureInfo.CurrentCulture) > TimeSpan.Parse(leftTime, CultureInfo.CurrentCulture)) return false;
            return true;
        }
    }
}
