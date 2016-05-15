using OpenQA.Selenium.IE;
using AutomationFrameWork.Helper;
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

        protected override void StartDriver ()
        {
            Drivers.DriverStorage = new InternetExplorerDriver(DriverHelper.Instance.DriverPath, (InternetExplorerOptions)InternetExplore.Instance.DriverOption);
        }

        protected override object DriverOption
        {
            get
            {
                InternetExplorerOptions op = (InternetExplorerOptions)Drivers.DriverOptions;
                if (op == null)
                    op = new InternetExplorerOptions
                    {
                        EnsureCleanSession = true,                       
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