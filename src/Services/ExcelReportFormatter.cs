using ReportGeneratorDemo.Interfaces;

namespace ReportGeneratorDemo.Services
{
    public sealed class ExcelReportFormatter : IReportFormatter
    {
        public string FormatReport()
        {
            return "Report is in Excel Format";
        }
    }
}
