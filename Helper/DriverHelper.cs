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
        public List<int> GetAvailablePort (int startingPort)
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

            for (int i = startingPort; i < UInt16.MaxValue; i++)
                if (!portArray.Contains(i))
                    returnPort.Add(i);

            return returnPort;
        }
        /// <summary>
        /// This method is use for 
        /// get avalibale port to run appium
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, List<int>> GetPortToUse ()
        {
            if (Drivers.UsedPort != null)
                UpdatePort();            
            Dictionary<int, List<int>> _returnPort = new Dictionary<int, List<int>>()
            {
                {
                  System.Threading.Thread.CurrentThread.ManagedThreadId, Drivers.FreePort.GetRange(0, 3).ToList()
                },
            };          
            Drivers.PortStorage = _returnPort;
            //UpdateUsedPort();
            //UpdateFreePort();
            //UpdatePort();
            return _returnPort;

        }
        /// <summary>
        /// This method is use for
        /// update list of used port when running appium in paralell
        /// </summary>
        private void UpdateUsedPort ()
        {
            try
            {
                if (Drivers.UsedPort == null)
                    Drivers.UsedPort = new Dictionary<int, List<int>>();
                Drivers.UsedPort.Add(System.Threading.Thread.CurrentThread.ManagedThreadId, Drivers.FreePort.GetRange(0, 3).ToList());
            }
            catch (System.ArgumentException e)
            {
                System.Console.WriteLine("Catch " + e.Message + " for thread " + System.Threading.Thread.CurrentThread.ManagedThreadId);
                Drivers.UsedPort[System.Threading.Thread.CurrentThread.ManagedThreadId].AddRange(Drivers.FreePort.GetRange(0, 3).ToList());
            }
        }
        /// <summary>
        /// This method is use for
        /// Update list of free port can use for run appium
        /// </summary>
        private void UpdateFreePort ()
        {            
            foreach (KeyValuePair<int, List<int>> port in Drivers.UsedPort)
            {
                Drivers.FreePort = Drivers.FreePort.Where(item => !port.Value.Contains((item))).ToList();
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public async void UpdatePort ()
        {
            try
            {
                if (Drivers.UsedPort == null)
                    Drivers.UsedPort = new Dictionary<int, List<int>>();
                Drivers.UsedPort.Add(System.Threading.Thread.CurrentThread.ManagedThreadId, Drivers.FreePort.GetRange(0, 3).ToList());
            }
            catch (System.ArgumentException e)
            {
                System.Console.WriteLine("Catch " + e.Message + " for thread " + System.Threading.Thread.CurrentThread.ManagedThreadId);
                Drivers.UsedPort[System.Threading.Thread.CurrentThread.ManagedThreadId].AddRange(Drivers.FreePort.GetRange(0, 3).ToList());
            }
            foreach (KeyValuePair<int, List<int>> port in Drivers.UsedPort)
            { 
                Drivers.FreePort = Drivers.FreePort.Where(item => !port.Value.Contains((item))).ToList();
            }
        }
        /// <summary>
        /// This method is use for
        /// update list of free port after finsh run test in appium
        /// </summary>
        public void ReleasePort ()
        {
            UpdatePort();
            foreach (KeyValuePair<int, List<int>> port in Drivers.PortStorage)
            {
                foreach (int temp in port.Value)
                    Drivers.FreePort.Add(temp);
            }          
            Drivers.UsedPort.Remove(System.Threading.Thread.CurrentThread.ManagedThreadId);       
            UpdatePort();
        }
    }
}
