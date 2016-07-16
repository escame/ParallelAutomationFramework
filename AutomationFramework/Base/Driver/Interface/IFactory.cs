namespace AutomationFrameWork.Driver.Interface
{
    public interface IFactory
    {       
        DriverConfiguration Configuration { get; set; }
        Browser BrowserType { get; set; }
        Driver GetDriver<Driver>();     
    }  
}
