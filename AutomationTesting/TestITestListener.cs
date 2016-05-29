using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutomationFrameWork.Base.TestEventListener;
using System.Runtime.CompilerServices;
using NUnit.Engine;
using AutomationFrameWork.Driver;
namespace AutomationTesting
{
   
   
    public class TestITestListener 
    {
       
        [Test]
        public void Event ()
        {
            OpenQA.Selenium.IWebDriver driver = DriverFactory.Instance.GetWebDriver;
        }
    }
}
