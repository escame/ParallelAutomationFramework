using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;

namespace AutomationFrameWork.Driver.Core
{
    public class Drivers 
    {
        static readonly object syncRoot = new Object();
        protected static ThreadLocal<object> driverStored = new ThreadLocal<object>();
        protected static ThreadLocal<DesiredCapabilities> desiredCapabilities = new ThreadLocal<DesiredCapabilities>();
        protected static ThreadLocal<object> optionStorage = new ThreadLocal<object>(); 
        /// <summary>
        /// This method is use for
        /// scan all class driver with correct name via DriverType 
        /// and invoke mehod StartDriver
        /// </summary>
        /// <param name="driverType"></param>
        protected static void StartDrivers (DriverType driverType)
        {
            List<Type> listClass = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                      .Where(t => t.Namespace == "AutomationFrameWork.Driver.Core")
                      .ToList();
            foreach (Type className in listClass)
            {
                if (className.Name.ToString().ToLower().Equals(driverType.ToString().ToLower()))
                {
                    MethodInfo method = className.GetMethod("StartDriver", BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.NonPublic);
                    FieldInfo field = className.GetField("instance",
                        BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                    object instance = field.GetValue(null);
                    method.Invoke(instance, Type.EmptyTypes);
                }
            }
        }
        /// <summary>
        /// This method use for close driver 
        /// </summary>
        protected static void CloseDriver()
        {
            IWebDriver driver = (IWebDriver)driverStored.Value;
            driver.Quit();
            driver.Dispose();
            driverStored.Value = null;
        }
        /// <summary>
        /// This method is use 
        /// for return object with can be MobileDriver or WebDriver
        /// </summary>
        /// <returns></returns>
        protected static object DriverStorage
        {
            get
            {
                return driverStored.Value;
            }
            set
            {
                driverStored.Value = value;
            }
        }
        /// <summary>
        /// This method is use 
        /// for setting DesiredCapabilities for Remote Driver, Firefox Driver, PhantomJs Driver
        /// </summary>
        protected static DesiredCapabilities DesiredCapabilities
        {
            get
            {
                if (Drivers.desiredCapabilities.Value == null)
                    Drivers.desiredCapabilities.Value = new DesiredCapabilities();
                return Drivers.desiredCapabilities.Value;
            }
            set
            {
                Drivers.desiredCapabilities.Value = value;
            }
        }
        /// <summary>
        /// This method is use
        /// for return DriverOption like ChromeOption, InternetExplorerOption
        /// </summary>
        protected static object DriverOptions
        {
            get
            {
                return optionStorage.Value;
            }
            set
            {
                optionStorage.Value = value;
            }
        }        
        virtual protected void StartDriver() { }
        virtual protected object DriverOption
        {
            get;
        }       
    }
}
