using NUnit.Framework;
using AutomationFrameWork.Driver;
using AutomationFrameWork.ActionsKeys;
using AutomationFrameWork.POM.HomePage;
using OpenQA.Selenium.Chrome;

namespace AutomationFrameWork.Demo
{
    [TestFixture(DriverType.Chrome)]
    [TestFixture(DriverType.InternetExplore)]
    [TestFixture(DriverType.Firefox)]
    [TestFixture(DriverType.EmulationiPhone4)]
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
            
            if (driver == DriverType.Chrome)
            {
                ChromeOptions op = new ChromeOptions();
                op.AddArgument("--user-agent=Mozilla/5.0 (iPad; CPU OS 9_1 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/9.0 Mobile/10A5355d Safari/8536.25");
                DriverFactory.Instance.DriverOptions = op;
            }
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
