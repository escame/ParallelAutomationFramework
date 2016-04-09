using OpenQA.Selenium;
using AutomationFrameWork.Base.Driver;
namespace AutomationFrameWork.Base
/// <summary>
///  This class will create WebDriver for any class extend from it
///  WebDriver use for findElement/findElements
/// </summary>
{
    public class BaseWebElements
    {
        protected IWebDriver WebDriver;
        public BaseWebElements()
        {
            this.WebDriver = DriverFactory.Instance.GetWebDriver;
        }
    }
}
