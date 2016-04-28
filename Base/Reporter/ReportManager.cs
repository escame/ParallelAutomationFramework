using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Common;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NLog;
using System.IO;
using System.Runtime.CompilerServices;

namespace AutomationFrameWork.Base
{
    
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class |
                   AttributeTargets.Interface | AttributeTargets.Assembly,
                   AllowMultiple = true)]
    public class ReportManager : Attribute,ITestAction
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
        public ActionTargets Targets
        {
            get
            {
                return ActionTargets.Test | ActionTargets.Suite;
            }
        }

        public void AfterTest (ITest test)
        {
            if (!test.IsSuite)
            {                
                logger.Info( test.MethodName + " is " + TestContext.CurrentContext.Result.Outcome.Status.ToString().ToUpper());
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    logger.Info(test.MethodName+ " failed " + TestContext.CurrentContext.Result.StackTrace);
                    logger.Info(TestContext.CurrentContext.Result.Message);
                }
                logger.Info("========================================================");
            }
            else
            {
                logger.Info("Passed " + TestContext.CurrentContext.Result.PassCount);
                logger.Info("Failed " + TestContext.CurrentContext.Result.FailCount);
                logger.Info("Error " + TestContext.CurrentContext.Result.SkipCount);
            }
        }

        public void BeforeTest (ITest test)
        {
            
            if (test.IsSuite)
            {
                logger.Info("Total " + test
                .TestCaseCount);
                logger.Info("Total"+ test
                .Tests);
            }
            else
            logger.Info("Start test " + test.MethodName);           
        }
        private void WriteToConsole (string eventMessage, ITest test)
        {
            logger.Info(
                "{0} {1}: {2}, from {3}.{4}.",
                eventMessage,
                test.IsSuite ? "Suite" : "Test",
                "--",
                test.Fixture != null ? test.Fixture.GetType().Name : "{no fixture}",
                test.Method != null ? test.Method.Name : "{no method}");
            logger.Info("Total Test Case: "+ test.TestCaseCount);
                
        }       
    }
}
