using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System;

namespace AutomationFrameWork.Driver.Core
{
    abstract public class Drivers
    {
        static readonly object syncRoot = new Object();
        static ThreadLocal<object> driverStored = new ThreadLocal<object>();
        static ThreadLocal<ChromeOptions> chromeOption = new ThreadLocal<ChromeOptions>();
        static ThreadLocal<DesiredCapabilities> desiredCapabilities = new ThreadLocal<DesiredCapabilities>();
        static ThreadLocal<object> optionStorage = new ThreadLocal<object>();
        static ThreadLocal<Dictionary<int, List<int>>> portStorage=new ThreadLocal<Dictionary<int, List<int>>>();       
        static Dictionary<int,Boolean> freePort = new Dictionary<int, Boolean>();       
        /// <summary>
        /// This method use for close driver 
        /// </summary>
        public static void CloseDriver()
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
        public static object DriverStorage
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
        /// for set chrome option in Chrome Driver
        /// </summary>
        public static ChromeOptions ChromeOptions
        {
            get
            {
                if (Drivers.chromeOption.Value == null)
                    Drivers.chromeOption.Value = new ChromeOptions();
                return Drivers.chromeOption.Value;
            }
            set
            {
                Drivers.chromeOption.Value = value;
            }
        }
        /// <summary>
        /// This method is use 
        /// for setting DesiredCapabilities for Remote Driver, Firefox Driver, PhantomJs Driver
        /// </summary>
        public static DesiredCapabilities DesiredCapabilities
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
        /// for return FreePort for run appium
        /// </summary>
        public static Dictionary<int, Boolean> FreePort
        { 
            get
            {
                lock (syncRoot)
                {
                    return freePort;
                }
            }
            set
            {
                lock (syncRoot)
                {
                    try
                    {
                        foreach (KeyValuePair<int, Boolean> values in value)
                            for (int port=0; port<Drivers.FreePort.Count||Drivers.FreePort.Count==0;port++)
                            {
                                if (!Drivers.FreePort.ContainsKey(values.Key))
                                    freePort.Add(values.Key, values.Value);
                                else
                                    freePort[values.Key] = values.Value;
                            }
                    }
                    catch (ArgumentException e)
                    {
                        System.Console.WriteLine(e.Message);
                    }
                }
            }
        }        
        /// <summary>
        /// This method is use 
        /// for storeage port in use for run appium
        /// </summary>
        public static Dictionary<int,List<int>> PortStorage
        {
            get
            {
                return portStorage.Value;
            }
            set
            {
                if (!portStorage.IsValueCreated)
                    portStorage.Value = new Dictionary<int, List<int>>();
                foreach (KeyValuePair<int, List<int>> port in value)
                {
                    try
                    {
                        portStorage.Value.Add(port.Key, port.Value);
                    }
                    catch (System.ArgumentException e)
                    {
                        System.Console.WriteLine("Catch "+e.Message+" for thread "+ port.Key);
                        portStorage.Value[port.Key].AddRange(port.Value);
                    }

                }
            }
        }
        abstract public void StartDriver();
        abstract public object DriverOption { get; }
        
    }
}
