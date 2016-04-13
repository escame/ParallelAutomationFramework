﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutomationFrameWork.Base.Driver;
using AutomationFrameWork.ActionsKeys;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;
using AutomationFrameWork.POM.HomePage;
namespace AutomationFrameWork.Feature.Search_Google_In_Note_5
{
    class LoginMailInMobile
    {
        [SetUp]
        public void SetUp()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("deviceName", "Note5");
            caps.SetCapability("udid", "0415313132353234");
            caps.SetCapability("browserName", MobileBrowserType.Chrome);
            DriverFactory.Instance.DesiredCapabilities = caps;
            DriverFactory.Instance.AppiumInfo("127.0.0.1",6969);
            DriverFactory.Instance.StartDriver(DriverType.Android);
        }
        [Test]
        public void LoginMailSucessfullyMobile()
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