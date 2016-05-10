using System;
using TechTalk.SpecFlow;
using AutomationFrameWork.Driver;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;
using NUnit.Framework;
using AutomationFrameWork.ActionsKeys;
using OpenQA.Selenium;
using System.Collections.Generic;
using AutomationFrameWork.Helper;
using System.Drawing;
using System.Text.RegularExpressions;

namespace MobileFrameWork.Step_Definition.Common_Steps
{
    [Parallelizable(ParallelScope.Self)]
    [Binding]
    public class CommonlSteps
    {
        DesiredCapabilities capabilities = new DesiredCapabilities();
        Dictionary<string, string> CSSActual;
        string DeviceType;
        [BeforeScenario]
        public void setUp()
        {
            Console.WriteLine("Start run test....");
        }
        [Given(@"I start '(.*)' browser to run")]
        public void GivenIUseBrowserToRun(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    DriverFactory.Instance.StartDriver(DriverType.Chrome);            
                    break;
                case "ipad":
                    DriverFactory.Instance.StartDriver(DriverType.EmulationiPad);     
                    break;
                case "iphone6":
                    DriverFactory.Instance.StartDriver(DriverType.EmulationiPhone6);  
                    break;
                case "iphone5":
                    DriverFactory.Instance.StartDriver(DriverType.EmulationiPhone5); 
                    break;
                case "iphone4":
                    DriverFactory.Instance.StartDriver(DriverType.EmulationiPhone4);  
                    break;
                case "nexus6":
                    DriverFactory.Instance.StartDriver(DriverType.EmulationNexus6);  
                    break;
                case "firefox":
                    DriverFactory.Instance.StartDriver(DriverType.Firefox);          
                    break;
                case "ie":
                    DriverFactory.Instance.StartDriver(DriverType.InternetExplore);   
                    break;
                case "phantomjs":
                    DriverFactory.Instance.StartDriver(DriverType.PhantomJS);         
                    break;
                case "remote":
                    DriverFactory.Instance.StartDriver(DriverType.Remote);          
                    break;
                default:
                    throw new ArgumentException("Invalid browser name, please type 'Chrome' 'Firefox' 'IE' 'iPad' 'Phantomjs' 'Remote' 'Nexus6' 'iPhone6' 'iPhone5' 'iPhone4' for can start browser");
            }
        }
        [Given(@"I navigate to '(.*)'")]
        public void NavigateTo(string url)
        {
            WebKeywords.Instance.Navigate(url);
        }
        [Given(@"I use '(.*)' device with uid '(.*)' and device name '(.*)'")]
        public void GivenIUseDeviceWithUidAndDeviceName(string deviceType, string deviceUID, string deviceName)
        {
            DeviceType = deviceType;
            capabilities.SetCapability("deviceName", deviceName);
            capabilities.SetCapability("udid", deviceUID);
        }
        [Given(@"I start app with appActivity '(.*)' and appPackage '(.*)'")]
        public void GivenIStartApp(string appActivity, string appPackage)
        {
            capabilities.SetCapability("appActivity", appActivity);
            capabilities.SetCapability("appPackage", appPackage);
        }
        [Given(@"I start '(.*)' browser on device")]
        public void GivenStartDeviceBrowser(string browserName)
        {

            switch (browserName.ToLower())
            {
                case "browser":
                    capabilities.SetCapability("browserName", MobileBrowserType.Browser);
                    break;
                case "chrome":
                    capabilities.SetCapability("browserName", MobileBrowserType.Chrome);
                    break;
                case "chromium":
                    capabilities.SetCapability("browserName", MobileBrowserType.Chromium);
                    break;
                case "safari":
                    capabilities.SetCapability("browserName", MobileBrowserType.Safari);
                    break;
                default:
                    throw new ArgumentException("Invalid browser name, please type 'Browser' 'Chrome' 'Chromium' 'Safari' for can start browser");
            }
        }
        [Given(@"Appium server has address '(.*)' with port listen '(.*)'")]
        public void GivenAppiumServer(string address, int portListen)
        {
            DriverFactory.Instance.DesiredCapabilities = capabilities;
            DriverFactory.Instance.RemoteInformation(address, portListen);
            if (DeviceType.ToLower().Equals("android"))
                DriverFactory.Instance.StartDriver(DriverType.Android);
            else if (DeviceType.ToLower().Equals("ios"))
                DriverFactory.Instance.StartDriver(DriverType.iOS);
            else
                throw new ArgumentException("Please select device in 'Android' or 'iOS' for can start automation");
        }
        [Given(@"I get CSS Attribute of '(.*)'")]
        public void GetCSSActual(string element)
        {
            IWebElement elementTemp = WebKeywords.Instance.FindElement(element);
            CSSActual = new Dictionary<string, string>();
            CSSActual = ValidateHelper.Instance.ReturnActualCssValue(elementTemp);
            Console.WriteLine("Get CSS of " + element);
            foreach (KeyValuePair<string, string> data in CSSActual)
            {
                Console.WriteLine(data.Key + ": " + data.Value);
            }
            Console.WriteLine("--------------------------------------------------");
        }
        [Then(@"It should be match with style guide '(.*)' in viewport '(.*)' with '(.*)' and '(.*)'")]
        public void ValidateStyle(string siteMap, string viewPort, string cssType, string cssExpected)
        {
            Dictionary<string, string> expectedCSS = new Dictionary<string, string>();
            expectedCSS= ValidateHelper.Instance.ReturnExpectedCSSValue("Resources//3654", "5454.['xyz'].abc");

        }
        [AfterScenario]
        public void cleanUp()
        {
            Console.WriteLine("Stop run test....");
            DriverFactory.Instance.CloseDriver();
        }

    }
}
