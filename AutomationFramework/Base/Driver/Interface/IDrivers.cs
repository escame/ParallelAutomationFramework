namespace AutomationFrameWork.Driver.Interface
{
    public interface IDrivers<Driver,Services, Options>
    {
        Driver Drivers(Services driverServices = default(Services), Options desiredCapabilities = default(Options), int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false);
        Services DriverServices { get; }
        Options DesiredCapabilities { get; }
    }
}
