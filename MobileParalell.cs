using OpenQA.Selenium.Remote;
using AutomationFrameWork.Base.Driver;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using System;
using OpenQA.Selenium;

namespace AutomationFrameWork
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture("note")]
    [TestFixture("nexus")]
    class MobileParalell
    {
        string devices=string.Empty;
        AndroidDriver<AppiumWebElement> driver=null;       
        public MobileParalell(string value)
        {
            Console.WriteLine("Param: "+value);
            Console.WriteLine("Value: "+ devices);
            this.devices = value;
            Console.WriteLine("Param after: " + value);
            Console.WriteLine("Value after: " + devices);
        }
        [SetUp]
        public void setUp()
        {
            Console.WriteLine("value to run: "+ devices);
            DesiredCapabilities cap = new DesiredCapabilities();
            if (devices.Equals("note"))
            {
                Console.WriteLine("run note");
                cap.SetCapability("deviceName", "note 5");
                cap.SetCapability("udid", "0415313132353234");
                cap.SetCapability("browserName", MobileBrowserType.Chrome);
                DriverFactory.Instance.DesiredCapabilities = cap;
                DriverFactory.Instance.AppiumInfo("127.0.0.1", 6969);
                DriverFactory.Instance.StartDriver(DriverType.Android);
                driver = (AndroidDriver<AppiumWebElement>)DriverFactory.Instance.GetMobileDriver;
            }
            else if(devices.Equals("nexus"))
            {
                Console.WriteLine("run nexus");
                cap.SetCapability("deviceName", "nexus 7");
                cap.SetCapability("udid", "015d4a5f1d382214");
                cap.SetCapability("browserName", MobileBrowserType.Chrome);
                DriverFactory.Instance.DesiredCapabilities = cap;
                DriverFactory.Instance.AppiumInfo("127.0.0.1", 4040);
                DriverFactory.Instance.StartDriver(DriverType.Android);
                driver = (AndroidDriver<AppiumWebElement>)DriverFactory.Instance.GetMobileDriver;
            }           
          
        }
        [TearDown]
        public void tearDown()
        {
            DriverFactory.Instance.CloseDriver();
        }
        
        [Test]
        public void Mobile()
        {
            /*
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("deviceName", "note 5");
            cap.SetCapability("udid", "0415313132353234");
            cap.SetCapability("browserName", MobileBrowserType.Chrome);
            DriverFactory.Instance.DesiredCapabilities = cap;
            DriverFactory.Instance.AppiumInfo("127.0.0.1",6969);
            DriverFactory.Instance.start(DriverType.Android);
            AndroidDriver<AppiumWebElement> driver = (AndroidDriver<AppiumWebElement>)DriverFactory.Instance.GetMobileDriver;            
            */


            driver.Url = "http://www.google.com";
            Assert.True(driver.Title.Equals("Google"));
            driver.FindElement(By.Id("lst-ib")).SendKeys("KMS Technology");
            driver.FindElement(By.Name("btnG")).Click();
            //DriverFactory.Instance.CloseWebDriver();
        }        
    }
}
