using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CacheBuddy.Services
{
    public class ClockService
    {
        private static TimeZoneInfo INDIA_TIME_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        private static TimeZoneInfo UK_TIME_ZONE = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");

        public String getTimeInIndia()
        {
           DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIA_TIME_ZONE);
           return $"The current time in India is: {indianTime.ToString()}!";
        }

        public String getTimeInUK()
        {
           DateTimeOffset ukTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, UK_TIME_ZONE);
           return $"The current time in the UK is: {ukTime.ToString()}!";
        }
    }
}