using AutomationFrameWork.Base.Driver;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
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
        public AppiumWebElement FindElementByAndroidUIAutomator(string value)
        {            
            var _AndroidDriver = (AndroidDriver<AppiumWebElement>)MobileDriver;         
            return _AndroidDriver.FindElementByAndroidUIAutomator(value);
        }
        public AppiumWebElement FindElementByIosUIAutomation(string value)
        {            
            var _IOsDriver = (IOSDriver<AppiumWebElement>)MobileDriver;            
            return _IOsDriver.FindElementByIosUIAutomation(value);
        }
        public void Swipe(int startX, int startY, int endX, int endY, int duration)
        {
            MobileDriver.Swipe(startX, startY, endX, endY, duration);
        }
        public void SwipeInVertical(int startY, int endY, int duration)
        {
            MobileDriver.Swipe(0, startY, 0, endY, duration);
        }
        public void SwipeInHorizontal(int startX, int endX, int duration)
        {
            MobileDriver.Swipe(startX, 0, endX, 0, duration);
        }
        public void SwipeToElement(AppiumWebElement elementFrom,AppiumWebElement elementTo,int duration)
        {
            MobileDriver.Swipe(elementFrom.Location.X,elementFrom.Location.Y,elementTo.LocationOnScreenOnceScrolledIntoView.X,elementTo.LocationOnScreenOnceScrolledIntoView.X,duration);
        }
    }
}

