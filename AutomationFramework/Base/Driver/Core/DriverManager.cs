using AutomationFrameWork.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using System.Threading;
namespace AutomationFrameWork.Driver
{
    public static class DriverManager
    {
        private static ThreadLocal<object> _driverStored;
        public static AppiumDriver<AppiumWebElement> MobileDriver
        {
            get
            {
                if (_driverStored == null || _driverStored.Value == null)
                    throw new StepErrorException("Please call method StartWebBrowser before can get WebBrowserDriver");
                return (AppiumDriver<AppiumWebElement>)_driverStored.Value;
            }
            set
            {
                if (_driverStored == null)
                    _driverStored = new ThreadLocal<object>();
                _driverStored.Value = value;
            }
        }
        public static IWebDriver WebBrowserDriver
        {
            get
            {
                if (_driverStored == null || _driverStored.Value == null)
                    throw new StepErrorException("Please call method StartWebBrowser before can get WebBrowserDriver");
                return (IWebDriver)_driverStored.Value;
            }
            set
            {
                if (_driverStored == null)
                    _driverStored = new ThreadLocal<object>();
                _driverStored.Value = value;
            }
        }
        public static PhantomJSDriver PhantomJSBrowserDriver
        {
            get
            {
                if (_driverStored == null || _driverStored.Value == null)
                    throw new StepErrorException("Please call method StartWebBrowser before can get WebBrowserDriver");
                return (PhantomJSDriver)_driverStored.Value;
            }
            set
            {
                if (_driverStored == null)
                    _driverStored = new ThreadLocal<object>();
                _driverStored.Value = value;
            }
        }
        public static RemoteWebDriver RemoteBrowserDriver
        {
            get
            {
                if (_driverStored == null || _driverStored.Value == null)
                    throw new StepErrorException("Please call method StartWebBrowser before can get WebBrowserDriver");
                return (RemoteWebDriver)_driverStored.Value;
            }
            set
            {
                if (_driverStored == null)
                    _driverStored = new ThreadLocal<object>();
                _driverStored.Value = value;
            }
        }
        public static void StartWebBrowser(BrowserType.Browser type, object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {           
            WebBrowserDriver= new WebBrowserFactory(type, driverServices, desiredCapabilities, commandTimeOut, pageLoadTimeout, scriptTimeout, isMaximize).GetDriver();
        }
        public static void StartPhantomJSBrowser(BrowserType.Browser type, object phantomJSServices = null, object phantomJSOptions = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            PhantomJSBrowserDriver = new PhantomJSBrowserFactory(type, phantomJSServices, phantomJSOptions, commandTimeOut, pageLoadTimeout, scriptTimeout, isMaximize).GetDriver();
        }
        public static void StartRemoteBrowser(BrowserType.Browser type, object uri = null, object desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {

        }
        public static void CloseDriver()
        {
            IWebDriver driver = (IWebDriver)_driverStored.Value;
            driver.Quit();
            driver.Dispose();           
            if (_driverStored.Value != null)
                _driverStored.Value = null;
        }
    }
}
