using AutomationFrameWork.Driver.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;
using AutomationFrameWork.Helper;

namespace AutomationFrameWork.Driver
{
    public class InternetExplore : Drivers
    {
        private static readonly InternetExplore instance = new InternetExplore();        
        private static IWebDriver WebDriver = null;        
        static InternetExplore()
        {
        }
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>(() =>
        {
            WebDriver = new InternetExplorerDriver(DriverHelper.Instance.DriverPath, (InternetExplorerOptions)InternetExplore.Instance.DriverOption);
            return WebDriver;

        });
        private InternetExplore()
        {
        }

        public static InternetExplore Instance
        {
            get
            {
                return instance;
            }
        }

        public override void StartDriver()
        {
            Drivers.DriverStorage = driver.Value;
        }

        public override object DriverOption
        {
            get
            {
                InternetExplorerOptions op = (InternetExplorerOptions)Drivers.DriverOptions;
                if (op == null)
                    op = new InternetExplorerOptions();
                return op;
            }
        }


    }
}