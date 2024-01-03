using ReportGeneratorDemo.Entities;

namespace ReportGeneratorDemo.Interfaces
{
    public interface IReportGenerator
    {
        string GenerateReportByFormatType(FormatType formatType);
    }
}
