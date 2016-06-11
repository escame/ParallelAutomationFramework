using OpenQA.Selenium.Chrome;
using AutomationFrameWork.Helper;
using OpenQA.Selenium;

namespace AutomationFrameWork.Driver
{
    class EmulationiPhone5 : Drivers
    {
        protected override object StartDriver(int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            ChromeOptions op = (ChromeOptions)Drivers.DriverOptions;
            if (op == null)
                op = new ChromeOptions();
            op.EnableMobileEmulation("Apple iPhone 5");
            IWebDriver driver = new ChromeDriver(DriverHelper.Instance.DriverPath, op);
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(scriptTimeout));
            if (isMaximize)
                driver.Manage().Window.Maximize();
            return driver;
        }
    }
}