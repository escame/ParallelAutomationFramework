using OpenQA.Selenium;
using AutomationFrameWork.Base;
using AutomationFrameWork.ActionsKeys;

namespace AutomationFrameWork.POM.HomePage
{
    class LoginPage : BasePageWeb<LoginPage,LoginElement,LoginValidate>
    {       
       
        public void navigate(string url)
        {
            WebKeywords.Instance.Navigate(url);
        }
        public void enterUserName(string username)
        {
            WebKeywords.Instance.SetText(Element.txtUserName, username);
        }
        public void clickNext()
        {
            WebKeywords.Instance.Click(Element.btnNext);
        }
        public void clickSignIn()
        {
            WebKeywords.Instance.Click(Element.btnSignin);
        }
        public void enterPass(string pass)
        {
            WebKeywords.Instance.WaitElementToBeClickable(Element.waitTxtPass,30);
            WebKeywords.Instance.SetText(Element.txtPassword,pass);
        }        
    }
}
