using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NLog;

namespace AutomationFrameWork
{
    class TestNlog
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        [Test]
        public void TesTNlog ()
        {
           
            for (int n = 0; n < 10; n++)
            {
                logger.Debug("This debug write to log " + n);
                logger.Info("This info write to log " + n);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
