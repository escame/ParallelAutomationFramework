using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using AutomationFrameWork.Helper;
namespace AutomationFrameWork.Driver
{
    class EmulationiPad : Drivers
    {
        protected override object StartDriver(int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            ChromeOptions op = (ChromeOptions)Drivers.DriverOptions;
            if (op == null)
                op = new ChromeOptions();
            op.AddArgument("--user-agent=Mozilla/5.0 (iPad; CPU OS 9_1 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/9.0 Mobile/10A5355d Safari/8536.25");
            IWebDriver driver = new ChromeDriver(DriverHelper.Instance.DriverPath, op);
            driver.Manage().Window.Size = new Size(1024, 768);
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(scriptTimeout));
            if (isMaximize)
                driver.Manage().Window.Maximize();
            return driver;
        }
    }
}