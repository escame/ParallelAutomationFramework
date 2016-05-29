using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using AutomationFrameWork.Exceptions;

namespace AutomationFrameWork.Driver.Core
{
    abstract class Drivers
    {
        private static ThreadLocal<object> driverStored ;
        protected static ThreadLocal<DesiredCapabilities> desiredCapabilities ;
        protected static ThreadLocal<object> optionStorage ;
        protected static ThreadLocal<String> remoteUri ;
        //private static readonly object _syncRoot = new Object();

        /// <summary>
        /// This method is use for
        /// scan all class driver with correct name via DriverType 
        /// and invoke method StartDriver
        /// </summary>
        /// <param name="driverType"></param>
        public static void StartDrivers (DriverType driverType, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
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
                    DriverStorage = startDriver.Invoke(instanceDriver,new object[] { pageLoadTimeout, scriptTimeout , isMaximize});                    
                    break;
                }
            }
        }
        /// <summary>
        /// This method use for close driver 
        /// </summary>
        public static void CloseDrivers ()
        {
            IWebDriver driver = (IWebDriver)driverStored.Value;
            driver.Quit();
            driver.Dispose();
            if (optionStorage != null)
                optionStorage.Value = null;
            if (desiredCapabilities != null)
                desiredCapabilities.Value = null;
            if (remoteUri != null)
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
            private set
            {
                if(driverStored==null)
                driverStored = new ThreadLocal<object>(true);
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
                if (desiredCapabilities == null)
                    desiredCapabilities = new ThreadLocal<DesiredCapabilities>();
                desiredCapabilities.Value = desiredCapabilities.Value == null ? new DesiredCapabilities() : desiredCapabilities.Value;
                return desiredCapabilities.Value;
            }
            set
            {
                if(desiredCapabilities==null)
                desiredCapabilities = new ThreadLocal<DesiredCapabilities>();
                desiredCapabilities.Value = value;
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
                if (optionStorage == null)
                    optionStorage = new ThreadLocal<object>();
                return optionStorage.Value;
            }
            set
            {
                if(optionStorage==null)
                    optionStorage = new ThreadLocal<object>();
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
                if (remoteUri == null)
                    throw new StepErrorException("Please set Uri for Remote Server");
                return remoteUri.Value;
            }
            set
            {
                if (remoteUri == null)
                    remoteUri = new ThreadLocal<string>();
                remoteUri.Value = value;
            }
        }
        /// <summary>
        /// This method is use for
        /// Start driver for any class extend Drivers
        /// </summary>    
        protected virtual object StartDriver (int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            throw new NotImplementedException();
        }      
        /// <summary>
        /// This method is use for
        /// Get DriverOption for any class extend Drivers
        /// </summary>
        protected virtual object DriverOption
        {
            get;
        }
    }
}
