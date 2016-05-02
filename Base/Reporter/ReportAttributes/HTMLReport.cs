using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.IO;

namespace AutomationFrameWork.Reporter.ReportAttributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true)]
    public class HTMLReport : Attribute, ITestAction
    {
        private static string _outputPath;
        private static string _screenshotsPath;
        private static string _attachmentsPath;

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
