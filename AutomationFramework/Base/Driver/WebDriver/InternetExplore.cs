using OpenQA.Selenium.IE;
using AutomationFrameWork.Helper;
using OpenQA.Selenium;

namespace AutomationFrameWork.Driver.Core
{
    class InternetExplore : Drivers
    {
        private static readonly InternetExplore _instance = new InternetExplore();
        static InternetExplore ()
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

        protected override object StartDriver (int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            //Drivers.DriverStorage = new InternetExplorerDriver(DriverHelper.Instance.DriverPath, (InternetExplorerOptions)InternetExplore.Instance.DriverOption);
            IWebDriver driver = new InternetExplorerDriver(DriverHelper.Instance.DriverPath, (InternetExplorerOptions)InternetExplore.Instance.DriverOption);
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(scriptTimeout));
            if (isMaximize)
                driver.Manage().Window.Maximize();
            return driver;
        }

        protected override object DriverOption
        {
            get
            {
                InternetExplorerOptions op = (InternetExplorerOptions)Drivers.DriverOptions;
                if (op == null)
                    op = new InternetExplorerOptions
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
                else
                {
                    op.EnsureCleanSession = true;
                    op.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    op.PageLoadStrategy = InternetExplorerPageLoadStrategy.Eager;
                    op.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Ignore;
                    op.IgnoreZoomLevel = true;
                    op.EnableNativeEvents = true;
                    op.RequireWindowFocus = true;
                    op.EnablePersistentHover = true;
                    op.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Top;
                }       
                return op;
            }
        }


    }
}