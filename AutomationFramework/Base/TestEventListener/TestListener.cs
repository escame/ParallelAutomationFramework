using System.Text;
using NUnit.Engine;
using NUnit.Engine.Extensibility;

namespace AutomationFrameWork.Base.ReportListener
{
    
    [Extension(Path = "/NUnit/Engine/TypeExtensions/ITestEventListener")]
    public class TestListener : ITestEventListener
    {
        StringBuilder _builder = new StringBuilder();
        public void OnTestEvent (string report)
        {

            WriteText(report);

        }
        private void WriteText (string text)
        {
            _builder.AppendLine();
            _builder.Append(text);
            System.IO.File.WriteAllText(@"C:\\Test\\WriteLines.txt", _builder.ToString());
        }
        
    }
}
