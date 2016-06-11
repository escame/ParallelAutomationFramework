namespace AutomationFrameWork.Driver.Interface
{
    public interface IDrivers<DriverType,Services, Options>
    {
        DriverType Drivers(Services driverServices = default(Services), Options desiredCapabilities = default(Options), int commandTimeOut = 60);
        Services DriverServices { get; }
        Options DesiredCapabilities { get; }
    }
}
