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
using System.Threading;
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
            Console.WriteLine("Thread ID in setup: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            Drivers.FreePort = Helper.DriverHelper.Instance.GetAvailablePort(65504);
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port set up: " + port);
            Helper.DriverHelper.Instance.GetPortToUse();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in thread id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in set up: " + portValue);
            }
        }
        [TearDown]
        public void TearDown ()
        {
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
                Drivers.FreePort.AddRange(port.Value.ToList());
            Drivers.FreePort.Sort();
            Console.WriteLine(" tear down in test");
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port after use teardown: " + port);
        }
        [Test]
        public void GetPort1 ()
        {
            Console.WriteLine("Thread ID in test: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            Helper.DriverHelper.Instance.GetPortToUse();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 1: " + portValue);
            }
            Helper.DriverHelper.Instance.GetPortToUse();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 2: " + portValue);
            }
        }
        [Test]
        public void GetPort2()
        {
            Console.WriteLine("Thread ID in test: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            Helper.DriverHelper.Instance.GetPortToUse();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 1: " + portValue);
            }
            Helper.DriverHelper.Instance.GetPortToUse();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 2: " + portValue);
            }
        }
        [Test]
        public void GetPort3 ()
        {
            Console.WriteLine("Thread ID in test: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            Helper.DriverHelper.Instance.GetPortToUse();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 1: " + portValue);
            }
            Helper.DriverHelper.Instance.GetPortToUse();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 2: " + portValue);
            }
        }
        [Test]
        public void GetPort4 ()
        {
            Console.WriteLine("Thread ID in test: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            Helper.DriverHelper.Instance.GetPortToUse();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 1: " + portValue);
            }
            Helper.DriverHelper.Instance.GetPortToUse();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 2: " + portValue);
            }
        }
    }      
}
