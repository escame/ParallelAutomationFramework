using AutomationFrameWork.Driver.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;
using AutomationFrameWork.Helper;

namespace AutomationFrameWork.Driver.Core
{
    public class InternetExplore : Drivers
    {
        private static readonly InternetExplore instance = new InternetExplore();      
        static InternetExplore()
        {
        }
        /*
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>(() =>
        {
            WebDriver = new InternetExplorerDriver(DriverHelper.Instance.DriverPath, (InternetExplorerOptions)InternetExplore.Instance.DriverOption);
            return WebDriver;

        });
        */
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
            Drivers.DriverStorage = new InternetExplorerDriver(DriverHelper.Instance.DriverPath, (InternetExplorerOptions)InternetExplore.Instance.DriverOption);
        }

        protected override object DriverOption
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