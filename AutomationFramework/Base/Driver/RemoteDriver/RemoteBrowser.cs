using System;
using OpenQA.Selenium.Remote;
using AutomationFrameWork.Driver.Interface;

namespace AutomationFrameWork.Driver.RemoteDriver
{
    class RemoteBrowser : IDrivers<RemoteWebDriver>
    {
        public RemoteBrowser() { }
        public RemoteWebDriver Driver { get; set; }
        public object DesiredCapabilities
        {
            get
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();
                return capabilities;
            }
        }

        public object DriverServices
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void StartDriver(DriverConfiguration configuarion)
        {
            configuarion.DesiredCapabilities = configuarion.DesiredCapabilities ?? DesiredCapabilities;
            RemoteWebDriver driver = new RemoteWebDriver(configuarion.RemoteUri, (DesiredCapabilities)configuarion.DesiredCapabilities, TimeSpan.FromSeconds(configuarion.CommandTimeout));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(configuarion.PageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(configuarion.ScriptTimeout));
            if (configuarion.MaximizeBrowser)
                driver.Manage().Window.Maximize();
            Driver = driver;
        }
    }
}
