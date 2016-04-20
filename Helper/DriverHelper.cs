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
        object syncRoot = new Object();
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
        public List<int> GetAvailablePort (int startingPort,int endPort)
        {
            IPEndPoint[] endPoints;
            List<int> portArray = new List<int>();
            List<int> returnPort = new List<int>();
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

            for (int i = startingPort; i <= endPort; i++)
                if (!portArray.Contains(i))
                    returnPort.Add(i);
            return returnPort;
        }
        public List<int> GetPort ()
        {
            List<int> returnPort = new List<int>();
            Console.WriteLine(Drivers.FreePort.Count);
            int count = 0;
            for (int n = 0; n < Drivers.FreePort.Count; n++)
            {
                if (Drivers.FreePort.ElementAt(n).Value == true && count < 3)
                {
                    returnPort.Add(Drivers.FreePort.ElementAt(n).Key);
                    Drivers.FreePort[Drivers.FreePort.ElementAt(n).Key] = false;
                    count = count + 1;
                }
            }
            return returnPort;
        }        
    }
}
