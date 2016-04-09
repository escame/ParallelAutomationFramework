using OpenQA.Selenium.Remote;
using NUnit.Framework;
using AutomationFrameWork.Base.Driver;
using System;
using AutomationFrameWork.ActionsKeys;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System.Threading;
using AutomationFrameWork.Driver;

namespace AutomationFrameWork.TestParalell
{
   
    //[TestFixture(DriverType.Chrome)]
    //[TestFixture(DriverType.Chrome)]
    //[TestFixture(DriverType.EmulationiPad)]
    [TestFixture(DriverType.InternetExplore)]
   

    [Parallelizable(ParallelScope.Self)]
    class ChangeDateTime
    {
        private DriverType param;
        //private static object lockObject = new object();
        public ChangeDateTime (DriverType paramValue)
        {
           
           
                Console.WriteLine(paramValue);
                param = paramValue;
           
        }
        IWebDriver driver;
        //public static NodeFactory node;
        //static AndroidDriver<AppiumWebElement> driver;
        //[Parallelizable(ParallelScope.Self)]
        /*
        [OneTimeSetUp]
        public void runNode()
        {
            DriverFactory.StartDriver(DriverType.Chrome);
            Console.Out.WriteLine("abc");
            //node = new NodeFactory("127.0.0.1",6969,6968,20);
            Console.WriteLine("check name: " +OpenQA.Selenium.Appium.Enums.MobileBrowserType.Chrome);
            Console.WriteLine("check name: " + OpenQA.Selenium.Appium.Enums.MobileBrowserType.Browser);
            Console.WriteLine("check name: " + OpenQA.Selenium.Appium.Enums.MobileBrowserType.Safari);
            Console.WriteLine("check name: " + OpenQA.Selenium.Appium.Enums.MobileBrowserType.Chromium);
        }
        */
        [SetUp]
        public void setUp()
        {
            /*
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("deviceName", "test");
            capabilities.SetCapability("udid", "015d2a4ff71bee08");
            capabilities.SetCapability("appPackage", "com.android.settings");
            capabilities.SetCapability("appActivity", ".Settings");
            DriverFactory.DesiredCapabilities = capabilities;
            DriverFactory.PortNumber = 6969;
            DriverFactory.AddressNumber = "127.0.0.1";
            DriverFactory.startDriver(DriverType.Android);
            driver = (AndroidDriver<AppiumWebElement>) DriverFactory.AppiumDriver;
            */
            //DriverFactory.StartDriver(param);
            //driver = DriverFactory.WebDriver;
            Console.WriteLine("Check param set up: " + param);
            DriverFactory.Instance.StartDriver(param);
            driver = DriverFactory.Instance.GetWebDriver;
        }
        [TearDown]
        public void teardDown()
        {
           
                Console.WriteLine("Check param close: " + param);
            //Chrome.Instance.CloseDriver();
            DriverFactory.Instance.CloseDriver();


        }
        /*
        [Test]
        public void ChnageDateTimeInNote5()
        {
            Console.WriteLine("test run" + WebKeywords.Instance().GetTitle());
            //driver.ScrollToExact("Date & time").Click();                  
        }
        */       
        [Test]
        public void Test1 ()
        {
            //Chrome chrome = new Chrome();
            //Console.WriteLine(param);
            //DriverFactory.Instance.StartDriver(param);
            //IWebDriver driver = DriverFactory.Instance.WebDriver;
            //Chrome.Instance.StartDriver();            
            //IWebDriver driver =  Chrome.Instance.ChromeDriver;
            //IWebDriver driver = DriverFactory.ChromeDriver();
            driver.Url = "https://www.whatismybrowser.com/";
            //driver.Url = "https://www.google.com";
            //Assert.AreEqual(driver.Title, "Google");
            Thread.Sleep(2000);
            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='holder']//div[@class='corset']//div[@class='string-major']")).GetAttribute("innerText"));
            //Console.WriteLine(driver.Title);
            //Chrome.Instance.CloseDriver();
            //Chrome.Instance.CloseDriver();
        }

        [Test]
        public void Test2 ()
        {

            //Chrome chrome = new Chrome();
            //Console.WriteLine(param);
            DriverFactory.Instance.StartDriver(param);
            IWebDriver driver = DriverFactory.Instance.GetWebDriver;
            //Chrome.Instance.StartDriver();            
            //IWebDriver driver =  Chrome.Instance.ChromeDriver;
            //IWebDriver driver = DriverFactory.ChromeDriver();
            driver.Url = "https://www.whatismybrowser.com/";
            //Assert.AreEqual(driver.Title, "Google");
            Thread.Sleep(2000);
            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='holder']//div[@class='corset']//div[@class='string-major']")).GetAttribute("innerText"));
            //Chrome.Instance.CloseDriver();
            //Chrome.Instance.CloseDriver();
        }

        [Test]
        public void Test3 ()
        {

            //Chrome chrome = new Chrome();
            //Console.WriteLine(param);
            DriverFactory.Instance.StartDriver(param);
            IWebDriver driver = DriverFactory.Instance.GetWebDriver;
            //Chrome.Instance.StartDriver();            
            //IWebDriver driver =  Chrome.Instance.ChromeDriver;
            //IWebDriver driver = DriverFactory.ChromeDriver();
            driver.Url = "https://www.whatismybrowser.com/";
            //Assert.AreEqual(driver.Title, "Google");
            Thread.Sleep(2000);
            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='holder']//div[@class='corset']//div[@class='string-major']")).GetAttribute("innerText"));
            //Chrome.Instance.CloseDriver();
            //Chrome.Instance.CloseDriver();
        }
        [Test]
        public void Test4 ()
        {
            //Chrome chrome = new Chrome();
            //Console.WriteLine(param);
            DriverFactory.Instance.StartDriver(param);
            IWebDriver driver = DriverFactory.Instance.GetWebDriver;
            //Chrome.Instance.StartDriver();            
            //IWebDriver driver =  Chrome.Instance.ChromeDriver;
            //IWebDriver driver = DriverFactory.ChromeDriver();
            driver.Url = "https://www.whatismybrowser.com/";
            //Assert.AreEqual(driver.Title, "Google");
            Thread.Sleep(2000);
            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='holder']//div[@class='corset']//div[@class='string-major']")).GetAttribute("innerText"));
            //Chrome.Instance.CloseDriver();
            //Chrome.Instance.CloseDriver();
        }
        [Test]
        public void testNode ()
        {
            NodeFactory node = new NodeFactory("127.0.0.1",6969,6868);
            Thread.Sleep(5000);
            node.closeNodeServer();
        }
        /*
        [TearDown]
        public void clean()
        {
            Console.WriteLine("clean");
            //DriverFactory.closeAppiumDriver();
        } 
        /*      
        [OneTimeTearDown]
        public void closeNode()
        {
            System.Diagnostics.Debug.WriteLine("Matrix has you...");
            DriverFactory.CloseWebDriver();
            //node.closeNodeServer();
        }
        */
    }
}
