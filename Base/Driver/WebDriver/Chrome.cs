using OpenQA.Selenium.Chrome;
using AutomationFrameWork.Helper;

namespace AutomationFrameWork.Driver.Core
{
    public class Chrome : Drivers
    {
        private static readonly Chrome instance = new Chrome();       
        static Chrome()
        {
        }        
        private Chrome()
        {

        }
        
        public static Chrome Instance
        {
            get
            {
                return instance;               
            }
        }
        protected override void StartDriver()
        {
            Drivers.DriverStorage =  new ChromeDriver(DriverHelper.Instance.DriverPath, (ChromeOptions)Chrome.instance.DriverOption); 
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