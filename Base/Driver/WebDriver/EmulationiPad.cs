using AutomationFrameWork.Driver.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using System.Threading;
using AutomationFrameWork.Helper;
namespace AutomationFrameWork.Driver
{
    public class EmulationiPad : Drivers
    {
        private static readonly EmulationiPad instance = new EmulationiPad();       
        private static IWebDriver WebDriver = null;
        static EmulationiPad()
        {
        }
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>(() =>
        {
            WebDriver = new ChromeDriver(DriverHelper.Instance.DriverPath, (ChromeOptions)EmulationiPad.Instance.DriverOption);
            WebDriver.Manage().Window.Size = new Size(1024, 768);
            return WebDriver;
        });
        private EmulationiPad()
        {
        }

        public static EmulationiPad Instance
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
                op.AddArgument("--user-agent=Mozilla/5.0 (iPad; CPU OS 9_1 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/9.0 Mobile/10A5355d Safari/8536.25");
                return op;               
            }
        }
    }
}