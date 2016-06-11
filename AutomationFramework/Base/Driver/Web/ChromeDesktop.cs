using System;
using OpenQA.Selenium.Chrome;
using AutomationFrameWork.Driver.Interface;

namespace AutomationFrameWork.Driver
{
    class ChromeDesktop : IDrivers
    {
       

        public object DesiredCapabilities
        {
            get
            {
                ChromeOptions options = new ChromeOptions();
                options.LeaveBrowserRunning = true;
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
            return new ChromeDriver((ChromeDriverService)driverServices, (ChromeOptions)desiredCapabilities, TimeSpan.FromSeconds(commandTimeOut));
        }
    }
}
