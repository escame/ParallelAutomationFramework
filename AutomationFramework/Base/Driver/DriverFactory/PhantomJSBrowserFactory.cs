using System;
using AutomationFrameWork.Driver.Interface;
using OpenQA.Selenium.PhantomJS;
using System.Reflection;
using System.Linq;

namespace AutomationFrameWork.Driver.Factory
{
    class PhantomJSBrowserFactory : IFactory<Browser, PhantomJSDriver>
    {       
        public object DesiredCapabilities { get; set; }
        public object DriverServices { get; set; }
        public int CommandTimeout { get; set; }
        public int PageLoadTimeout { get; set; }
        public int ScriptTimeout { get; set; }
        public bool MaximizeBrowser { get; set; }
        public Browser BrowserType { get; set; }
        /// <summary>
        /// This method is used for instance phantomjsdriver
        /// can use for headless browser testing or capture network traffic
        /// </summary>
        /// <param name="type"></param>
        /// <param name="driverServices"></param>
        /// <param name="desiredCapabilities"></param>
        /// <param name="commandTimeOut"></param>
        /// <param name="pageLoadTimeout"></param>
        /// <param name="scriptTimeout"></param>
        /// <param name="isMaximize"></param>
        public PhantomJSBrowserFactory(Browser type, object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            BrowserType = type;
            DriverServices = driverServices;
            DesiredCapabilities = desiredCapabilities;
            CommandTimeout = commandTimeOut;
            PageLoadTimeout = pageLoadTimeout;
            ScriptTimeout = scriptTimeout;
            MaximizeBrowser = isMaximize;
        }
        public PhantomJSDriver GetDriver()
        {
            Type foundClass = Assembly.GetExecutingAssembly().GetTypes()
                     .Where(item => item.Namespace == Constants.HEADLESS_DRIVER_NAME_SPACE && item.Name.Equals(BrowserType.ToString(), StringComparison.OrdinalIgnoreCase))
                     .FirstOrDefault();

            if (foundClass != null)
            {
                object instance = Activator.CreateInstance(foundClass);
                Type classType = instance.GetType();
                MethodInfo method = classType.GetMethod("StartDriver", BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Instance);
                method.Invoke(instance, new object[] { DriverServices, DesiredCapabilities, CommandTimeout, PageLoadTimeout, ScriptTimeout, MaximizeBrowser });
                PropertyInfo property = classType.GetProperty("Driver");
                return (PhantomJSDriver)property.GetValue(instance, null);
            }
            else
                throw new OperationCanceledException("HeadlessBrowser for" + BrowserType + " is not implemented");
        }
    }
}
