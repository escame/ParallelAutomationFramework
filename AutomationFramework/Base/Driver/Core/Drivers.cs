using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;

namespace AutomationFrameWork.Driver.Core
{
    abstract class Drivers
    {
        protected static ThreadLocal<object> driverStored = new ThreadLocal<object>(true);
        protected static ThreadLocal<DesiredCapabilities> desiredCapabilities = new ThreadLocal<DesiredCapabilities>();
        protected static ThreadLocal<object> optionStorage = new ThreadLocal<object>();
        protected static ThreadLocal<String> remoteUri = new ThreadLocal<string>();
        private static readonly object _syncRoot = new Object();

        /// <summary>
        /// This method is use for
        /// scan all class driver with correct name via DriverType 
        /// and invoke method StartDriver
        /// </summary>
        /// <param name="driverType"></param>
        public static void StartDrivers (DriverType driverType)
        {
            List<Type> listClass = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                      .Where(item => item.Namespace == "AutomationFrameWork.Driver.Core")
                      .ToList();
            foreach (Type className in listClass)
            {
                if (className.Name.ToString().ToLower().Equals(driverType.ToString().ToLower()))
                {
                    MethodInfo startDriver = className.GetMethod("StartDriver", BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.NonPublic);
                    FieldInfo instance = className.GetField("_instance",
                        BindingFlags.Static | BindingFlags.NonPublic);
                    object instanceDriver = instance.GetValue(null);                   
                    startDriver.Invoke(instanceDriver, Type.EmptyTypes);                    
                    break;
                }
            }
        }
        /// <summary>
        /// This method use for close driver 
        /// </summary>
        public static void CloseDrivers ()
        {
            IWebDriver _driver = (IWebDriver)driverStored.Value;
            _driver.Quit();
            _driver.Dispose();
            if (optionStorage.Value != null)
                optionStorage.Value = null;
            if (desiredCapabilities.Value != null)
                desiredCapabilities.Value = null;
            if (remoteUri.Value != null)
                remoteUri.Value = null;
            if (driverStored.Value != null)
                driverStored.Value = null;
        }
        /// <summary>
        /// This method is use 
        /// for return object with can be MobileDriver or WebDriver
        /// </summary>
        /// <returns></returns>
        public static object DriverStorage
        {
            get
            {
                return driverStored.Value;
            }
            protected set
            {
                driverStored.Value = value;
            }
        }
        /// <summary>
        /// This method is use 
        /// for setting DesiredCapabilities for Remote Driver, Firefox Driver, PhantomJs Driver
        /// </summary>
        public static DesiredCapabilities DesiredCapabilitiesCore
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
        public static object DriverOptions
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
        /// <summary>
        /// This method is use
        /// for return Uri of Cloud devices or remote Uri
        /// </summary>
        public static String RemoteUriCore
        {
            get
            {
                return remoteUri.Value;
            }
            set
            {
                remoteUri.Value = value;
            }
        }
        /// <summary>
        /// This method is use for
        /// Start driver for any class extend Drivers
        /// </summary>    
        virtual protected void StartDriver ()
        {
        }
        /// <summary>
        /// This method is use for
        /// Get DriverOption for any class extend Drivers
        /// </summary>
        virtual protected object DriverOption
        {
            get;
        }
    }
}
