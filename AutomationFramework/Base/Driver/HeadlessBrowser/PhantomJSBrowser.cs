using System;
using OpenQA.Selenium.PhantomJS;
using AutomationFrameWork.Driver.Interface;
namespace AutomationFrameWork.Driver.HeadlessBrowser
{
    class PhantomJSBrowser : IDrivers<PhantomJSDriver, PhantomJSDriverService, PhantomJSOptions>
    {
        public PhantomJSBrowser() { }
        public PhantomJSDriver Driver { get; set; }
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

        public void StartDriver(object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            driverServices = driverServices ?? DriverServices;
            desiredCapabilities = desiredCapabilities ?? DesiredCapabilities;
            Driver= new PhantomJSDriver((PhantomJSDriverService)driverServices, (PhantomJSOptions)desiredCapabilities, TimeSpan.FromSeconds(commandTimeOut));
        }       
    }
}
