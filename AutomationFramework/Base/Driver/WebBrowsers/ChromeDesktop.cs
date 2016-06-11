using System;
using OpenQA.Selenium.Chrome;
using AutomationFrameWork.Driver.Interface;
using OpenQA.Selenium;

namespace AutomationFrameWork.Driver
{
    class ChromeDesktop : IDrivers<IWebDriver, ChromeDriverService, ChromeOptions>
    {
       

        public ChromeOptions DesiredCapabilities
        {
            get
            {
                ChromeOptions options = new ChromeOptions();
                options.LeaveBrowserRunning = true;
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
            return new ChromeDriver(driverServices, desiredCapabilities, TimeSpan.FromSeconds(commandTimeOut));
        }
    }
}
