using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace AutomationFrameWork
{
    class TestNlog2
    {
        [OneTimeSetUp]
        public void OneTimeSetUp ()
        {
            Console.Write("one time set");

        }
        [OneTimeTearDown]
        public void OneTimeTearDown ()
        {
            Console.Write("one time tear");
        }
        [Test]
        public void NLog3 ()
        {
            Console.WriteLine("abc");
            Assert.IsTrue(true);
        }
        [Test]
        public void NLog4 ()
        {
            Console.WriteLine("abc");
            Assert.IsTrue(false);
        }
    }
}
