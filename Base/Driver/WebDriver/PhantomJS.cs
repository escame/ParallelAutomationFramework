using OpenQA.Selenium.PhantomJS;
using AutomationFrameWork.Helper;
namespace AutomationFrameWork.Driver.Core
{
    public class PhantomJS : Drivers
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
        protected override void StartDriver ()
        {
            Drivers.DriverStorage = new PhantomJSDriver(PhantomJS.Instance.PhantomJSDriverService, (PhantomJSOptions)PhantomJS.Instance.DriverOption);
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