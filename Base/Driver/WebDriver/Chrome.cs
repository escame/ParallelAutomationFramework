using AutomationFrameWork.Driver.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using AutomationFrameWork.Helper;

namespace AutomationFrameWork.Driver
{
    public class Chrome : Drivers
    {
        private static readonly Chrome instance = new Chrome();        
        private static IWebDriver WebDriver = null;
        static Chrome()
        {
        }
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>(() =>
        {
            WebDriver = new ChromeDriver(DriverHelper.Instance.DriverPath, (ChromeOptions)Chrome.Instance.DriverOption);
            return WebDriver;

        });
        private Chrome()
        {

        }

        public static Chrome Instance
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
                ChromeOptions op = (ChromeOptions)Drivers.DriverOptions;
                if (op == null)
                    op = new ChromeOptions();
                return op;
            }
        }
    }
}