using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AutomationFrameWork.Helper;

namespace AutomationFrameWork.Driver.Core
{
    class Chrome : Drivers
    {
        private static readonly Chrome _instance = new Chrome();
        static Chrome ()
        {
        }
        private Chrome ()
        {

        }

        public static Chrome Instance
        {
            get
            {
                return _instance;
            }
        }
        protected override object StartDriver (int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            IWebDriver driver = new ChromeDriver(DriverHelper.Instance.DriverPath, (ChromeOptions)Chrome.Instance.DriverOption);
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(scriptTimeout));
            if (isMaximize)
                driver.Manage().Window.Maximize();
            return driver;
            //Drivers.DriverStorage = driver;
        }
        protected override object DriverOption
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