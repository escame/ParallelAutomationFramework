using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
namespace AutomationFrameWork.Driver.Interface
{
    public interface IDriverOptions<Options> 
    {
        Options DesiredCapabilities { get; }
    }
  
}
