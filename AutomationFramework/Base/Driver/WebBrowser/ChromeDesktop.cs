using System;
using OpenQA.Selenium.Chrome;
using AutomationFrameWork.Driver.Interface;
using OpenQA.Selenium;

namespace AutomationFrameWork.Driver.WebBrowser
{
    class ChromeDesktop : IBrowsers<IWebDriver, ChromeDriverService, ChromeOptions>
    {
        public ChromeDesktop() { }
        public IWebDriver Driver
        {
            get; set;
        }
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
        public void StartDriver(ChromeDriverService driverServices = null, ChromeOptions desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            driverServices = driverServices ?? DriverServices;
            desiredCapabilities = desiredCapabilities ?? DesiredCapabilities;
            IWebDriver driver = new ChromeDriver(driverServices, desiredCapabilities, TimeSpan.FromSeconds(commandTimeOut));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(scriptTimeout));
            if (isMaximize)
                driver.Manage().Window.Maximize();
            Driver = driver;
        }
    }
}
