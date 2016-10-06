using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CacheBuddy.Services
{
    public class ClockService
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public String getTimeInIndia()
        {
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            Console.WriteLine(indianTime);
           return $"The time in India is: {indianTime.ToString()}!";
        }
    }
}