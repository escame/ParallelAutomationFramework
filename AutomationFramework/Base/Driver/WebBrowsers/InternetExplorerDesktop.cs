using AutomationFrameWork.Driver.Interface;
using System;
using OpenQA.Selenium.IE;

namespace AutomationFrameWork.Driver
{
    class InternetExplorerDesktop : IDrivers
    {
        public object DesiredCapabilities
        {
            get
            {
                InternetExplorerOptions options = new InternetExplorerOptions();
                options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Top;
                options.EnableNativeEvents = true;              
                options.EnsureCleanSession = true;              
                options.IgnoreZoomLevel = true;
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                options.RequireWindowFocus = false;
                options.EnablePersistentHover = false;
                options.PageLoadStrategy = InternetExplorerPageLoadStrategy.Eager;
                options.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Ignore;       
                return options;
            }
        }
        public object DriverServices
        {
            get
            {
                InternetExplorerDriverService serivces = InternetExplorerDriverService.CreateDefaultService();
                serivces.HideCommandPromptWindow = true;
                serivces.Implementation = InternetExplorerDriverEngine.AutoDetect;
                serivces.SuppressInitialDiagnosticInformation = false;
                return serivces;
            }
        }

        public object Drivers(object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60)
        {
            driverServices = driverServices ?? DriverServices;
            desiredCapabilities = desiredCapabilities ?? DesiredCapabilities;
            return new InternetExplorerDriver((InternetExplorerDriverService)DriverServices,(InternetExplorerOptions)DesiredCapabilities,TimeSpan.FromSeconds(commandTimeOut));
        }
    }
}
