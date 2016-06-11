using AutomationFrameWork.Driver.Interface;
using OpenQA.Selenium.Firefox;
using System;


namespace AutomationFrameWork.Driver
{
    class FirefoxDesktop : IDrivers
    {
        public object DesiredCapabilities
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
        public object DriverServices
        {
            get
            {
                FirefoxBinary serivces = new FirefoxBinary();
                serivces.Timeout = TimeSpan.FromSeconds(60);              
                return serivces;
            }
        }

        public object Drivers(object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60)
        {
            driverServices = driverServices ?? DriverServices;
            desiredCapabilities = desiredCapabilities ?? DesiredCapabilities;            
            return new FirefoxDriver((FirefoxBinary)DriverServices,(FirefoxProfile)DesiredCapabilities,TimeSpan.FromSeconds(commandTimeOut));
        }
    }
}
