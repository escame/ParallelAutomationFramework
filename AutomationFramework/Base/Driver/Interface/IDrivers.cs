namespace AutomationFrameWork.Driver.Interface
{
    public interface IDrivers
    {
        object Drivers(object driverServices = null, object desiredCapabilities = null, int commandTimeOut = 60);
        object DriverServices { get; }
        object DesiredCapabilities { get; }
    }
}
