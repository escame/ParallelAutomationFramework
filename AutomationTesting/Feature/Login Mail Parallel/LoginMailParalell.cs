using NUnit.Framework;
using AutomationFrameWork.Driver;
using AutomationFrameWork.ActionsKeys;
using System.Collections.Generic;
using System;
using AutomationTesting.POM.HomePage;

namespace AutomationTesting.Feature.Login_Mail_Parallel
{

    
    [TestFixture(DriverType.Chrome)]
    [TestFixture(DriverType.EmulationiPad)]
    [TestFixture(DriverType.EmulationiPhone4)]
    [TestFixture(DriverType.EmulationiPhone5)]
    [TestFixture(DriverType.EmulationiPhone6)]
    [TestFixture(DriverType.Firefox)]     
    [Parallelizable(ParallelScope.Self)]
    class TestParalell
    {

        DriverType driver;
        public TestParalell (DriverType type)
        {
            driver = type;
        }
        [SetUp]
        public void SetUp ()
        {
            DriverFactory.Instance.StartDriver(driver);
        }
        [Test]
        [Repeat(10)]
        [Retry(10)]
        [Category("SearchGoogle")]
        public void LoginMailSucessfullyParalell ()
        {
            LoginPage.Instance.Navigate("https://accounts.google.com/ServiceLogin?service=mail&passive=true&rm=false&continue=https://mail.google.com/mail/&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1#identifier");
            LoginPage.Instance.EnterUserName("specflowdemo@gmail.com");
            LoginPage.Instance.ClickNext();
            LoginPage.Instance.EnterPass("0934058877");
            LoginPage.Instance.ClickSignIn();
            LoginPage.Instance.Verify().ValidateLoginSucesfully("specflowdemo@gmail.com");
        }
        [Test]
        [Repeat(10)]
        [Retry(10)]
        [Category("SearchGoogle")]
        public void LoginMailWrongUserName ()
        {
            LoginPage.Instance.Navigate("https://accounts.google.com/ServiceLogin?service=mail&passive=true&rm=false&continue=https://mail.google.com/mail/&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1#identifier");
            LoginPage.Instance.EnterUserName("specflowdesamo@gmail.com");
            LoginPage.Instance.ClickNext();
            LoginPage.Instance.Verify().ValidateUserNameErrorMsg("Sorry, Google doesn't recognize that email. ");
        }
        [Test]
        [Repeat(10)]
        [Retry(10)]
        [Category("SearchGoogle")]
        public void LoginMailWrongPass ()
        {
            LoginPage.Instance.Navigate("https://accounts.google.com/ServiceLogin?service=mail&passive=true&rm=false&continue=https://mail.google.com/mail/&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1#identifier");
            LoginPage.Instance.EnterUserName("specflowdemo@gmail.com");
            LoginPage.Instance.ClickNext();
            LoginPage.Instance.EnterPass("dsadsaddas");
            LoginPage.Instance.ClickSignIn();
            LoginPage.Instance.Verify().ValidatePassErrorMsg("The email and password you entered don't match.");
        }
        [Test, TestCaseSource("GetTestData")]
        [Repeat(1)]
        [Category("SearchGoogle")]
        public void TestDataDriven1 (string search)
        {
            WebKeywords.Instance.Navigate("https://google.com");
            if(driver!=DriverType.EmulationiPhone4)
            WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("lst-ib")), search);
            else
             WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("mib")), search);
        }
        [Test, TestCaseSource("GetTestData")]
        [Repeat(20)]
        [Category("SearchGoogle")]
        public void TestDataDriven2 (string search)
        {
            WebKeywords.Instance.Navigate("https://google.com");
            if (driver != DriverType.EmulationiPhone4)
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("lst-ib")), search);
            else
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("mib")), search);
        }
        [Test, TestCaseSource("GetTestData")]
        [Repeat(20)]
        [Category("SearchGoogle")]
        public void TestDataDriven3 (string search)
        {
            WebKeywords.Instance.Navigate("https://google.com");
            if (driver != DriverType.EmulationiPhone4)
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("lst-ib")), search);
            else
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("mib")), search);
        }
        [Test, TestCaseSource("GetTestData")]
        [Repeat(20)]
        [Category("SearchGoogle")]
        public void TestDataDriven4 (string search)
        {
            WebKeywords.Instance.Navigate("https://google.com");
            if (driver != DriverType.EmulationiPhone4)
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("lst-ib")), search);
            else
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("mib")), search);
        }
        [Test, TestCaseSource("GetTestData")]
        [Repeat(20)]
        [Category("SearchGoogle")]
        public void TestDataDriven5 (string search)
        {
            WebKeywords.Instance.Navigate("https://google.com");
            if (driver != DriverType.EmulationiPhone4)
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("lst-ib")), search);
            else
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("mib")), search);
        }
        [Test, TestCaseSource("GetTestData")]
        [Repeat(20)]
        [Category("SearchGoogle")]
        public void TestDataDriven6 (string search)
        {
            WebKeywords.Instance.Navigate("https://google.com");
            if (driver != DriverType.EmulationiPhone4)
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("lst-ib")), search);
            else
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("mib")), search);
        }
        [Test, TestCaseSource("GetTestData")]
        [Repeat(20)]
        [Category("SearchGoogle")]
        public void TestDataDriven7 (string search)
        {
            WebKeywords.Instance.Navigate("https://google.com");
            if (driver != DriverType.EmulationiPhone4)
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("lst-ib")), search);
            else
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("mib")), search);
        }
        [Test, TestCaseSource("GetTestData")]
        [Repeat(20)]
        [Category("SearchGoogle")]
        public void TestDataDriven8 (string search)
        {
            WebKeywords.Instance.Navigate("https://google.com");
            if (driver != DriverType.EmulationiPhone4)
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("lst-ib")), search);
            else
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("mib")), search);
        }
        [Test, TestCaseSource("GetTestData")]
        [Repeat(20)]
        [Category("SearchGoogle")]
        public void TestDataDriven9 (string search)
        {
            WebKeywords.Instance.Navigate("https://google.com");
            if (driver != DriverType.EmulationiPhone4)
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("lst-ib")), search);
            else
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("mib")), search);
        }
        [Test, TestCaseSource("GetTestData")]
        [Repeat(20)]
        [Category("SearchGoogle")]
        public void TestDataDriven10 (string search)
        {
            WebKeywords.Instance.Navigate("https://google.com");
            if (driver != DriverType.EmulationiPhone4)
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("lst-ib")), search);
            else
                WebKeywords.Instance.SetText(DriverFactory.Instance.GetWebDriver.FindElement(OpenQA.Selenium.By.Id("mib")), search);
        }
        [TearDown]
        public void TearDown ()
        {
            DriverFactory.Instance.CloseDriver();
        }

        private static IEnumerable<String> GetTestData ()
        {
            String[] data = { "Samsung Galaxy Note 5", "Apple iPhone 6+", "QA Automation", "Selenium and Nunit", "FaceBook" };
            foreach (String temp in data)
            {
                yield return temp;
            }
        }
    }
}