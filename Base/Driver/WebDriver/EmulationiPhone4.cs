using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomationFrameWork.Driver.Core;
using System.Threading;
using AutomationFrameWork.Helper;

namespace AutomationFrameWork.Driver
{
    public class EmulationiPhone4 : Drivers
    {
        private static readonly EmulationiPhone4 instance = new EmulationiPhone4();     
        private static IWebDriver WebDriver = null;
        static EmulationiPhone4()
        {
        }
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>(() =>
        {
            WebDriver = new ChromeDriver(DriverHelper.Instance.DriverPath, (ChromeOptions)EmulationiPhone4.Instance.DriverOption);
            return WebDriver;
        });
        private EmulationiPhone4()
        {
        }

        public static EmulationiPhone4 Instance
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
                op.EnableMobileEmulation("Apple iPhone 4");
                return op;
            }
        }
    }
}