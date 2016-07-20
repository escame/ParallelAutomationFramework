using AutomationFrameWork.Driver;
using NUnit.Framework;
using OpenQA.Selenium.PhantomJS;
using System;
using System.IO;

namespace AutomationTesting.DemoPhantomJS
{
    class NetworkSniffer
    {        
        [SetUp]
        public void SetUp()
        {
            DriverConfiguration configuration = new DriverConfiguration();
            var options = new PhantomJSOptions();
            options.AddAdditionalCapability("phantomjs.page.settings.UserAgent", "Mozilla/5.0 (iPad; U; CPU OS 3_2 like Mac OS X;en-us) AppleWebKit/531.21.10 (KHTML, like Gecko) Version/4.0.4Mobile/7B334b Safari/531.21.10 ");
            var services = PhantomJSDriverService.CreateDefaultService();
            services.LogFile = "D:\\AutomationReport\\Log.txt";
            configuration.DriverServices = services;
            configuration.DesiredCapabilities = options;
            DriverManager.StartDriver(FactoryType.PhantomJSBrowserFactory, Browser.PhantomJSBrowser,configuration);
        }
        [Test,Description("Demo PhantomJS"),Category("Demo Network Sniffer")]
        public void DemoNetworkSniffer()
        {
            var driver = DriverManager.GetDriver<OpenQA.Selenium.PhantomJS.PhantomJSDriver>();           driver.ExecutePhantomJS(File.ReadAllText(@"D:\WorkSpace\Git\AutomationFramework\AutomationTesting\Feature\Demo Network Sniffer\netlog.js"));             
            driver.Url = "https://www.google.com";
            System.Console.WriteLine(driver.Title);

        }
        [TearDown]
        public void TearDown()
        {
            DriverManager.CloseDriver();
        }
    }
}
