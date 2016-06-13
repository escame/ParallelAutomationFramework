using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutomationFrameWork.Driver.Interface;
using System.Reflection;
using OpenQA.Selenium;
using AutomationFrameWork.Driver.WebBrowser;
namespace AutomationFrameWork.Driver
{
    public static class DriverManager
    {
        public static IWebDriver WebBrowser(DriverType type)
        {
            switch (type)
            {
                case DriverType.Chrome:
                    ChromeDesktop chrome = new ChromeDesktop();
                    chrome.StartDriver();
                    return chrome.Driver;
                default:
                    return null;
            }
        }
    }   
}
