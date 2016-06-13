using AutomationFrameWork.Driver.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFrameWork.Driver.WebBrowser
{
    class Nexus7 : IBrowsers<IWebDriver, ChromeDriverService, ChromeOptions>
    {
        public Nexus7() { }
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

        public void StartDriver(ChromeDriverService driverServices = null, ChromeOptions desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            driverServices = driverServices ?? DriverServices;
            desiredCapabilities = desiredCapabilities ?? DesiredCapabilities;
            var options = desiredCapabilities;
            options.EnableMobileEmulation("Nexus 7");
            IWebDriver driver = new ChromeDriver(driverServices, options, TimeSpan.FromSeconds(commandTimeOut));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(scriptTimeout));
            if (isMaximize)
                driver.Manage().Window.Maximize();
            Driver=driver;
        }       
    }
}
