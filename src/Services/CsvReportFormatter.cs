using ReportGeneratorDemo.Interfaces;

namespace ReportGeneratorDemo.Services
{
    public sealed class CsvReportFormatter : IReportFormatter
    {
        public string FormatReport()
        {
            return "Report is in CSV Format";
        }
    }
}
