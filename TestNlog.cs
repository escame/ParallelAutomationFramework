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
            Drivers.FreePort = Helper.DriverHelper.Instance.GetAvailablePort(65504);
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port set up: " + port);
            Drivers.PortStorage=Helper.DriverHelper.Instance.GetPortToUse();
            foreach (int port in Drivers.PortStorage)
                Console.WriteLine("Free port use set up: " + port);
            Drivers.FreePort = Drivers.FreePort.Where(item => !Drivers.UsedPort.Contains(item)).ToList();
        }
        [TearDown]
        public void TearDown ()
        {

            foreach (int port in Drivers.PortStorage)
                Console.WriteLine("storage port tear down: " + port);
            var temp = (from value in Drivers.UsedPort where ! Drivers.PortStorage.Contains(value) select value).ToList();           
            foreach (int port in temp)
                Console.WriteLine("Use port tear down: " + port);
            Drivers.FreePort.AddRange(Drivers.PortStorage);
            Drivers.FreePort.Sort();
            Console.WriteLine(" tear down in test");
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port after use teardown: " + port);
        }
        [Test]
        public void GetPort1 ()
        {

            var temp1 = Helper.DriverHelper.Instance.GetPortToUse();
            Drivers.PortStorage.AddRange(temp1.GetRange(0,3));
            foreach (int port in temp1)
                Console.WriteLine("Check get port: " + port);
            Drivers.FreePort = Drivers.FreePort.Where(item => !Drivers.UsedPort.Contains(item)).ToList();
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port after use GetPort1: " + port);
            var temp2 = Helper.DriverHelper.Instance.GetPortToUse();
            Drivers.PortStorage.AddRange(temp2.GetRange(0, 3));
            foreach (int port in temp2)
                Console.WriteLine("Check get port: " + port);
            Drivers.FreePort = Drivers.FreePort.Where(item => !Drivers.UsedPort.Contains(item)).ToList();
        }
        [Test]
        public void GetPort2()
        {
            var temp1 = Helper.DriverHelper.Instance.GetPortToUse();
            Drivers.PortStorage.AddRange(temp1.GetRange(0, 3));
            foreach (int port in temp1)
                Console.WriteLine("Check get port: " + port);
            Drivers.FreePort = Drivers.FreePort.Where(item => !Drivers.UsedPort.Contains(item)).ToList();
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port after use GetPort2: " + port);
            var temp2 = Helper.DriverHelper.Instance.GetPortToUse();
            Drivers.PortStorage.AddRange(temp2.GetRange(0, 3));
            foreach (int port in temp2)
                Console.WriteLine("Check get port: " + port);
            Drivers.FreePort = Drivers.FreePort.Where(item => !Drivers.UsedPort.Contains(item)).ToList();
        }
        [Test]
        public void GetPort3 ()
        {
            var temp1 = Helper.DriverHelper.Instance.GetPortToUse();
            Drivers.PortStorage.AddRange(temp1.GetRange(0, 3));
            foreach (int port in temp1)
                Console.WriteLine("Check get port: " + port);
            Drivers.FreePort = Drivers.FreePort.Where(item => !Drivers.UsedPort.Contains(item)).ToList();
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port after use GetPort2: " + port);
            var temp2 = Helper.DriverHelper.Instance.GetPortToUse();
            Drivers.PortStorage.AddRange(temp2.GetRange(0, 3));
            foreach (int port in temp2)
                Console.WriteLine("Check get port: " + port);
            Drivers.FreePort = Drivers.FreePort.Where(item => !Drivers.UsedPort.Contains(item)).ToList();
        }
        [Test]
        public void GetPort4 ()
        {
            var temp1 = Helper.DriverHelper.Instance.GetPortToUse();
            Drivers.PortStorage.AddRange(temp1.GetRange(0, 3));
            foreach (int port in temp1)
                Console.WriteLine("Check get port: " + port);
            Drivers.FreePort = Drivers.FreePort.Where(item => !Drivers.UsedPort.Contains(item)).ToList();
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port after use GetPort2: " + port);
            var temp2 = Helper.DriverHelper.Instance.GetPortToUse();
            Drivers.PortStorage.AddRange(temp2.GetRange(0, 3));
            foreach (int port in temp2)
                Console.WriteLine("Check get port: " + port);
            Drivers.FreePort = Drivers.FreePort.Where(item => !Drivers.UsedPort.Contains(item)).ToList();
        }
    }      
}
