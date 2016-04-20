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

namespace AutomationFrameWork
{
    [ReportManager]
    [TestFixture]   
    [Parallelizable(ParallelScope.Self)]
    public class TestNlog 
    {
        [SetUp]
        public void GetPort ()
        {
           
            foreach (KeyValuePair<int, Boolean> port in Drivers.FreePort)
                Console.WriteLine(port.Key + "--" + port.Value);
        }
        [TearDown]
        public void GetPortAfter ()
        {
            foreach (KeyValuePair<int, Boolean> port in Drivers.FreePort)
                Console.WriteLine(port.Key + "--" + port.Value);
        }
        [Test]
        public void Use1 ()
        {
            List<int> use = new List<int>();
            Console.WriteLine(Drivers.FreePort.Count);
            int count = 0;
            for (int n = 0; n < Drivers.FreePort.Count; n++)
            {                
                if (Drivers.FreePort.ElementAt(n).Value == true&& count<3)
                {
                    use.Add(Drivers.FreePort.ElementAt(n).Key);
                    Drivers.FreePort[Drivers.FreePort.ElementAt(n).Key] = false;
                    count = count + 1;
                }
            }           
            foreach (int port in use)
                Console.WriteLine("Use "+ port);
        }
        [Test]
        public void Use2()
        {
            List<int> use = new List<int>();
            Console.WriteLine(Drivers.FreePort.Count);
            int count = 0;
            for (int n = 0; n < Drivers.FreePort.Count; n++)
            {              
                if (Drivers.FreePort.ElementAt(n).Value == true && count < 3)
                {
                    use.Add(Drivers.FreePort.ElementAt(n).Key);
                    Drivers.FreePort[Drivers.FreePort.ElementAt(n).Key] = false;
                    count = count + 1;
                }
            }
            foreach (int port in use)
                Console.WriteLine("Use " + port);
        }
        [OneTimeSetUp]
        public void Init ()
        {
            
            List<int> temp = Helper.DriverHelper.Instance.GetAvailablePort(2000, 2025);
            foreach (int port in temp)
            {
                Console.WriteLine(port);
                Drivers.FreePort = new Dictionary<int, bool>()
                {
                    { port
                    ,true},
                };
            }
            ReportManager.logger.Info("This run one time");
            ReportManager.logger.Info("Total Pass: " + TestContext.CurrentContext.Result.PassCount);
            ReportManager.logger.Info("Total Fail: " + TestContext.CurrentContext.Result.FailCount);
            ReportManager.logger.Info("Total Error: " + TestContext.CurrentContext.Result.SkipCount);
        }
        [OneTimeTearDown]
        public void Clean ()
        {
            ReportManager.logger.Info("Total Pass: "+TestContext.CurrentContext.Result.PassCount);
            ReportManager.logger.Info("Total Fail: " + TestContext.CurrentContext.Result.FailCount);
            ReportManager.logger.Info("Total Error: " + TestContext.CurrentContext.Result.SkipCount);
        }
    }    
          
}
