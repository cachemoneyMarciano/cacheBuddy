using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CacheBuddy.Services
{
    public class VacationTracker
    {
        public String getRemainingVacationDays()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\Zak\Desktop");
            driver.Navigate().GoToUrl("https://me.jpmorganchase.com/mejpmc/");

            return "0";
        }    
    }
}