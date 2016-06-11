using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace AutomationFrameWork.Driver
{
    class Firefox : Drivers
    {
        protected override object StartDriver(int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            IWebDriver driver = new FirefoxDriver(Drivers.DesiredCapabilitiesCore);
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(scriptTimeout));
            if (isMaximize)
                driver.Manage().Window.Maximize();
            return driver;
        }
    }
}