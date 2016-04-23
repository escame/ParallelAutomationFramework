using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutomationFrameWork.Driver;
using AutomationFrameWork.ActionsKeys;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;
using AutomationFrameWork.POM.HomePage;
using AutomationFrameWork.Driver.Core;

namespace AutomationFrameWork.Demo
{
    [TestFixture(DriverType.Chrome)]
    [TestFixture(DriverType.InternetExplore)]
    [TestFixture(DriverType.Firefox)]
    [TestFixture(DriverType.EmulationiPhone4)]
    //[Parallelizable(ParallelScope.Self)]
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
            WebKeywords.Instance.Navigate("https://accounts.google.com/ServiceLogin?service=mail&passive=true&rm=false&continue=https://mail.google.com/mail/&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1#identifier");
            LoginPage.Instance.EnterUserName("specflowdemo@gmail.com");
            LoginPage.Instance.ClickNext();
            LoginPage.Instance.EnterPass("0934058877");
            LoginPage.Instance.ClickSignIn();
            LoginPage.Instance.Verify().ValidateLoginSucesfully("specflowdemo@gmail.com - Gmail");
        }
        [TearDown]
        public void TearDown()
        {
            DriverFactory.Instance.CloseDriver();
        }
    }
}
