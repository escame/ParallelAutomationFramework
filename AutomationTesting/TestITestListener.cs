using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Runtime.CompilerServices;
using NUnit.Engine;
using AutomationFrameWork.Driver;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using AutomationFrameWork.Utils;
using AutomationFrameWork.ActionsKeys;
using System.Web.UI;
using System.IO;
using AutomationFrameWork.Extensions;
using System.Collections.ObjectModel;
using Mono.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTesting
{

    [TestFixture(DriverType.Chrome)]
    [TestFixture(DriverType.EmulationiPhone4)]
    [TestFixture(DriverType.EmulationiPhone5)]
    [TestFixture(DriverType.EmulationiPhone6)]
    [TestFixture(DriverType.EmulationiPad)]
    [TestFixture(DriverType.Firefox)]
    [TestFixture(DriverType.InternetExplore)]   
    public class TestITestListener
    {
        DriverType _type;
        IWebDriver driver;
        public TestITestListener(DriverType type)
        {
            _type = type;
        }
        [Category("Capture Element Image")]
        [Test]
        public void Event ()
        {
            ChromeOptions op = new ChromeOptions();
            op.EnableMobileEmulation("Apple iPhone 4");
            //DriverFactory.Instance.DriverOption = op;
            DriverFactory.Instance.StartDriver(DriverType.Chrome, isMaximazie: true);
            IWebDriver driver = DriverFactory.Instance.GetWebDriver;
            driver.Url = "https://www.whatismybrowser.com/";
            IWebElement el = driver.FindElement(By.XPath("//*[@id='holder']//*[@class='detection-primary content-block']"));
            WebKeywords.Instance.GetScreenShot();
            Utilities.Instance.GetWebElementBaseImage(el, formatType: System.Drawing.Imaging.ImageFormat.Jpeg);
            driver.Dispose();
            DriverFactory.Instance.CloseDriver();
        }
        [Category("TestReportTemplate")]
        [Test]
        public void CreateHTML ()
        {
            string FullPage = string.Empty;
            var strWr = new StringWriter();
            using (var writer = new HtmlTextWriter(strWr))
            {
                writer.Write("<!DOCTYPE html>");
                writer.AddAttribute(HtmlTextWriterAttribute.Id,"Test");
                writer.RenderBeginTag(HtmlTextWriterTag.Head);
                writer.AddAttribute("http-equiv", "X-UA-Compatible");
                writer.AddAttribute("content", @"IE=edge");
                writer.AddAttribute("charset", "utf-8");
                writer.RenderBeginTag(HtmlTextWriterTag.Meta);
                writer.RenderEndTag();
                writer.AddAttribute(HtmlTextWriterAttribute.Rel, "stylesheet");
                writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/css");
                writer.AddAttribute(HtmlTextWriterAttribute.Href, @"D:\WorkSpace\Git\AutomationFramework\AutomationFramework\Base\Reporter\EmbeddedResources\Primer\primer.css");
                writer.RenderBeginTag(HtmlTextWriterTag.Link);
                writer.RenderEndTag();
                writer.NewLine = "\r\n";
                writer.AddAttribute(HtmlTextWriterAttribute.Id, "Div 1");              
                writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "center");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.AddAttribute(HtmlTextWriterAttribute.Id, "testname");
                writer.RenderBeginTag(HtmlTextWriterTag.A);
                writer.RenderBeginTag(HtmlTextWriterTag.H1);
                writer.Write("Test this show in html page");                
                writer.NewLine = "\r\n";
                writer.RenderEndTag();        
                writer.RenderEndTag();
                writer.RenderEndTag();
                writer.RenderEndTag();               
                writer.Write("</html>");        
            }
            FullPage = strWr.ToString();
            File.WriteAllText(@"C:\Users\Minh\Desktop\New folder\TestReport.html", FullPage);
        }
        #region
        //Test FindContext
        [Test]
        [Repeat(5)]
        [Category("Context")]
        public void TestContextFind ()
        {           
            driver.Url = "http://www.google.com";
            driver.Navigate().GoToUrl("http://vtc.vn");
            driver.Navigate().Back();            
        }
        [SetUp]
        public void SetUp()
        {
                DriverFactory.Instance.StartDriver(_type);
                driver = DriverFactory.Instance.GetWebDriver;
            
        }
        [TearDown]
        public void TearDown()
        {
            DriverFactory.Instance.CloseDriver();
        }
        #endregion
    }
}
