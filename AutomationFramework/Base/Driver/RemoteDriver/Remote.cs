using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace AutomationFrameWork.Driver.Core
{
    class Remote : Drivers
    {
        private static readonly Remote _instance = new Remote();     
        static Remote ()
        {
        }
        private Remote ()
        {
        }
        public static Remote Instance
        {
            get
            {
                return _instance;
            }
        }
        protected override object DriverOption
        {
            get
            {
                return 1;
            }
        }       
        protected override object StartDriver (int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {           
            RemoteWebDriver driver = new RemoteWebDriver(new Uri(Drivers.RemoteUriCore), Remote.Instance.DesiredCapabilities);
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(scriptTimeout));
            return driver;
        }

        private DesiredCapabilities DesiredCapabilities
        {
            get
            {
                return Drivers.DesiredCapabilitiesCore;
            }
        }
    }   
}
/// <summary>
/// Implement screen shot for Remote Driver
/// </summary>
namespace OpenQA.Selenium.Remote
{
    public class ScreenshotRemoteDriver : RemoteWebDriver, ITakesScreenshot
    {
        public ScreenshotRemoteDriver (Uri remoteAddress, ICapabilities desiredCapabilities)
            : base(remoteAddress, desiredCapabilities)
        {
        }

        public Screenshot GetScreenshotRemoteDriver ()
        {
            Response screenshotResponse = this.Execute(DriverCommand.Screenshot, null);
            string base64 = screenshotResponse.Value.ToString();
            return new Screenshot(base64);
        }
    }
}