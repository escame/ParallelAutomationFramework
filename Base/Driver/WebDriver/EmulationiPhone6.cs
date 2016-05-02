using OpenQA.Selenium.Chrome;
using AutomationFrameWork.Helper;
namespace AutomationFrameWork.Driver.Core
{
    public class EmulationiPhone6 : Drivers
    {
        private static readonly EmulationiPhone6 _instance = new EmulationiPhone6();     
        static EmulationiPhone6()
        {
        }       
        private EmulationiPhone6()
        {
        }

        public static EmulationiPhone6 Instance
        {
            get
            {
                return _instance;
            }
        }
        protected override void StartDriver()
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