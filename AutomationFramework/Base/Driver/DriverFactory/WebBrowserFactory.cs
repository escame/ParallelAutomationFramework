using OpenQA.Selenium;
using AutomationFrameWork.Driver.Interface;
using System;
using System.Linq;
using System.Reflection;
namespace AutomationFrameWork.Driver.Factory
{
    class WebBrowserFactory : IFactory
    {       
        public DriverConfiguration Configuration { get; set; }
        public Browser BrowserType { get; set; }
        public WebBrowserFactory() { }
        /// <summary>
        /// This method is use for instance Desktop Web Browser
        /// Ex: Chrome, IE, Firefox...
        /// </summary>
        /// <param name="type"></param>
        /// <param name="configuration"></param>       
        public WebBrowserFactory(Browser type, DriverConfiguration configuration) 
        {
            BrowserType = type;
            Configuration = configuration;         
        }
        public IWebDriver GetDriver<IWebDriver>()
        {
            Type foundClass = Assembly.GetExecutingAssembly().GetTypes()
                     .Where(item => item.Namespace == Constants.WEB_DRIVER_NAME_SPACE && item.Name.Equals(BrowserType.ToString(), StringComparison.OrdinalIgnoreCase)) 
                     .FirstOrDefault();
                    
            if (foundClass != null)
            {             
                object instance = Activator.CreateInstance(foundClass);
                Type classType = instance.GetType();
                MethodInfo method = classType.GetMethod("StartDriver", BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Instance);
                method.Invoke(instance, new object[] { Configuration });
                PropertyInfo property = classType.GetProperty("Driver");
                return (IWebDriver)property.GetValue(instance, null);               
            }
            else
                throw new OperationCanceledException("WebBrowser for"+BrowserType +" is not implemented");
        }
    }
}
