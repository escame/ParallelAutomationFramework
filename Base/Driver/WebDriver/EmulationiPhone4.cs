using OpenQA.Selenium.Chrome;
using AutomationFrameWork.Helper;

namespace AutomationFrameWork.Driver.Core
{
    public class EmulationiPhone4 : Drivers
    {
        private static readonly EmulationiPhone4 instance = new EmulationiPhone4();    
        static EmulationiPhone4()
        {
        }        
        private EmulationiPhone4()
        {
        }

        public static EmulationiPhone4 Instance
        {
            get
            {
                return instance;
            }
        }
        protected override void StartDriver()
        {
            Drivers.DriverStorage = new ChromeDriver(DriverHelper.Instance.DriverPath, (ChromeOptions)EmulationiPhone4.Instance.DriverOption);
        }

        protected override object DriverOption
        {
            get
            {
                ChromeOptions op = (ChromeOptions)Drivers.DriverOptions;
                if (op == null)
                    op = new ChromeOptions();
                op.EnableMobileEmulation("Apple iPhone 4");
                return op;
            }
        }
    }
}