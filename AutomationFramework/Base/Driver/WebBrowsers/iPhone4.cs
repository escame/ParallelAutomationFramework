using AutomationFrameWork.Driver.Interface;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium;
namespace AutomationFrameWork.Driver
{
    class iPhone4 : IDrivers<IWebDriver, ChromeDriverService, ChromeOptions>
    {

        public ChromeOptions DesiredCapabilities
        {
            get
            {
                ChromeOptions options = new ChromeOptions();
                options.LeaveBrowserRunning = true;
                options.EnableMobileEmulation("Apple iPhone 4");
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

        public IWebDriver Drivers(ChromeDriverService driverServices = null, ChromeOptions desiredCapabilities = null, int commandTimeOut = 60)
        {
            driverServices = driverServices ?? DriverServices;
            desiredCapabilities = desiredCapabilities ?? DesiredCapabilities;
            var options = desiredCapabilities;
            options.EnableMobileEmulation("Apple iPhone 4");
            return new ChromeDriver(driverServices, options, TimeSpan.FromSeconds(commandTimeOut));
        }
    }
}
