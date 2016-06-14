using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
namespace AutomationFrameWork.Driver
{
    public static class DriverManager
    {    
        public static IWebDriver WebBrowser(BrowserType.WebBrowser type, object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            WebBrowserFactory fac = new WebBrowserFactory(type, driverServices, desiredCapabilities, commandTimeOut, pageLoadTimeout, scriptTimeout, isMaximize);
            return fac.GetDriver();
        }
        public static PhantomJSDriver PhantomJSBrowser(BrowserType.HeadlessBrowser type, object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            return null;
        }
        public static RemoteWebDriver RemoteBrowser(BrowserType.RemoteBrowser type, object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            return null;
        }
    }
}
