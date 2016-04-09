using AutomationFrameWork.Utils;
namespace AutomationFrameWork.Helper
{
    public class DriverHelper
    {
        private static readonly DriverHelper instance = new DriverHelper();
        static DriverHelper()
        {
        }
        public static DriverHelper Instance
        {
            get
            {
                return instance;
            }
        }
        /// <summary>
        /// This method use for set driver path
        /// Ex: chromedriver.exe,IEDriverServer.exe
        /// </summary>
        /// <returns></returns>
        public string DriverPath
        {
            get
            {                
                return Utilities.Instance.GetRelativePath("Base//Driver//Resources");                
            }
        }
    }
}
