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
    public class ReportManager : Attribute, ITestListener,ITestAction
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
            WriteToConsole("After in report",test);
            logger.Info("Test result "+TestContext.CurrentContext.Result.Outcome.Status);
            logger.Info("Test error " + TestContext.CurrentContext.Result.StackTrace);
            logger.Info("Test result mess " + TestContext.CurrentContext.Result.Message);
        }

        public void BeforeTest (ITest test)
        {
            WriteToConsole("Before in report", test);
            logger.Info("Start test " + test.FullName);           
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
        public void TestFinished (ITestResult result)
        {
            Console.WriteLine("MINH HOANG TEST "+result);
            System.IO.File.WriteAllText(@"D:\WriteLines"+result.ToString()+".txt", "abc");
        }

        public void TestStarted (ITest test)
        {
            Console.WriteLine("MINH HOANG TEST Start " + test.Parent); System.IO.File.WriteAllText(@"D:\WriteLines"+test.Name+".txt", "abc");
        }
    }
}
