using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using AutomationFrameWork.POM.HomePage;
using AutomationFrameWork.Base.Driver;

namespace AutomationFrameWork.Feature.Login_Mail_With_Singleton
{
    [Parallelizable(ParallelScope.Self)]    
    [TestFixture(DriverType.Chrome)]
    [TestFixture(DriverType.InternetExplore)]
    [TestFixture(DriverType.Firefox)]
    class LoginMail
    {
        //IWebDriver driver;
        DriverType type;
        public LoginMail(DriverType param)
        {
            this.type = param;
        }
        [SetUp]
        public void setUp()
        {
            DriverFactory.Instance.StartDriver(type);
            LoginPageS.Instance.navigate("https://accounts.google.com/ServiceLogin?service=mail&passive=true&rm=false&continue=https://mail.google.com/mail/&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1#identifier");
        }
        [TearDown]
        public void tearDown()
        {
            DriverFactory.Instance.CloseDriver();
        }

        [Test]
        public void LoginSucessfullyWithSingleton()
        {
            LoginPageS.Instance.enterUserName("specflowdemo@gmail.com");
            LoginPageS.Instance.clickNext();
            LoginPageS.Instance.enterPass("0934058877");
            LoginPageS.Instance.clickSignIn();
            LoginPageS.Instance.Verify().validateLoginSucesfully("specflowdemo@gmail.com - Gmail");
        }
    }
}
