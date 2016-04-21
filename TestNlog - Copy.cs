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
using System.Net.Sockets;
using AutomationFrameWork.Base.Driver;
using OpenQA.Selenium;
using AutomationFrameWork.Driver;

namespace AutomationFrameWork
{
    [ReportManager]
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class TestNlog2
    {
        static NodeFactory node;
        static List<int> use;
        ThreadLocal<List<int>> portstored = new ThreadLocal<List<int>>();
        [SetUp]
        public void GetPort()
        {
            TestNlog2.use = new List<int>();
            if (Helper.DriverHelper.UsedPort.Count == 0 || Helper.DriverHelper.UsedPort == null)
                Console.WriteLine("User port is null free port full");
            else
                foreach (int port in Helper.DriverHelper.UsedPort)
                {
                    Console.WriteLine("Used port  before get port: " + port);
                }
            foreach (KeyValuePair<int, Boolean> port in Drivers.FreePort)
                Console.WriteLine("Free port set up " + port.Key + "--" + port.Value);
            List<int> use = Helper.DriverHelper.Instance.GetPort();
            portstored.Value = use;
            foreach (KeyValuePair<int, Boolean> port in Drivers.FreePort)
                Console.WriteLine("Free port after get port in set up: "+port.Key + "--" + port.Value);
            node = new NodeFactory("127.0.0.1", portstored.Value.ElementAt(0), portstored.Value.ElementAt(1), portstored.Value.ElementAt(2));
        }
        [TearDown]
        public void GetPortAfter()
        {
            foreach (KeyValuePair<int, Boolean> port in Drivers.FreePort)
                Console.WriteLine(port.Key + "--" + port.Value);
            node.closeNodeServer();
            Helper.DriverHelper.Instance.ReleasePort(portstored.Value);            
            Console.WriteLine("=======================================");
            foreach (KeyValuePair<int, Boolean> port in Drivers.FreePort)
                Console.WriteLine(port.Key + "--" + port.Value);
        }
        [Test]
        public void Use1()
        {
            Thread.Sleep(45000);
            Console.WriteLine(Drivers.FreePort.Count);
            foreach (int port in TestNlog2.use)
                Console.WriteLine("Use " + port);              
        }
        [Test]
        public void Use2()
        {
            
            Console.WriteLine(Drivers.FreePort.Count);
            foreach (int port in TestNlog2.use)
                Console.WriteLine("Use " + port);
            Thread.Sleep(30000);
        }
        [OneTimeSetUp]
        public void Init()
        {
            Dictionary<int, Boolean> temp = Helper.DriverHelper.Instance.GetAvailablePort(79, 89);
            foreach (KeyValuePair<int, Boolean> port in temp)
            {
                Console.WriteLine(port);
                Drivers.FreePort = new Dictionary<int, bool>()
                {
                    { port.Key
                    ,port.Value},
                };
            }
            ReportManager.logger.Info("This run one time");
            ReportManager.logger.Info("Total Pass: " + TestContext.CurrentContext.Result.PassCount);
            ReportManager.logger.Info("Total Fail: " + TestContext.CurrentContext.Result.FailCount);
            ReportManager.logger.Info("Total Error: " + TestContext.CurrentContext.Result.SkipCount);
        }
        [OneTimeTearDown]
        public void Clean()
        {
            Console.WriteLine("=======================================");
            foreach (KeyValuePair<int, Boolean> port in Drivers.FreePort)
                ReportManager.logger.Info("check onetime teardown: "+port.Key + "--" + port.Value);
            ReportManager.logger.Info("Total Pass: " + TestContext.CurrentContext.Result.PassCount);
            ReportManager.logger.Info("Total Fail: " + TestContext.CurrentContext.Result.FailCount);
            ReportManager.logger.Info("Total Error: " + TestContext.CurrentContext.Result.SkipCount);
        }       
    }

}
