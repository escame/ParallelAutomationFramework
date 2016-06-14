using AutomationFrameWork.Driver.Interface;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium;
namespace AutomationFrameWork.Driver.WebBrowser
{
    class iPhone6 : IDrivers<IWebDriver, ChromeDriverService, ChromeOptions>
    {
        public iPhone6() { }
        public IWebDriver Driver { get; set; }
        public ChromeOptions DesiredCapabilities
        {
            get
            {
                ChromeOptions options = new ChromeOptions();
                options.LeaveBrowserRunning = true;
                options.EnableMobileEmulation("Apple iPhone 6");
                return options;
            }
        }
        public ChromeDriverService DriverServices
        {
            get
            {
                ChromeDriverService serivces = ChromeDriverService.CreateDefaultService();
                serivces.EnableVerboseLogging = false;
                serivces.HideCommandPromptWindow = true;
                serivces.SuppressInitialDiagnosticInformation = false;
                return serivces;
            }
        }

        public void StartDriver(object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            driverServices = driverServices ?? DriverServices;
            desiredCapabilities = desiredCapabilities ?? DesiredCapabilities;
            var options = (ChromeOptions)desiredCapabilities;
            options.EnableMobileEmulation("Apple iPhone 6");
            IWebDriver driver = new ChromeDriver((ChromeDriverService)driverServices, options, TimeSpan.FromSeconds(commandTimeOut));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(scriptTimeout));
            if (isMaximize)
                driver.Manage().Window.Maximize();
            Driver = driver;
        }
    }
}
