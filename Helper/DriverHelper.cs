using AutomationFrameWork.Driver.Core;
using AutomationFrameWork.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace AutomationFrameWork.Helper
{
    public class DriverHelper
    {
        private static readonly DriverHelper instance = new DriverHelper();
        public static List<int> UsedPort = new List<int>();
        static readonly object syncRoot = new Object();
        static DriverHelper ()
        {
        }
        public static DriverHelper Instance
        {
            get
            {
                return instance;
            }
        }
        /// <summary>
        /// This method use for set driver path
        /// Ex: chromedriver.exe,IEDriverServer.exe
        /// </summary>
        /// <returns></returns>
        public string DriverPath
        {
            get
            {
                return Utilities.Instance.GetRelativePath("Base//Driver//Resources");
            }
        }
        /// <summary>
        /// This method is use for
        /// get all avaliable port in local system
        /// </summary>
        /// <param name="startingPort"></param>
        /// <returns></returns>
        public Dictionary<int,Boolean> GetAvailablePort (int startingPort,int endPort)
        {           
            IPEndPoint[] endPoints;
            List<int> portArray = new List<int>();
            Dictionary<int,Boolean> returnPort = new Dictionary<int, bool>();
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
            //Add user port to list            
            portArray.AddRange(UsedPort);
            portArray.Sort();
            // Check for get Free Port 
            for (int i = startingPort; i <= endPort; i++)
                if (!portArray.Contains(i) && !UsedPort.Contains(i))
                {
                    if (!UsedPort.Contains(i))
                        returnPort.Add(i, true);
                    else
                        returnPort.Add(i, false);
                }
            return returnPort;
        }
        public List<int> GetPort ()
        {
            if (Helper.DriverHelper.UsedPort.Count == 0 || Helper.DriverHelper.UsedPort == null)
                Console.WriteLine("User port is null free port full in before Get port to use");
            else
                foreach (int port in Helper.DriverHelper.UsedPort)
                {
                    Console.WriteLine("Used port  before get port to use: " + port);
                }
            foreach (KeyValuePair<int, Boolean> port in Drivers.FreePort)
                Console.WriteLine("Free port before get port: "+port.Key + "--" + port.Value);
            List<int> returnPort = new List<int>();
            Console.WriteLine(Drivers.FreePort.Count);
            int count = 0;
            for (int n = 0; n < Drivers.FreePort.Count; n++)
            {
                if (Drivers.FreePort.ElementAt(n).Value == true && count < 3)
                {
                    returnPort.Add(Drivers.FreePort.ElementAt(n).Key);
                    UsedPort.Add(Drivers.FreePort.ElementAt(n).Key);
                    Drivers.FreePort[Drivers.FreePort.ElementAt(n).Key] = false;
                    count = count + 1;
                }
            }
            return returnPort;
        }

        public void ReleasePort(List<int> portRelease)
        {
            foreach (int port in UsedPort)
                Console.WriteLine("Use port before release: " + port);
            for (int n = 0; n < portRelease.Count; n++)
            {
                UsedPort.Remove(portRelease.ElementAt(n));
                Drivers.FreePort[portRelease.ElementAt(n)] = true;
            }
            foreach (int port in UsedPort)
                Console.WriteLine("Use port after release: " + port);
        }   
    }
}
