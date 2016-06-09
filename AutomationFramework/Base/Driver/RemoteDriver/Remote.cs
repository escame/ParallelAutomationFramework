using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace AutomationFrameWork.Driver.Core
{
    class Remote : Drivers
    {       
        protected override object StartDriver (int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {           
            RemoteWebDriver driver = new RemoteWebDriver(new Uri(Drivers.RemoteUriCore), Drivers.DesiredCapabilitiesCore);
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(scriptTimeout));
            return driver;
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