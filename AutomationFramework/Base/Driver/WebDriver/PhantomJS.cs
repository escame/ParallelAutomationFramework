using OpenQA.Selenium.PhantomJS;
using AutomationFrameWork.Helper;
namespace AutomationFrameWork.Driver.Core
{
    class PhantomJS : Drivers
    {
        private static readonly PhantomJS _instance = new PhantomJS();
        private static PhantomJSDriverService _phantomJSDriverService = null;
        static PhantomJS ()
        {
        }
        private PhantomJS ()
        {

        }

        public static PhantomJS Instance
        {
            get
            {
                return _instance;
            }
        }
        protected override object StartDriver (int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            //Drivers.DriverStorage = new PhantomJSDriver(PhantomJS.Instance.PhantomJSDriverService, (PhantomJSOptions)PhantomJS.Instance.DriverOption);
            PhantomJSDriver driver = new PhantomJSDriver(PhantomJS.Instance.PhantomJSDriverService, (PhantomJSOptions)PhantomJS.Instance.DriverOption);
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(scriptTimeout));          
            return driver;
        }

        public PhantomJSDriverService PhantomJSDriverService
        {
            get
            {
                if (_phantomJSDriverService == null)
                    _phantomJSDriverService = PhantomJSDriverService.CreateDefaultService(DriverHelper.Instance.DriverPath);
                return _phantomJSDriverService;
            }
            set
            {
                _phantomJSDriverService = value;
            }
        }
        protected override object DriverOption
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