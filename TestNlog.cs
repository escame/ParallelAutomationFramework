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
using System.Threading;
using System.Net.Sockets;
using AutomationFrameWork.Driver.Core;
using AutomationFrameWork.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace AutomationFrameWork
{
    
    [TestFixture("127.0.0.1",1,2,3,DriverType.EmulationiPad)]
    [TestFixture("127.0.0.1", 4, 5, 6, DriverType.Chrome)]
    [TestFixture("127.0.0.1", 7, 8, 9, DriverType.Firefox)]
    [TestFixture("127.0.0.1", 11, 12, 13, DriverType.InternetExplore)]
    [Parallelizable(ParallelScope.Self)]
    public class TestNlog
    {
        int P, BP, C;
        string add=string.Empty;
        DriverType T;
        public TestNlog (string address,int p,int bp,int c,DriverType type)
        {
            add = address;
            P = p;            
            BP = bp;
            C = c;
            T = type;
        }      
        List<int> use;
        ThreadLocal<List<int>> portstored = new ThreadLocal<List<int>>();
        [Test]
        public void node1 ()
        {
            /*
             Console.WriteLine(add + " " + P + " " + BP + " " + C);
             DriverFactory.Instance.StartDriver(T);
             Thread.Sleep(1000);
             DriverFactory.Instance.GetWebDriver.Url = add;
             Thread.Sleep(5000);
             //Console.WriteLine(DriverFactory.Instance.GetWebDriver.Title);
             DriverFactory.Instance.CloseDriver();
             */
            //NodeFactory node = new NodeFactory();
            
            List<int> temp=Helper.DriverHelper.Instance.GetPort();
            Console.WriteLine(add + " " + temp
            .ElementAt(0) + " " + temp.ElementAt(1) + " " + temp.ElementAt(2));
            NodeFactory.Instance.StrartNodeServer(add, temp.ElementAt(0), temp.ElementAt(1), temp.ElementAt(2));
            Thread.Sleep(1000);
            NodeFactory.Instance.CloseNodeServer();
            //NodeFactory.Instance.strartNode(add,P,BP,C);
            //Thread.Sleep(5000);
            //Console.WriteLine(NodeFactory.Instance.PortNumber);
            //Console.WriteLine(NodeFactory.Instance.BootstrapPort);
            //Console.WriteLine(NodeFactory.Instance.ChromeDriverPort);
            //Console.WriteLine(NodeFactory.Instance.AddressNumber);
            //NodeFactory.Instance.closeNodeServer();
            //NodeFactory.Instance.closeNodeServer();
        }
       
        /*
        [SetUp]
        public void GetPort()
        {
            use = new List<int>();
            if (Helper.DriverHelper.UsedPort.Count == 0 || Helper.DriverHelper.UsedPort == null)
                Console.WriteLine("User port is null free port full");
            else
                foreach (int port in Helper.DriverHelper.UsedPort)
                {
                    Console.WriteLine("Used port  before get port: " + port);
                }
            foreach (KeyValuePair<int, Boolean> port in Drivers.FreePort)
                Console.WriteLine("Free port set up " + port.Key + "--" + port.Value);
            use = Helper.DriverHelper.Instance.GetPort();
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
            Console.WriteLine(Drivers.FreePort.Count);
            foreach (int port in use)
                Console.WriteLine("Use " + port);              
        }
        [Test]
        public void Use2()
        {            
            Console.WriteLine(Drivers.FreePort.Count);
            foreach (int port in use)
                Console.WriteLine("Use " + port);
            
        }
        */
        
        [OneTimeSetUp]
        public void Init()
        {
            Dictionary<int, Boolean> temp = Helper.DriverHelper.Instance.GetAvailablePort(75, 92);
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
