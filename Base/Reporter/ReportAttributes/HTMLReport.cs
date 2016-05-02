using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.IO;
using System.Reflection;
using AutomationFrameWork.Reporter.ReportItems;
namespace AutomationFrameWork.Reporter.ReportAttributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true)]
    public class HTMLReport : Attribute, ITestAction
    {
        private Guid _guid;
        private string _testName;
        private readonly string _projectName;
        private readonly string _className;
        private static ReportConfiguration _configuration;

        private static string _outputPath;
        private static string _screenshotsPath;
        private static string _attachmentsPath;

        private MethodInfo _methodInfo;
        private TestInformation _testInformation;
        private DateTime _start;
        private DateTime _finish;
        private string _testOutput;

        public ActionTargets Targets => ActionTargets.Test;

        public void AfterTest (ITest test)
        {
            throw new NotImplementedException();
        }

        public void BeforeTest (ITest test)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Create Folder Save Report
        /// </summary>
        private static void CreateDirectories ()
        {
            Directory.CreateDirectory(_outputPath);
            Directory.CreateDirectory(_screenshotsPath);
            Directory.CreateDirectory(_attachmentsPath);
        }
    }
}
