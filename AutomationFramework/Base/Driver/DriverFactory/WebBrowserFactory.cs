using OpenQA.Selenium;
using AutomationFrameWork.Driver.Interface;
using AutomationFrameWork.Driver.WebBrowser;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFrameWork.Driver
{
    class WebBrowserFactory<Services, Options>
    {
        public IWebDriver GetDriver(BrowserType.WebBrowser type, Services driverServices = default(Services), Options desiredCapabilities = default(Options), int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {           
            throw new NotImplementedException();
        }

      
    }
}
