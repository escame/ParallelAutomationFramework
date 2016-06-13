using System;
using OpenQA.Selenium.Remote;
using AutomationFrameWork.Driver.Interface;

namespace AutomationFrameWork.Driver.RemoteBrowser
{
    class RemoteBrowser : IBrowsers<RemoteWebDriver, Uri, DesiredCapabilities>
    {
        public RemoteBrowser() { }
        public RemoteWebDriver Driver{ get; set; }
        public DesiredCapabilities DesiredCapabilities
        {
            get
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();
                return capabilities;
            }
        }

        public Uri DriverServices
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void StartDriver(Uri driverServices = null, DesiredCapabilities desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            desiredCapabilities = desiredCapabilities ?? DesiredCapabilities;
            RemoteWebDriver driver = new RemoteWebDriver(driverServices, desiredCapabilities, TimeSpan.FromSeconds(commandTimeOut));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(scriptTimeout));
            if (isMaximize)
                driver.Manage().Window.Maximize();
            Driver = driver;
        }       
    }
}
