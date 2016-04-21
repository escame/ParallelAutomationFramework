using System;
using System.Diagnostics;
using System.Threading;

namespace AutomationFrameWork.Driver
{

    public class NodeFactory
    {        
        private int portNumber, bootstrapPort,chromeDriverPort, processID;
        private string addressNumber;
        private Process appiumServer;
        static NodeFactory ()
        {
        }
        public static NodeFactory Instance
        {
            get
            {
                return NodeFactory.Node.Value;
            }
        }
        static ThreadLocal<NodeFactory> Node = new ThreadLocal<NodeFactory>(() =>
        {            
            return new NodeFactory();
        });
        /// <summary>
        /// This start node server for run appium
        /// </summary>
        /// <param name="addressNumber"></param>
        /// <param name="portNumber"></param>
        /// <param name="bootstrapPort"></param>
        /// <param name="timeOut"></param>
        public void  strartNode (String addressNumber, int portNumber, int bootstrapPort,int chromeDriverPort)
        {
            this.AddressNumber = addressNumber;
            this.BootstrapPort = bootstrapPort;
            this.PortNumber = portNumber;
            this.ChromeDriverPort = chromeDriverPort;         
            appiumServer = new Process();
            appiumServer.StartInfo.FileName = "cmd";
            appiumServer.StartInfo.Arguments = "/c node C:/Users/minh/AppData/Roaming/npm/node_modules/appium/build/lib/main.js " + " -a " + this.AddressNumber + " -p " + this.PortNumber + " -bp " + this.BootstrapPort+ " --chromedriver-port "+this.ChromeDriverPort;
            appiumServer.StartInfo.UseShellExecute = true;
            appiumServer.StartInfo.RedirectStandardOutput = false;                      
            appiumServer.Start();
            //while (!isNodeServerStart()) ;
            this.ProcessId = appiumServer.Id;            
        }
        /// <summary>
        /// This set port number for appium can listen
        /// </summary>
        public int PortNumber
        {
            get
            {
                return portNumber;
            }

            private set
            {
                portNumber = value;
            }
        }
        /// <summary>
        /// This set address of Appium Server
        /// </summary>
        public string AddressNumber
        {
            get
            {
                return addressNumber;
            }

            private set
            {
                addressNumber = value;
            }
        }
        /// <summary>
        /// This set bootstrap port for node server
        /// </summary>
        public int BootstrapPort
        {
            get
            {
                return bootstrapPort;
            }

            private set
            {
                bootstrapPort = value;
            }
        }
        /// <summary>
        /// This set bootstrap port for node server
        /// </summary>
        public int ChromeDriverPort
        {
            get
            {
                return chromeDriverPort;
            }

            private set
            {
                chromeDriverPort = value;
            }
        }
        /// <summary>
        /// This method is use for
        /// get and set process id
        /// </summary>
        public int ProcessId
        {
            get
            {
                return processID;
            }

            private set
            {
                processID = value;
            }
        }
        /// <summary>
        /// This close node server with has PID 
        /// </summary>
        public void closeNodeServer ()
        {            
            Process closeNodeServer = new Process();
            closeNodeServer.StartInfo.FileName = "Taskkill";
            closeNodeServer.StartInfo.Arguments = "/PID " + this.ProcessId;
            closeNodeServer.Start();                 
        }
        /// <summary>
        /// This method is use for
        /// Check node server running or not
        /// return true if appium sever not start
        /// </summary>
        /// <returns></returns>
        private Boolean isNodeServerStart ()
        {           
            return (appiumServer == null || appiumServer.StandardOutput.ReadLine().Contains("started on"));
        }
    }
}

