using AutomationFrameWork.Driver.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.Remote;
using AutomationFrameWork.Utils;

namespace AutomationFrameWork.Driver.Core
{
    public class Firefox : Drivers
    {
        private static readonly Firefox instance = new Firefox();          
        static Firefox()
        {
        }
        /*
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>(() =>
        {
            WebDriver = new FirefoxDriver(Firefox.Instance.DesiredCapabilities);
            return WebDriver;

        });
        */
        private Firefox()
        {

        }

        public static Firefox Instance
        {
            get
            {
                return instance;
            }
        }
        public override void StartDriver()
        {
            Drivers.DriverStorage = new FirefoxDriver(Firefox.Instance.DesiredCapabilities);
        }
        /// <summary>
        /// Not implement this method for firefox
        /// </summary>
        protected override object DriverOption
        {
            get
            {
                return null;
            }
        }


        private new DesiredCapabilities DesiredCapabilities
        {
            get
            {
                return Drivers.DesiredCapabilities;
            }
        }
    }
}