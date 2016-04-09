using System;
using TechTalk.SpecFlow;
using AutomationFrameWork.POM.HomePage;
using NUnit.Framework;
namespace AutomationFrameWork.Step_Definition.Login_Steps
{

    [Parallelizable(ParallelScope.Self)]
    [Binding]
    public class LoginMailSteps
    {         
        [Given(@"I have entered '(.*)' in browser")]
        public void GivenIHaveEnteredInBrowser(string url)
        {
            LoginPage.Instance.navigate(url);            
        }
        
        [When(@"I have entered '(.*)' into the username")]
        public void WhenIHaveEnteredIntoTheUsername(string username)
        {
            LoginPage.Instance.enterUserName(username);
        }
        
        [When(@"I click on next button")]
        public void WhenIClickOnNextButton()
        {
            LoginPage.Instance.clickNext();
        }
        
        [When(@"I have entered '(.*)' into the password")]
        public void WhenIHaveEnteredIntoThePassword(string password)
        {
            LoginPage.Instance.enterPass(password);
        }
        
        [When(@"i click login button")]
        public void WhenIClickLoginButton()
        {
            LoginPage.Instance.clickSignIn();
        }
        
        [Then(@"the login page display sucessfully with contain '(.*)'")]
        public void ThenTheLoginPageDisplaySucessfullyWithContain(string expected)
        {
            LoginPage.Instance.Verify().validateLoginSucesfully(expected);
        }
        [Then(@"The username error message display '(.*)'")]
        public void ThenTheUsernameErrorMessageDisplay(string expected)
        {
            LoginPage.Instance.Verify().validateUserNameErrorMsg(expected);
        }
        [Then(@"The login error message display '(.*)'")]
        public void ThenTheLoginErrorMessageDisplay(string expected)
        {
            LoginPage.Instance.Verify().validatePassErrorMsg(expected);
        }
    }
}
