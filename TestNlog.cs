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
        /*
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
            Drivers.FreePort = Helper.DriverHelper.Instance.GetAvailablePort(65499);
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port set up: " + port);
            Helper.DriverHelper.Instance.GetPortToUse();           
            Helper.DriverHelper.Instance.UpdateUsedPort();
            Helper.DriverHelper.Instance.UpdateFreePort();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in thread id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in set up: " + portValue);
            }
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port after finish setup: " + port);
        }
        [TearDown]
        public void TearDown ()
        {
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port before use ReleasePort: " + port);
            Helper.DriverHelper.Instance.ReleasePort();
            Helper.DriverHelper.Instance.UpdateFreePort();
            Helper.DriverHelper.Instance.UpdateUsedPort();
            Drivers.FreePort.Sort();
            Console.WriteLine(" tear down in test");
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port after use teardown: " + port);
        }
        */
        [SetUp]
        public void abc ()
        {
            Drivers.FreePort=Helper.DriverHelper.Instance.GetAvailablePort(65511);
        }
        [TearDown]
        public void TearDown ()
        {
            foreach (KeyValuePair<int, List<int>> port in Drivers.UsedPort)
            {
                Console.WriteLine("Get port value in test teardown: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port used in teardown: " + portValue);
            }
            Console.WriteLine("---------------------------------------------------");
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port store in test teardown: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port store in teardown: " + portValue);
            }
            Helper.DriverHelper.Instance.ReleasePort();

            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port after release: " + port);
        }
        [Test]
        public void GetPort1 ()
        {
            Console.WriteLine("Thread ID in test: " + System.Threading.Thread.CurrentThread.ManagedThreadId);         
            Helper.DriverHelper.Instance.GetPortToUse();
            Helper.DriverHelper.Instance.UpdatePort();
            //Helper.DriverHelper.Instance.UpdateUsedPort();
            //Helper.DriverHelper.Instance.UpdateFreePort();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 1: " + portValue);
            }             
            Helper.DriverHelper.Instance.GetPortToUse();
            Helper.DriverHelper.Instance.UpdatePort();
            //Helper.DriverHelper.Instance.UpdateUsedPort();
            //Helper.DriverHelper.Instance.UpdateFreePort();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 2: " + portValue);
            }
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port after: "+ port);           

        }
        [Test]
        public void GetPort2()
        {
            Console.WriteLine("Thread ID in test: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            Helper.DriverHelper.Instance.GetPortToUse();
            Helper.DriverHelper.Instance.UpdatePort();
            //Helper.DriverHelper.Instance.UpdateUsedPort();
            //Helper.DriverHelper.Instance.UpdateFreePort();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 1: " + portValue);
            }
            Helper.DriverHelper.Instance.GetPortToUse();
            Helper.DriverHelper.Instance.UpdatePort();
            //Helper.DriverHelper.Instance.UpdateUsedPort();
            //Helper.DriverHelper.Instance.UpdateFreePort();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 2: " + portValue);
            }
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port after: " + port);
        }
        [Test]
        public void GetPort3 ()
        {
            Console.WriteLine("Thread ID in test: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            Helper.DriverHelper.Instance.GetPortToUse();
            Helper.DriverHelper.Instance.UpdatePort();
            //Helper.DriverHelper.Instance.UpdateUsedPort();
            //Helper.DriverHelper.Instance.UpdateFreePort();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 1: " + portValue);
            }
            Helper.DriverHelper.Instance.GetPortToUse();
            Helper.DriverHelper.Instance.UpdatePort();
            //Helper.DriverHelper.Instance.UpdateUsedPort();
            //Helper.DriverHelper.Instance.UpdateFreePort();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 2: " + portValue);
            }
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port after: " + port);

        }
        [Test]
        public void GetPort4 ()
        {
            Console.WriteLine("Thread ID in test: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            Helper.DriverHelper.Instance.GetPortToUse();
            Helper.DriverHelper.Instance.UpdatePort();
            //Helper.DriverHelper.Instance.UpdateUsedPort();
            //Helper.DriverHelper.Instance.UpdateFreePort();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 1: " + portValue);
            }
            Helper.DriverHelper.Instance.GetPortToUse();
            Helper.DriverHelper.Instance.UpdatePort();
            //Helper.DriverHelper.Instance.UpdateUsedPort();
            //Helper.DriverHelper.Instance.UpdateFreePort();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                Console.WriteLine("Get port value in test id: " + port.Key);
                foreach (int portValue in port.Value)
                    Console.WriteLine("Check get port in 2: " + portValue);
            }
            foreach (int port in Drivers.FreePort)
                Console.WriteLine("Free port after: " + port);
        }     
    }      
}
