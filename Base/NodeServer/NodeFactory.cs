using System;
using System.Diagnostics;

namespace AutomationFrameWork.Driver
{

    public class NodeFactory
    {

        int portNumber, bootstrapPort,chromeDriverPort, processID;
        string addressNumber;
        Process appiumServer;
        /// <summary>
        /// This start node server for run appium
        /// </summary>
        /// <param name="addressNumber"></param>
        /// <param name="portNumber"></param>
        /// <param name="bootstrapPort"></param>
        /// <param name="timeOut"></param>
        public NodeFactory (String addressNumber, int portNumber, int bootstrapPort,int chromeDriverPort)
        {
            this.AddressNumber = addressNumber;
            this.BootstrapPort = bootstrapPort;
            this.PortNumber = portNumber;           
            appiumServer = new Process();
            appiumServer.StartInfo.FileName = "cmd";
            appiumServer.StartInfo.Arguments = "/c node C:/Users/Minh/AppData/Roaming/npm/node_modules/appium/build/lib/main.js " + " -a " + this.AddressNumber + " -p " + this.PortNumber + " -bp " + this.BootstrapPort+ " --chromedriver-port "+this.ChromeDriverPort;
            appiumServer.StartInfo.UseShellExecute = false;
            appiumServer.StartInfo.RedirectStandardOutput = true;                      
            appiumServer.Start();
            while (!isNodeServerStart()) ;
            this.ProcessId = appiumServer.Id;
            Console.WriteLine(this.ProcessId);
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
            Console.WriteLine(appiumServer.StandardOutput.ReadLine());            
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

