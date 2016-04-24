using AutomationFrameWork.Driver;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using System.Threading;

namespace AutomationFrameWork.ActionsKeys
{
    public class MobileKeywords
    {       
        private static readonly MobileKeywords instance = new MobileKeywords();
        private MobileKeywords ()
        {            
        }
        static MobileKeywords ()
        {
        }
        ThreadLocal<AppiumDriver<AppiumWebElement>> MobileDriver = new ThreadLocal<AppiumDriver<AppiumWebElement>>(() =>
        {
            return DriverFactory.Instance.GetMobileDriver;
        });    
        public static MobileKeywords Instance ()
        {           
            return instance;
        }
        public void ScroolToClick (string text)
        {
            MobileDriver.Value.ScrollToExact(text).Click();
        }
        public AppiumWebElement FindElementByAndroidUIAutomator(string value)
        {            
            var _AndroidDriver = (AndroidDriver<AppiumWebElement>)MobileDriver.Value;   
            return _AndroidDriver.FindElementByAndroidUIAutomator(value);
        }
        public AppiumWebElement FindElementByIosUIAutomation(string value)
        {            
            var _IOsDriver = (IOSDriver<AppiumWebElement>)MobileDriver.Value;           
            return _IOsDriver.FindElementByIosUIAutomation(value);
        }
        public void Swipe(int startX, int startY, int endX, int endY, int duration)
        {
            MobileDriver.Value.Swipe(startX, startY, endX, endY, duration);
        }
        public void SwipeInVertical(int startY, int endY, int duration)
        {
            MobileDriver.Value.Swipe(0, startY, 0, endY, duration);
        }
        public void SwipeInHorizontal(int startX, int endX, int duration)
        {
            MobileDriver.Value.Swipe(startX, 0, endX, 0, duration);
        }
        public void SwipeToElement(AppiumWebElement elementFrom,AppiumWebElement elementTo,int duration)
        {
            MobileDriver.Value.Swipe(elementFrom.Location.X,elementFrom.Location.Y,elementTo.LocationOnScreenOnceScrolledIntoView.X,elementTo.LocationOnScreenOnceScrolledIntoView.X,duration);
        }
    }
}

