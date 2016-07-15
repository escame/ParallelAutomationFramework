namespace AutomationFrameWork.Driver.Interface
{
    public interface IFactory
    {
        object DesiredCapabilities { get; set; }
        object DriverServices { get; set; }
        int CommandTimeout { get; set; }
        int PageLoadTimeout { get; set; }
        int ScriptTimeout { get; set; }
        bool MaximizeBrowser { get; set; }
        Browser BrowserType { get; set; }
        Driver GetDriver<Driver>();     
    }  
}
