using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameWork.Driver
{
    public interface IDrivers
    {
        object StartDriver(object driverServices,object desiredCapabilities,TimeSpan commandTimeOut);
        void CloseDriver();
    }
}
