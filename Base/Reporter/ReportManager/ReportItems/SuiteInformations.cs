using System.Collections.Generic;

namespace AutomationFrameWork.Reporter.ReportItems
{
    public class SuiteInformations
    {
        public string Name;
        public List<TestInformations> Tests;
        public List<SuiteInformations> Suites;

        public SuiteInformations (string name)
        {
            Name = name;
            Tests = new List<TestInformations>();
            Suites = new List<SuiteInformations>();
        }
    }
}
