using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameWork.Driver
{
    public static class WebDriverExtension
    {
        public static IJavaScriptExecutor JavaScript(this IWebDriver driver)
        { 
            return (driver as IJavaScriptExecutor);
        }
        public static void MoveToClick(this IWebElement element)
        {            
            try
            {
                
                DriverManager<IWebDriver>.Driver.JavaScript().ExecuteScript("arguments[0].scrollIntoView();", element);
                element.Click();
            }
            catch (WebDriverException)
            {
                DriverManager<IWebDriver>.Driver.JavaScript().ExecuteScript("window.scrollTo(0, 0);");
                DriverManager<IWebDriver>.Driver.JavaScript().ExecuteScript("arguments[0].scrollIntoView();", element);
                element.Click();
            }
        }
    }
}
