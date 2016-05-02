using OpenQA.Selenium.Chrome;
using AutomationFrameWork.Helper;
namespace AutomationFrameWork.Driver.Core
{
    public class EmulationiPhone5 : Drivers
    {
        private static readonly EmulationiPhone5 _instance = new EmulationiPhone5();    
        static EmulationiPhone5()
        {
        }       
        private EmulationiPhone5()
        {
        }

        public static EmulationiPhone5 Instance
        {
            get
            {
                return _instance;
            }
        }
        protected override void StartDriver()
        {
            Drivers.DriverStorage = new ChromeDriver(DriverHelper.Instance.DriverPath, (ChromeOptions)EmulationiPhone5.Instance.DriverOption);
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