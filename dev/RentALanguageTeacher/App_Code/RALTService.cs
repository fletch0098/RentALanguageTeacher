using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace RentALanguageTeacher.App_Code
{
    public class RALTService
    {

        //Function to get random number
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }


        /// <summary>
        /// Converts a PayPal datestring into a valid .net datetime value
        /// </summary>
        /// <param name="dateValue">a string containing a PayPal date</param>
        /// <param name="localUtcOffset">the number of hours from UTC/GMT the local 
        /// time is (ie, the timezone where the computer is)</param>
        /// <returns>Valid DateTime value if successful, DateTime.MinDate if not</returns>
        public static DateTime ConvertFromPayPalDate(string rawPayPalDate, int localUtcOffset)
        {
            /* regex pattern splits paypal date into
             * time : hh:mm:ss
             * date : Mmm dd yyyy
             * timezone : PST/PDT
             */
            const string payPalDateRegex = @"(?<time>\d{1,2}:\d{2}:\d{2})\s(?<date>(?<Mmm>[A-Za-z\.]{3,5})\s(?<dd>\d{1,2}),?\s(?<yyyy>\d{4}))\s(?<tz>[A-Z]{0,3})";
            //!important : above line broken over two lines for formatting - rejoin in code editor
            //example 05:49:56 Oct. 18, 2009 PDT
            //        20:48:22 Dec 25, 2009 PST
            Match dateMatch = Regex.Match(rawPayPalDate, payPalDateRegex, RegexOptions.IgnoreCase);
            DateTime time, date = DateTime.MinValue;
            //check to see if the regex pattern matched the supplied string
            if (dateMatch.Success)
            {
                //extract the relevant parts of the date from regex match groups
                string rawDate = dateMatch.Groups["date"].Value;
                string rawTime = dateMatch.Groups["time"].Value;
                string tz = dateMatch.Groups["tz"].Value;

                //create date and time values
                if (DateTime.TryParse(rawTime, out time) && DateTime.TryParse(rawDate, out date))
                {
                    //add the time to the date value to get the datetime value
                    date = date.Add(new TimeSpan(time.Hour, time.Minute, time.Second));
                    //adjust for the pdt timezone.  Pass 0 to localUtcOffset to get UTC/GMT
                    int offset = localUtcOffset + 7; //pdt = utc-7, pst = utc-8
                    if (tz == "PDT")//pacific daylight time
                        date = date.AddHours(offset);
                    else  //pacific standard time
                        date = date.AddHours(offset + 1);
                }
            }
            return date;
        }

        //Do not account for offset
        public static DateTime ConvertFromPayPalDate(string rawPayPalDate)
        {
            /* regex pattern splits paypal date into
             * time : hh:mm:ss
             * date : Mmm dd yyyy
             * timezone : PST/PDT
             */
            const string payPalDateRegex = @"(?<time>\d{1,2}:\d{2}:\d{2})\s(?<date>(?<Mmm>[A-Za-z\.]{3,5})\s(?<dd>\d{1,2}),?\s(?<yyyy>\d{4}))\s(?<tz>[A-Z]{0,3})";
            //!important : above line broken over two lines for formatting - rejoin in code editor
            //example 05:49:56 Oct. 18, 2009 PDT
            //        20:48:22 Dec 25, 2009 PST
            Match dateMatch = Regex.Match(rawPayPalDate, payPalDateRegex, RegexOptions.IgnoreCase);
            DateTime time, date = DateTime.MinValue;
            //check to see if the regex pattern matched the supplied string
            if (dateMatch.Success)
            {
                //extract the relevant parts of the date from regex match groups
                string rawDate = dateMatch.Groups["date"].Value;
                string rawTime = dateMatch.Groups["time"].Value;
                string tz = dateMatch.Groups["tz"].Value;

                //create date and time values
                if (DateTime.TryParse(rawTime, out time) && DateTime.TryParse(rawDate, out date))
                {
                    //add the time to the date value to get the datetime value
                    date = date.Add(new TimeSpan(time.Hour, time.Minute, time.Second));
                }
            }
            return date;
        }

    }
}