using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NLog;
using AutomationFrameWork.Base;
namespace AutomationFrameWork
{
    [TestFixture][ReportManager]
    public class TestNlog 
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        [Test]
        public void TesTNlog1 ()
        {
            Console.WriteLine("test log");
            Assert.IsTrue(true);
        }
        [Test]        
        public void TesTNlog2 ()
        {
            Console.WriteLine("test log");
            Assert.IsTrue(false);
        }
        [SetUp]
        public void SetUp ()
        {
            Console.WriteLine(" set up in test");
        }
        [TearDown]
        public void TearDown ()
        {
            Console.WriteLine(" tear down in test");
        }
    }
}
