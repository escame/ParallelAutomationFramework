using OpenQA.Selenium.Chrome;
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
        protected override void StartDriver ()
        {
            Drivers.DriverStorage = new ChromeDriver(DriverHelper.Instance.DriverPath, (ChromeOptions)Chrome.Instance.DriverOption);
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