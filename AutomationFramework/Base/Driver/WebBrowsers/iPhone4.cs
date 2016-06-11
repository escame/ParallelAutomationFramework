using AutomationFrameWork.Driver.Interface;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFrameWork.Driver
{
    class iPhone4 : IDrivers
    {

        public object DesiredCapabilities
        {
            get
            {
                ChromeOptions options = new ChromeOptions();
                options.LeaveBrowserRunning = true;
                options.EnableMobileEmulation("Apple iPhone 4");
                return options;
            }
        }
        public object DriverServices
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

        public object Drivers(object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60)
        {
            driverServices = driverServices ?? DriverServices;
            desiredCapabilities = desiredCapabilities ?? DesiredCapabilities;
            var options = (ChromeOptions)desiredCapabilities;
            options.EnableMobileEmulation("Apple iPhone 4");
            return new ChromeDriver((ChromeDriverService)driverServices, options, TimeSpan.FromSeconds(commandTimeOut));
        }
    }
}
