using OpenQA.Selenium.IE;
using AutomationFrameWork.Helper;
using OpenQA.Selenium;

namespace AutomationFrameWork.Driver
{
    class InternetExplore : Drivers
    {
        protected override object StartDriver(int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            InternetExplorerOptions op = (InternetExplorerOptions)Drivers.DriverOptions;
            if (op == null)
                op = InternetExplorerOptions;
            IWebDriver driver = new InternetExplorerDriver(DriverHelper.Instance.DriverPath, op);
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(scriptTimeout));
            if (isMaximize)
                driver.Manage().Window.Maximize();
            return driver;
        }
        private InternetExplorerOptions InternetExplorerOptions
        {
            get
            {
                return new InternetExplorerOptions
                {
                    EnsureCleanSession = false,
                    IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                    PageLoadStrategy = InternetExplorerPageLoadStrategy.Eager,
                    UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Ignore,
                    IgnoreZoomLevel = true,
                    EnableNativeEvents = true,
                    RequireWindowFocus = true,
                    EnablePersistentHover = true,
                    ElementScrollBehavior = InternetExplorerElementScrollBehavior.Top,
                };
            }
        }
    }
}