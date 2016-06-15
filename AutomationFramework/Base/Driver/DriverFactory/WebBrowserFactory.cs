using OpenQA.Selenium;
using AutomationFrameWork.Driver.Interface;
using System;
using System.Linq;
using System.Reflection;
namespace AutomationFrameWork.Driver.Factory
{
    class WebBrowserFactory : IFactory<BrowserType.Browser, IWebDriver>
    {          
        public object DesiredCapabilities { get; set; }
        public object DriverServices { get; set; }
        public int CommandTimeout { get; set; }
        public int PageLoadTimeout { get; set; }
        public int ScriptTimeout { get; set; }
        public bool MaximizeBrowser { get; set; }

        public BrowserType.Browser BrowserType { get; set; }

        public WebBrowserFactory(BrowserType.Browser type, object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false) {
            BrowserType = type;
            DriverServices = driverServices;
            DesiredCapabilities = desiredCapabilities;
            CommandTimeout = commandTimeOut;
            PageLoadTimeout = pageLoadTimeout;
            ScriptTimeout = scriptTimeout;
            MaximizeBrowser = isMaximize;           
        }
        public IWebDriver GetDriver()
        {
            Type foundClass = Assembly.GetExecutingAssembly().GetTypes()
                     .Where(item => item.Namespace == Constants.WEB_DRIVER_NAME_SPACE && item.Name.Equals(BrowserType.ToString(), StringComparison.OrdinalIgnoreCase)) 
                     .FirstOrDefault();
                    
            if (foundClass != null)
            {             
                object instance = Activator.CreateInstance(foundClass);
                Type classType = instance.GetType();
                MethodInfo method = classType.GetMethod("StartDriver", BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Instance);
                method.Invoke(instance, new object[] { DriverServices, DesiredCapabilities, CommandTimeout, PageLoadTimeout, ScriptTimeout, MaximizeBrowser });
                PropertyInfo property = classType.GetProperty("Driver");
                return (IWebDriver)property.GetValue(instance, null);               
            }
            else
                throw new NotImplementedException("Browser "+BrowserType +" is not implemented");
        }
    }
}
