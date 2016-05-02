using AutomationFrameWork.Driver;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using System.Threading;

namespace AutomationFrameWork.ActionsKeys
{
    public class MobileKeywords
    {       
        private static readonly MobileKeywords _instance = new MobileKeywords();
        private static AppiumDriver<AppiumWebElement> _mobileDriver;
        private MobileKeywords ()
        {            
        }
        static MobileKeywords ()
        {
        }         
        public static MobileKeywords Instance ()
        {
            _mobileDriver = DriverFactory.Instance.GetMobileDriver;
            return _instance;
        }
        public void ScroolToClick (string text)
        {
            _mobileDriver.ScrollToExact(text).Click();
        }
        public AppiumWebElement FindElementByAndroidUIAutomator(string value)
        {            
            var _AndroidDriver = (AndroidDriver<AppiumWebElement>)_mobileDriver;   
            return _AndroidDriver.FindElementByAndroidUIAutomator(value);
        }
        public AppiumWebElement FindElementByIosUIAutomation(string value)
        {            
            var _IOsDriver = (IOSDriver<AppiumWebElement>)_mobileDriver;           
            return _IOsDriver.FindElementByIosUIAutomation(value);
        }
        public void Swipe(int startX, int startY, int endX, int endY, int duration)
        {
            _mobileDriver.Swipe(startX, startY, endX, endY, duration);
        }
        public void SwipeInVertical(int startY, int endY, int duration)
        {
            _mobileDriver.Swipe(0, startY, 0, endY, duration);
        }
        public void SwipeInHorizontal(int startX, int endX, int duration)
        {
            _mobileDriver.Swipe(startX, 0, endX, 0, duration);
        }
        public void SwipeToElement(AppiumWebElement elementFrom,AppiumWebElement elementTo,int duration)
        {
            _mobileDriver.Swipe(elementFrom.Location.X,elementFrom.Location.Y,elementTo.LocationOnScreenOnceScrolledIntoView.X,elementTo.LocationOnScreenOnceScrolledIntoView.X,duration);
        }
    }
}

