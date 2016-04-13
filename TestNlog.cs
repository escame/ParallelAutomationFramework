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
        [Test]
        public void GetPort ()
        {
            List<int> temp=GetAvailablePort(10);
            foreach (int port in temp)
                Console.WriteLine("Port: " + port +" is free");
           
        }
        public static List<int> GetAvailablePort (int startingPort)
        {
            IPEndPoint[] endPoints;
            List<int> portArray = new List<int>();
            List<int> returnPort=new List<int>();
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();

            //getting active connections
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            portArray.AddRange(from n in connections
                               where n.LocalEndPoint.Port >= startingPort
                               select n.LocalEndPoint.Port);

            //getting active tcp listners - WCF service listening in tcp
            endPoints = properties.GetActiveTcpListeners();
            portArray.AddRange(from n in endPoints
                               where n.Port >= startingPort
                               select n.Port);

            //getting active udp listeners
            endPoints = properties.GetActiveUdpListeners();
            portArray.AddRange(from n in endPoints
                               where n.Port >= startingPort
                               select n.Port);

            portArray.Sort();

            for (int i = startingPort; i < UInt16.MaxValue; i++)
                if (!portArray.Contains(i))
                    returnPort.Add(i);

            return returnPort;
        }
    }
   
}
