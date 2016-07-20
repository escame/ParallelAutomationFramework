using AutomationFrameWork.Driver.Interface;
using OpenQA.Selenium.Appium;
using System;
using System.Linq;
using System.Reflection;

namespace AutomationFrameWork.Driver.DriverFactory
{
    class MobileFactory : IFactory
    {       
        public DriverConfiguration Configuration { get; set; }
        public Browser BrowserType { get; set; }
        /// <summary>
        /// This method is use for instance Mobile driver
        /// </summary>
        /// <param name="type"></param>
        /// <param name="configuration"></param>       
        public MobileFactory(Browser type, DriverConfiguration configuration)
        {
            BrowserType = type;
            Configuration = configuration;
        }
        public object GetDriver()
        {
            Type foundClass = Assembly.GetExecutingAssembly().GetTypes()
                     .Where(item => item.Namespace == Constants.MOBILE_DRIVER_NAME_SPACE && item.Name.Equals(BrowserType.ToString(), StringComparison.OrdinalIgnoreCase))
                     .FirstOrDefault();

            if (foundClass != null)
            {
                object instance = Activator.CreateInstance(foundClass);
                Type classType = instance.GetType();
                MethodInfo method = classType.GetMethod("StartDriver", BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Instance);
                method.Invoke(instance, new object[] { Configuration });
                PropertyInfo property = classType.GetProperty("Driver");
                return property.GetValue(instance, null);
            }
            else
                throw new OperationCanceledException("MobileDriver for " + BrowserType + " is not implemented");
        }      
    }
}

