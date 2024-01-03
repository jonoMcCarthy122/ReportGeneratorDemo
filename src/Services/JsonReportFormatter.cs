using ReportGeneratorDemo.Interfaces;

namespace ReportGeneratorDemo.Services
{
    public sealed class JsonReportFormatter : IReportFormatter
    {
        public string FormatReport()
        {
            return "Report is in Json Format";
        }
    }
}
