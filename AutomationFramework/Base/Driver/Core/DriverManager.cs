using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutomationFrameWork.Driver.Interface;
using System.Reflection;

namespace AutomationFrameWork.Driver
{
    class DriverManager<Driver,Serivces,Options>
    {
        private const string DriverCoreNamespace = "AutomationFrameWork.Driver";
        private static ThreadLocal<Driver> _driverStored;
        private static ThreadLocal<Driver> _type = new ThreadLocal<Driver>();
      
        public static Driver DriverStorage
        {
            get
            {
                return _driverStored.Value;
            }
            private set
            {
                if (_driverStored == null)
                    _driverStored = new ThreadLocal<Driver>(true);
                _driverStored.Value = value;
            }
        }
        public static void StartDrivers(DriverType driverType, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false,Serivces services = default(Serivces), Options options= default(Options))
        {
            Type foundClass = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                      .Where(item => item.Namespace == DriverCoreNamespace && item.Name.Equals(driverType.ToString(), StringComparison.OrdinalIgnoreCase)) // TODO for review: refactor code to search driver
                      .FirstOrDefault();

            if (foundClass != null)
            {
                ConstructorInfo constructor = foundClass.GetConstructor(Type.EmptyTypes);
                MethodInfo startDriver = foundClass.GetMethod("StartDriver", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod);
                DriverStorage = (Driver)startDriver.Invoke(constructor.Invoke(new object[] { }), new object[] { pageLoadTimeout, scriptTimeout, isMaximize });
            }
        }
    }   
}
