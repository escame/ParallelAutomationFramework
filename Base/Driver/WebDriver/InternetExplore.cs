using OpenQA.Selenium.IE;
using AutomationFrameWork.Helper;
namespace AutomationFrameWork.Driver.Core
{
    public class InternetExplore : Drivers
    {
        private static readonly InternetExplore _instance = new InternetExplore();      
        static InternetExplore()
        {
        }      
        private InternetExplore ()
        {
        }

        public static InternetExplore Instance
        {
            get
            {
                return _instance;
            }
        }

        protected override void StartDriver()
        {
            Drivers.DriverStorage = new InternetExplorerDriver(DriverHelper.Instance.DriverPath, (InternetExplorerOptions)InternetExplore.Instance.DriverOption);
        }

        protected override object DriverOption
        {
            get
            {
                InternetExplorerOptions op = (InternetExplorerOptions)Drivers.DriverOptions;
                if (op == null)
                    op = new InternetExplorerOptions();
                return op;
            }
        }


    }
}