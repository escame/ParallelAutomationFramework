using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NLog;
using AutomationFrameWork.Base;
using System.Net;
using System.Net.NetworkInformation;
using AutomationFrameWork.Driver.Core;

namespace AutomationFrameWork
{
    
    [Parallelizable(ParallelScope.Self)]
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
            Drivers.FreePort = Helper.DriverHelper.Instance.GetAvailablePort(65514);
            Helper.DriverHelper.Instance.GetPortToUse();
            Drivers.FreePort = Drivers.FreePort.Where(item => !Drivers.UsedPort.Contains(item)).ToList();
        }
        [TearDown]
        public void TearDown ()
        {
            Console.WriteLine(" tear down in test");
        }
        [Test]
        public void GetPort1 ()
        {

            var temp1 = Helper.DriverHelper.Instance.GetPortToUse();
            foreach (int port in temp1)
                Console.WriteLine("Check get port: " + port);
            Drivers.FreePort = Drivers.FreePort.Where(item => !Drivers.UsedPort.Contains(item)).ToList();
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port after use GetPort1: " + port);
            var temp2 = Helper.DriverHelper.Instance.GetPortToUse();
            foreach (int port in temp2)
                Console.WriteLine("Check get port: " + port);
        }
        [Test]
        public void GetPort2()
        {
            var temp1 = Helper.DriverHelper.Instance.GetPortToUse();
            foreach (int port in temp1)
                Console.WriteLine("Check get port: " + port);
            Drivers.FreePort = Drivers.FreePort.Where(item => !Drivers.UsedPort.Contains(item)).ToList();
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port after use GetPort2: " + port);
            var temp2 = Helper.DriverHelper.Instance.GetPortToUse();
            foreach (int port in temp2)
                Console.WriteLine("Check get port: " + port);
        }
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Console.WriteLine("One Time Set Up");
            Drivers.FreePort = Helper.DriverHelper.Instance.GetAvailablePort(1);
        }
    }   

    [SetUpFixture]
    public class GlobalSetup
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Console.WriteLine("One Time Set Up");
            Drivers.FreePort = Helper.DriverHelper.Instance.GetAvailablePort(1);
        }
    }
}
