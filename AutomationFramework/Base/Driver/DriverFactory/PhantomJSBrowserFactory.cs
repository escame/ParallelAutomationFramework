using System;
using AutomationFrameWork.Driver.Interface;
using OpenQA.Selenium.PhantomJS;
using System.Reflection;
using System.Linq;

namespace AutomationFrameWork.Driver.Factory
{
    class PhantomJSBrowserFactory : IFactory
    {       
        public DriverConfiguration Configuration { get; set; }
        public Browser BrowserType { get; set; }
        /// <summary>
        /// This method is used for instance phantomjsdriver
        /// can use for headless browser testing or capture network traffic
        /// </summary>
        /// <param name="type"></param>
        /// <param name="configuration"></param>        
        public PhantomJSBrowserFactory(Browser type, DriverConfiguration configuration)
        {
            BrowserType = type;
            Configuration = configuration;
        }
        public object  GetDriver()
        {
            Type foundClass = Assembly.GetExecutingAssembly().GetTypes()
                     .Where(item => item.Namespace == Constants.HEADLESS_DRIVER_NAME_SPACE && item.Name.Equals(BrowserType.ToString(), StringComparison.OrdinalIgnoreCase))
                     .FirstOrDefault();

            if (foundClass != null)
            {
                object instance = Activator.CreateInstance(foundClass);
                Type classType = instance.GetType();
                MethodInfo method = classType.GetMethod("StartDriver", BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Instance);
                method.Invoke(instance, new object[] {Configuration });
                PropertyInfo property = classType.GetProperty("Driver");
                return property.GetValue(instance, null);
            }
            else
                throw new OperationCanceledException("HeadlessBrowser for" + BrowserType + " is not implemented");
        }
    }
}
