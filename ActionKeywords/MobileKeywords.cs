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
        static AppiumDriver<AppiumWebElement> _MobileDriver;
        private MobileKeywords ()
        {            
        }
        static MobileKeywords ()
        {
        }         
        public static MobileKeywords Instance ()
        {
            _MobileDriver = DriverFactory.Instance.GetMobileDriver;
            return instance;
        }
        public void ScroolToClick (string text)
        {
            _MobileDriver.ScrollToExact(text).Click();
        }
        public AppiumWebElement FindElementByAndroidUIAutomator(string value)
        {            
            var _AndroidDriver = (AndroidDriver<AppiumWebElement>)_MobileDriver;   
            return _AndroidDriver.FindElementByAndroidUIAutomator(value);
        }
        public AppiumWebElement FindElementByIosUIAutomation(string value)
        {            
            var _IOsDriver = (IOSDriver<AppiumWebElement>)_MobileDriver;           
            return _IOsDriver.FindElementByIosUIAutomation(value);
        }
        public void Swipe(int startX, int startY, int endX, int endY, int duration)
        {
            _MobileDriver.Swipe(startX, startY, endX, endY, duration);
        }
        public void SwipeInVertical(int startY, int endY, int duration)
        {
            _MobileDriver.Swipe(0, startY, 0, endY, duration);
        }
        public void SwipeInHorizontal(int startX, int endX, int duration)
        {
            _MobileDriver.Swipe(startX, 0, endX, 0, duration);
        }
        public void SwipeToElement(AppiumWebElement elementFrom,AppiumWebElement elementTo,int duration)
        {
            _MobileDriver.Swipe(elementFrom.Location.X,elementFrom.Location.Y,elementTo.LocationOnScreenOnceScrolledIntoView.X,elementTo.LocationOnScreenOnceScrolledIntoView.X,duration);
        }
    }
}

