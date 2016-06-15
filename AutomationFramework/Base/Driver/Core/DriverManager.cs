using AutomationFrameWork.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using System.Threading;
namespace AutomationFrameWork.Driver
{
    public class DriverManager
    {
        private static ThreadLocal<IWebDriver> _webDriver;
        private static ThreadLocal<PhantomJSDriver> _phantomJSDriver;
        private static ThreadLocal<RemoteWebDriver> _remotebDriver;
        public DriverManager()
        {
        }
        public static IWebDriver WebBrowserDriver
        {
            get
            {
                if (_webDriver == null || _webDriver.Value == null)
                    throw new StepErrorException("Please call method StartWebBrowser before can get WebBrowserDriver");
                return _webDriver.Value;
            }
            set
            {
                if (_webDriver == null)
                    _webDriver = new ThreadLocal<IWebDriver>();
                _webDriver.Value = value;
            }
        }
        public static PhantomJSDriver PhantomJSBrowserDriver
        {
            get
            {
                if (_phantomJSDriver == null || _phantomJSDriver.Value == null)
                    throw new StepErrorException("Please call method StartWebBrowser before can get WebBrowserDriver");
                return _phantomJSDriver.Value;
            }
            set
            {
                if (_phantomJSDriver == null)
                    _phantomJSDriver = new ThreadLocal<PhantomJSDriver>();
                _phantomJSDriver.Value = value;
            }
        }
        public static RemoteWebDriver RemoteBrowserDriver
        {
            get
            {
                if (_remotebDriver == null || _remotebDriver.Value == null)
                    throw new StepErrorException("Please call method StartWebBrowser before can get WebBrowserDriver");
                return _phantomJSDriver.Value;
            }
            set
            {
                if (_remotebDriver == null)
                    _remotebDriver = new ThreadLocal<RemoteWebDriver>();
                _remotebDriver.Value = value;
            }
        }
        public static void StartWebBrowser(BrowserType.WebBrowser type, object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {           
            WebBrowserDriver= new WebBrowserFactory(type, driverServices, desiredCapabilities, commandTimeOut, pageLoadTimeout, scriptTimeout, isMaximize).GetDriver();
        }
        public static void StartPhantomJSBrowser(BrowserType.HeadlessBrowser type, object phantomJSServices = null, object phantomJSOptions = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            RemoteBrowserDriver = new PhantomJSBrowserFactory(type, phantomJSServices, phantomJSOptions, commandTimeOut, pageLoadTimeout, scriptTimeout, isMaximize).GetDriver();
        }
        public static void StartRemoteBrowser(BrowserType.RemoteBrowser type, object uri = null, object desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {

        }
    }
}
