using AutomationFrameWork.Driver.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System.Threading;
using AutomationFrameWork.Helper;
namespace AutomationFrameWork.Driver
{
    public class PhantomJS : Drivers
    {
        private static readonly PhantomJS instance = new PhantomJS();       
        private static IWebDriver WebDriver = null;
        private static PhantomJSDriverService phantomJSDriverService = null;       
        static PhantomJS()
        {
        }
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>(() =>
        {
            WebDriver = new PhantomJSDriver(PhantomJS.Instance.PhantomJSDriverService, (PhantomJSOptions)PhantomJS.Instance.DriverOption);
            return WebDriver;

        });
        private PhantomJS()
        {

        }

        public static PhantomJS Instance
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

        public PhantomJSDriverService PhantomJSDriverService
        {
            get
            {
                if (phantomJSDriverService == null)
                    phantomJSDriverService = PhantomJSDriverService.CreateDefaultService(DriverHelper.Instance.DriverPath);
                return phantomJSDriverService;
            }
            set
            {
                phantomJSDriverService = value;
            }
        }
        public override object DriverOption
        {
            get
            {
                PhantomJSOptions op = (PhantomJSOptions)Drivers.DriverOptions;
                if (op == null)
                    op = new PhantomJSOptions();
                return op;
            }
        }
    }
}