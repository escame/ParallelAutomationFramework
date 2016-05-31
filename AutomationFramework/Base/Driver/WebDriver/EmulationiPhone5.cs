using OpenQA.Selenium.Chrome;
using AutomationFrameWork.Helper;
using OpenQA.Selenium;

namespace AutomationFrameWork.Driver.Core
{
    class EmulationiPhone5 : Drivers
    {
        private static readonly EmulationiPhone5 _instance = new EmulationiPhone5();
        static EmulationiPhone5 ()
        {
        }
        private EmulationiPhone5 ()
        {
        }

        public static EmulationiPhone5 Instance
        {
            get
            {
                return _instance;
            }
        }
        protected override object StartDriver (int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {           
            IWebDriver driver = new ChromeDriver(DriverHelper.Instance.DriverPath, (ChromeOptions)EmulationiPhone5.Instance.DriverOption);
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(scriptTimeout));
            if (isMaximize)
                driver.Manage().Window.Maximize();
            return driver;
        }
        protected override object DriverOption
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