using AutomationFrameWork.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using System.Threading;
using AutomationFrameWork.Driver.Factory;
using System;
using System.Reflection;
using System.Linq;

namespace AutomationFrameWork.Driver
{
    public static class DriverManager
    {
        private static ThreadLocal<object> _driverStored=new ThreadLocal<object>();
        public static AppiumDriver<AppiumWebElement> MobileDriver
        {
            get
            {
                return (AppiumDriver<AppiumWebElement>)_driverStored.Value;
            }
        }
        public static IWebDriver WebBrowserDriver
        {
            get
            {
                return (IWebDriver)DriverStored;
            }
        }
        public static PhantomJSDriver PhantomJSBrowserDriver
        {
            get
            {
                return (PhantomJSDriver)DriverStored;
            }
        }
        public static RemoteWebDriver RemoteBrowserDriver
        {
            get
            {
                return (RemoteWebDriver)DriverStored;
            }
        }
        private static object DriverStored
        {
            get
            {
                if (_driverStored == null || _driverStored.Value == null)
                    throw new StepErrorException("Please call method 'StartWebBrowser','StartPhantomJSBrowser' or 'StartRemoteBrowser' before can get Driver");
                return _driverStored.Value;
            }
            set
            {                
                _driverStored.Value = value;
            }
        }
        public static void StartDriver(FactoryType factoryType, BrowserType.Browser type, object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            Type foundClass = Assembly.GetExecutingAssembly().GetTypes()
                         .Where(item => item.Namespace == Constants.FACTORY_NAME_SPACE && item.Name.Equals(factoryType.ToString(), StringComparison.OrdinalIgnoreCase))
                         .FirstOrDefault();

            if (foundClass != null)
            {
                Object[] args = { type, driverServices, desiredCapabilities, commandTimeOut, pageLoadTimeout, scriptTimeout, isMaximize };
                object instance = Activator.CreateInstance(foundClass,args);
                Type classType = instance.GetType();
                MethodInfo method = classType.GetMethod("GetDriver", BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Instance);                         
                DriverStored = method.Invoke(instance, null);                
            }
            else
                throw new NotImplementedException("Factory for " + factoryType + " is not implemented");
        }     
        public static void CloseDriver()
        {
            IWebDriver driver = (IWebDriver)DriverStored;
            driver.Quit();
            driver.Dispose();
            if (DriverStored != null)
                DriverStored = null;
        }
    }
}
