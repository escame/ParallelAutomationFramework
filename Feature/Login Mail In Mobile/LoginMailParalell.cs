using NUnit.Framework;
using AutomationFrameWork.Driver;
using AutomationFrameWork.ActionsKeys;
using AutomationFrameWork.POM.HomePage;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AutomationFrameWork.Demo
{
    [TestFixture(DriverType.Chrome)]
    [TestFixture(DriverType.InternetExplore)]
    [TestFixture(DriverType.Firefox)]
    [TestFixture(DriverType.EmulationiPad)]
    [TestFixture(DriverType.EmulationiPhone6)]
    [Parallelizable(ParallelScope.Self)]
    class LoginMailParalell
    {
        DriverType driver;
        public LoginMailParalell (DriverType type)
        {
            driver = type;       
        }      
        [SetUp]
        public void SetUp()
        {           
            DriverFactory.Instance.StartDriver(driver);            
        }
        [Test]      
        public void LoginMailSucessfullyParalell()
        {
            LoginPage.Instance.Navigate("https://accounts.google.com/ServiceLogin?service=mail&passive=true&rm=false&continue=https://mail.google.com/mail/&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1#identifier");        
            LoginPage.Instance.EnterUserName("specflowdemo@gmail.com");
            LoginPage.Instance.ClickNext();
            LoginPage.Instance.EnterPass("0934058877");
            LoginPage.Instance.ClickSignIn();
            LoginPage.Instance.Verify().ValidateLoginSucesfully("specflowdemo@gmail.com - Gmail");
        }
        [Test, TestCaseSource("GetTestData")]
        public void TestDataDriven (string search)
        {
            WebKeywords.Instance.Navigate("https://google.com");
            WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("lst-ib")),search);
            System.Threading.Thread.Sleep(3000);
        }
        [TearDown]
        public void TearDown()
        {
            DriverFactory.Instance.CloseDriver();
        }

        private static IEnumerable<String> GetTestData ()
        {
            String[] data = { "Samsung Galaxy Note 5", "Apple iPhone 6+", "QA Automation", "Selenium and Nunit", "FaceBook"};
            foreach (String temp in data)
            {
                yield return temp;
            }
        }
    }
}
