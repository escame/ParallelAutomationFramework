namespace AutomationFrameWork.Driver.Interface
{
    public interface IFactory<Type, Driver, Services, Options>

    {
        Driver GetDriver(Type type,Services driverServices = default(Services), Options desiredCapabilities = default(Options), int commandTimeOut = 60, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false);
    }  
}
