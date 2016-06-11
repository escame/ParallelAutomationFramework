using AutomationFrameWork.Driver.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFrameWork.Driver
{
    class Nexus7 : IDrivers<IWebDriver, ChromeDriverService, ChromeOptions>
    {

        public ChromeOptions DesiredCapabilities
        {
            get
            {
                ChromeOptions options = new ChromeOptions();
                options.LeaveBrowserRunning = true;
                options.EnableMobileEmulation("Nexus 7");
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
            options.EnableMobileEmulation("Nexus 7");
            return new ChromeDriver(driverServices, options, TimeSpan.FromSeconds(commandTimeOut));
        }
    }
}
