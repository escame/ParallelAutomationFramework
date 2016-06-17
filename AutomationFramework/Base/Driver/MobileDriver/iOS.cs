using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using AutomationFrameWork.Driver.Interface;
using OpenQA.Selenium.Appium.Enums;

namespace AutomationFrameWork.Driver.MobileDriver
{
    class iOS : IDrivers<IOSDriver<AppiumWebElement>, AppiumServiceBuilder, DesiredCapabilities>
    {
        public IOSDriver<AppiumWebElement> Driver
        {
            get; set;
        }
        public DesiredCapabilities DesiredCapabilities
        {
            get
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();
                capabilities.SetCapability("browserName", MobileBrowserType.Safari);
                capabilities.SetCapability("deviceName", "iOS");
                return capabilities;
            }
        }

        public AppiumServiceBuilder DriverServices
        {
            get
            {
                AppiumServiceBuilder serices = new AppiumServiceBuilder();
                serices.UsingAnyFreePort();
                serices.Build();
                return serices;
            }
        }

        public void StartDriver(object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            driverServices = driverServices ?? DriverServices;
            desiredCapabilities = desiredCapabilities ?? DesiredCapabilities;
            IOSDriver<AppiumWebElement> driver = new IOSDriver<AppiumWebElement>((AppiumServiceBuilder)driverServices, (DesiredCapabilities)desiredCapabilities, TimeSpan.FromSeconds(commandTimeOut));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(scriptTimeout));
            Driver = driver;
        }
    }
}
