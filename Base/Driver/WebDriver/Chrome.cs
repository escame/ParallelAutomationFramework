using AutomationFrameWork.Driver.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
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
                //return Chrome.ChromeInstance.Value;
            }
        }
        public override void StartDriver()
        {
            Drivers.DriverStorage =  new ChromeDriver(DriverHelper.Instance.DriverPath, (ChromeOptions)Chrome.Instance.DriverOption); 
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