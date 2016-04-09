using AutomationFrameWork.Base.Driver;
using OpenQA.Selenium.Appium;
namespace AutomationFrameWork.ActionsKeys
{
    public class MobileKeywords
    {
        private static AppiumDriver<AppiumWebElement> MobileDriver = null;
        private MobileKeywords ()
        {
            //This method for not allow use can instance this class from outside
        }
        private static MobileKeywords instance = new MobileKeywords();
        public static MobileKeywords Instance ()
        {
            MobileDriver = DriverFactory.Instance.GetMobileDriver;
            return instance;
        }
        public void ScroolToClick (string text)
        {
            MobileDriver.ScrollToExact(text).Click();
        }

    }
}
