using OpenQA.Selenium.PhantomJS;
using AutomationFrameWork.Helper;
namespace AutomationFrameWork.Driver.Core
{
    class PhantomJS : Drivers
    {
        protected override object StartDriver (int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            PhantomJSOptions op = (PhantomJSOptions)Drivers.DriverOptions;
            if (op == null)
                op = new PhantomJSOptions();
            PhantomJSDriver driver = new PhantomJSDriver(Drivers.PhantomJSDriverService, op);
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(scriptTimeout));          
            return driver;
        }       
    }
}