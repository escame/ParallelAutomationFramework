using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using AutomationFrameWork.Driver.Interface;

namespace AutomationFrameWork.Driver.Interface
{

    public interface IBrowsers<Drivers, Services, Options> : IDriver<Drivers>, IDriverOptions<Options>, IDriverServices<Services>    
    {
        void StartDriver(Services driverServices = default(Services), Options desiredCapabilities = default(Options), int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false);          
    }  
}
