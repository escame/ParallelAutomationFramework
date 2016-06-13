using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using AutomationFrameWork.Driver.Interface;

namespace AutomationFrameWork.Driver.Interface
{
    public interface IDriverss<Driver> 
    {
        Driver Drivers { get; set; }
    }
    public interface IBrowsers<Drivers,Options, Services> : IDriverOptions<Options>, IDriverServices<Services>,IDriverss<Drivers>
    {
        void Driver(Services driverServices = default(Services), Options desiredCapabilities = default(Options), int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false);
    }
    public class Test : IBrowsers<IWebDriver, ChromeOptions, ChromeDriverService>
    {
        public IWebDriver Drivers
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public ChromeOptions Options
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ChromeDriverService Services
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Driver(ChromeDriverService driverServices = null, ChromeOptions desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            throw new NotImplementedException();
        }

        public class Manager<T> where T : IDriverss<T>
        { 
        
        }
    }
}
