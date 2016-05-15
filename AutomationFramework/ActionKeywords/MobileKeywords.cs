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
        private MobileKeywords ()
        {            
        }
        static MobileKeywords ()
        {
        }         
        public static MobileKeywords Instance ()
        {           
           return _instance;
        }
        public void ScroolToClick (string text)
        {
            DriverFactory.Instance.GetMobileDriver.ScrollToExact(text).Click();
        }
        public AppiumWebElement FindElementByAndroidUIAutomator(string value)
        {            
            var _AndroidDriver = (AndroidDriver<AppiumWebElement>)DriverFactory.Instance.GetMobileDriver;   
            return _AndroidDriver.FindElementByAndroidUIAutomator(value);
        }
        public AppiumWebElement FindElementByIosUIAutomation(string value)
        {            
            var _IOsDriver = (IOSDriver<AppiumWebElement>)DriverFactory.Instance.GetMobileDriver;           
            return _IOsDriver.FindElementByIosUIAutomation(value);
        }
        public void Swipe(int startX, int startY, int endX, int endY, int duration)
        {
            DriverFactory.Instance.GetMobileDriver.Swipe(startX, startY, endX, endY, duration);
        }
        public void SwipeInVertical(int startY, int endY, int duration)
        {
            DriverFactory.Instance.GetMobileDriver.Swipe(0, startY, 0, endY, duration);
        }
        public void SwipeInHorizontal(int startX, int endX, int duration)
        {
            DriverFactory.Instance.GetMobileDriver.Swipe(startX, 0, endX, 0, duration);
        }
        public void SwipeToElement(AppiumWebElement elementFrom,AppiumWebElement elementTo,int duration)
        {
            DriverFactory.Instance.GetMobileDriver.Swipe(elementFrom.Location.X,elementFrom.Location.Y,elementTo.LocationOnScreenOnceScrolledIntoView.X,elementTo.LocationOnScreenOnceScrolledIntoView.X,duration);
        }
    }
}

