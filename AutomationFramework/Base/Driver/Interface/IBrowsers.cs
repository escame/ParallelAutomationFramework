using OpenQA.Selenium;
using System;

namespace AutomationFrameWork.Driver.Interface
{

    public interface IBrowsers<Drivers, Services, Options> : IDriver<Drivers>, IDriverOptions<Options>, IDriverServices<Services>    
    {
        void StartDriver(Services driverServices = default(Services), Options desiredCapabilities = default(Options), int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false);          
    } 
}
