using AutomationFrameWork.Driver.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;


namespace AutomationFrameWork.Driver
{
    class FirefoxDesktop : IDrivers<IWebDriver, FirefoxBinary, FirefoxProfile>
    {
        public FirefoxProfile DesiredCapabilities
        {
            get
            {
                FirefoxProfile profiles = new FirefoxProfile();
                profiles.AcceptUntrustedCertificates = true;
                profiles.AlwaysLoadNoFocusLibrary = true;
                profiles.AssumeUntrustedCertificateIssuer = false;
                profiles.DeleteAfterUse = true;
                profiles.EnableNativeEvents = true;
                return profiles;
            }
        }
        public FirefoxBinary DriverServices
        {
            get
            {
                FirefoxBinary serivces = new FirefoxBinary();
                serivces.Timeout = TimeSpan.FromSeconds(60);
                return serivces;
            }
        }

        public IWebDriver Drivers(FirefoxBinary driverServices = null, FirefoxProfile desiredCapabilities = null, int commandTimeOut = 60)
        {
            driverServices = driverServices ?? DriverServices;
            desiredCapabilities = desiredCapabilities ?? DesiredCapabilities;
            return new FirefoxDriver(driverServices, desiredCapabilities, TimeSpan.FromSeconds(commandTimeOut));
        }
    }
}
