using System;
using OpenQA.Selenium.PhantomJS;
using AutomationFrameWork.Driver.Interface;
namespace AutomationFrameWork.Driver
{
    class PhantomJSBrowser : IDrivers<PhantomJSDriver, PhantomJSDriverService, PhantomJSOptions>
    {
        public PhantomJSOptions DesiredCapabilities
        {
            get
            {
                PhantomJSOptions options = new PhantomJSOptions();
                return options;
            }
        }

        public PhantomJSDriverService DriverServices
        {
            get
            {
                PhantomJSDriverService services = PhantomJSDriverService.CreateDefaultService();
                services.HideCommandPromptWindow = true;
                services.IgnoreSslErrors = true;
                services.LoadImages = true;               
                services.SuppressInitialDiagnosticInformation = false;
                return services;
            }
        }

        public PhantomJSDriver Drivers(PhantomJSDriverService driverServices = null, PhantomJSOptions desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            driverServices = driverServices ?? DriverServices;
            desiredCapabilities = desiredCapabilities ?? DesiredCapabilities;
            return new PhantomJSDriver(driverServices, desiredCapabilities, TimeSpan.FromSeconds(commandTimeOut));
        }
    }
}
