using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using AutomationFrameWork.Exceptions;
using OpenQA.Selenium.PhantomJS;

namespace AutomationFrameWork.Driver
{
    abstract class Drivers
    {
        private const string DriverCoreNamespace = "AutomationFrameWork.Driver.Core";
        private static ThreadLocal<object> _driverStored;
        private static ThreadLocal<object> _optionStorage;
        private static ThreadLocal<object> _servicesStorage;
        private static ThreadLocal<DesiredCapabilities> _desiredCapabilities;
        private static ThreadLocal<PhantomJSDriverService> _phantomJSDriverService;
        private static ThreadLocal<String> _remoteUri;

        /// <summary>
        /// This method is use for
        /// Start driver for any class extend Drivers
        /// </summary>    
        protected abstract object StartDriver(int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false);
        /// <summary>
        /// This method is use for
        /// scan all class driver with correct name via DriverType 
        /// and invoke method StartDriver
        /// </summary>
        /// <param name="driverType"></param>
        public static void StartDrivers(DriverType driverType, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            Type foundClass = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                      .Where(item => item.Namespace == DriverCoreNamespace && item.Name.Equals(driverType.ToString(), StringComparison.OrdinalIgnoreCase)) // TODO for review: refactor code to search driver
                      .FirstOrDefault();

            if (foundClass != null)
            {
                ConstructorInfo constructor = foundClass.GetConstructor(Type.EmptyTypes);
                MethodInfo startDriver = foundClass.GetMethod("StartDriver", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod);
                DriverStorage = startDriver.Invoke(constructor.Invoke(new object[] { }), new object[] { pageLoadTimeout, scriptTimeout, isMaximize });
            }
        }
        /// <summary>
        /// This method use for close driver 
        /// </summary>
        public static void CloseDrivers()
        {
            IWebDriver driver = (IWebDriver)_driverStored.Value;
            driver.Quit();
            driver.Dispose();
            if (_optionStorage != null)
                _optionStorage.Value = null;
            if (_desiredCapabilities != null)
                _desiredCapabilities.Value = null;
            if (_remoteUri != null)
                _remoteUri.Value = null;
            if (_driverStored.Value != null)
                _driverStored.Value = null;
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
                return _driverStored.Value;
            }
            private set
            {
                if (_driverStored == null)
                    _driverStored = new ThreadLocal<object>(true);
                _driverStored.Value = value;
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
                if (_desiredCapabilities == null)
                    _desiredCapabilities = new ThreadLocal<DesiredCapabilities>();
                _desiredCapabilities.Value = _desiredCapabilities.Value == null ? new DesiredCapabilities() : _desiredCapabilities.Value;
                return _desiredCapabilities.Value;
            }
            set
            {
                if (_desiredCapabilities == null)
                    _desiredCapabilities = new ThreadLocal<DesiredCapabilities>(); // TODO question? why create new, then assign to new value in next line?
                _desiredCapabilities.Value = value;
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
                if (_optionStorage == null)
                    _optionStorage = new ThreadLocal<object>();
                return _optionStorage.Value;
            }
            set
            {
                if (_optionStorage == null)
                    _optionStorage = new ThreadLocal<object>();
                _optionStorage.Value = value;
            }
        }
        /// <summary>
        /// This method is use
        /// for return DriverService like PhantomJSDriverService
        /// </summary>
        public static object DriverService
        {
            get
            {
                if (_servicesStorage == null)
                    _servicesStorage = new ThreadLocal<object>();
                return _servicesStorage.Value;
            }
            set
            {
                if (_servicesStorage == null)
                    _servicesStorage = new ThreadLocal<object>();
                _servicesStorage.Value = value;
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
                if (_remoteUri == null)
                    throw new StepErrorException("Please set Uri for Remote Server");
                return _remoteUri.Value;
            }
            set
            {
                if (_remoteUri == null)
                    _remoteUri = new ThreadLocal<string>();
                _remoteUri.Value = value;
            }
        }
        /// <summary>
        /// This method is use
        /// for return PhantomJSDriverService
        /// </summary>
        public static PhantomJSDriverService PhantomJSDriverService
        {
            get
            {
                if (_phantomJSDriverService == null)
                {
                    _phantomJSDriverService = new ThreadLocal<PhantomJSDriverService>();
                    _phantomJSDriverService.Value = PhantomJSDriverService.CreateDefaultService(Helper.DriverHelper.Instance.DriverPath);
                }
                return _phantomJSDriverService.Value;
            }
            set
            {
                if (_phantomJSDriverService == null)
                    _phantomJSDriverService = new ThreadLocal<PhantomJSDriverService>();
                _phantomJSDriverService.Value = value;
            }
        }
    }
}
