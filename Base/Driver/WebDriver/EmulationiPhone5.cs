using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomationFrameWork.Driver.Core;
using System.Threading;
using AutomationFrameWork.Helper;

namespace AutomationFrameWork.Driver
{
    public class EmulationiPhone5 : Drivers
    {
        private static readonly EmulationiPhone5 instance = new EmulationiPhone5();     
        private static IWebDriver WebDriver = null;
        static EmulationiPhone5()
        {
        }
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>(() =>
        {

            WebDriver = new ChromeDriver(DriverHelper.Instance.DriverPath, (ChromeOptions)EmulationiPhone5.Instance.DriverOption);
            return WebDriver;
        });
        private EmulationiPhone5()
        {
        }

        public static EmulationiPhone5 Instance
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
                op.EnableMobileEmulation("Apple iPhone 5");
                return op;
            }
        }
    }
}