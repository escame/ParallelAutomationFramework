using OpenQA.Selenium.PhantomJS;
using AutomationFrameWork.Helper;
namespace AutomationFrameWork.Driver.Core
{
    public class PhantomJS : Drivers
    {
        private static readonly PhantomJS instance = new PhantomJS();
        private static PhantomJSDriverService phantomJSDriverService = null;       
        static PhantomJS()
        {
        }     
        private PhantomJS ()
        {

        }

        public static PhantomJS Instance
        {
            get
            {
                return instance;
            }
        }
        protected override void StartDriver()
        {
            Drivers.DriverStorage = new PhantomJSDriver(PhantomJS.Instance.PhantomJSDriverService, (PhantomJSOptions)PhantomJS.Instance.DriverOption);
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