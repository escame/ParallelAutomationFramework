namespace AutomationFrameWork.Driver.Interface
{
    public interface IDrivers<Drivers>
    {
        void StartDriver(DriverConfiguration configuration);
        Drivers Driver { get; set; }
        object DriverServices { get; }
        object DesiredCapabilities { get; }
    }    
}
