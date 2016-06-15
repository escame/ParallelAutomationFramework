namespace AutomationFrameWork.Driver.Interface
{
    public interface IDrivers<Drivers,Services, Options>
    {
        void StartDriver(object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false);
        Drivers Driver { get; set; }
        Services DriverServices { get; }
        Options DesiredCapabilities { get; }
    }
}
