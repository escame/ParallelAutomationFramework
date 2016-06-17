using AutomationFrameWork.Driver.Interface;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using System;

namespace AutomationFrameWork.Driver.MobileDriver
{
    class Android : IDrivers<AndroidDriver<AppiumWebElement>, AppiumServiceBuilder, DesiredCapabilities>
    {
        public AndroidDriver<AppiumWebElement> Driver
        {
            get; set;
        }
        public DesiredCapabilities DesiredCapabilities
        {
            get
            {
                DesiredCapabilities capabilities = DesiredCapabilities.Android();
                capabilities.SetCapability("browserName", MobileBrowserType.Chrome);
                capabilities.SetCapability("deviceName", "Android");
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

        public void StartDriver(object driverServices = null, object desiredCapabilities=null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            driverServices = driverServices ?? DriverServices;
            desiredCapabilities = desiredCapabilities ?? DesiredCapabilities;
            AndroidDriver<AppiumWebElement> driver = new AndroidDriver<AppiumWebElement>((AppiumServiceBuilder)driverServices, (DesiredCapabilities)desiredCapabilities, TimeSpan.FromSeconds(commandTimeOut));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(scriptTimeout));
            Driver = driver;
        }
    }
}
