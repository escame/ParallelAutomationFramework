using AutomationFrameWork.Driver.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using AutomationFrameWork.Helper;
namespace AutomationFrameWork.Driver.Core
{
    public class EmulationiPhone6 : Drivers
    {
        private static readonly EmulationiPhone6 instance = new EmulationiPhone6();     
        static EmulationiPhone6()
        {
        }
        /*
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>(() =>
        {
            WebDriver = new ChromeDriver(DriverHelper.Instance.DriverPath, (ChromeOptions)EmulationiPhone6.Instance.DriverOption);
            return WebDriver;
        });
        */
        private EmulationiPhone6()
        {
        }

        public static EmulationiPhone6 Instance
        {
            get
            {
                return instance;
            }
        }
        public override void StartDriver()
        {
            Drivers.DriverStorage = new ChromeDriver(DriverHelper.Instance.DriverPath, (ChromeOptions)EmulationiPhone6.Instance.DriverOption);
        }

        protected override object DriverOption
        {
            get
            {
                ChromeOptions op = (ChromeOptions)Drivers.DriverOptions;
                if (op == null)
                    op = new ChromeOptions();
                op.EnableMobileEmulation("Apple iPhone 6");
                return op;
            }
        }
    }
}