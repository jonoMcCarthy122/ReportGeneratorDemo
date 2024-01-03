using ReportGeneratorDemo.Entities;
using ReportGeneratorDemo.Interfaces;

namespace ReportGeneratorDemo.Services
{
    //this will be our factory class
    public sealed class ReportGenerator : IReportGenerator
    {
        private readonly IEnumerable<IReportFormatter> _reportFormatterStrategies;

        //all available formatters are injected into the constructor:)
        public ReportGenerator(IEnumerable<IReportFormatter> reportFormatterStrategies) =>
            _reportFormatterStrategies = reportFormatterStrategies;

        public string GenerateReportByFormatType(FormatType formatType)
        {
            //use pattern matching to get the correct formatter instance based off the format type
            IReportFormatter? formatter = formatType switch
            {
                FormatType.Csv => _reportFormatterStrategies.OfType<CsvReportFormatter>().FirstOrDefault(),
                FormatType.Json => _reportFormatterStrategies.OfType<JsonReportFormatter>().FirstOrDefault(),
                FormatType.Excel => _reportFormatterStrategies.OfType<ExcelReportFormatter>().FirstOrDefault(),
                FormatType.None => default,
                _ => default,
            };

            if (formatter is null)
            {
                throw new ArgumentException("No formatter found");
            }

            return formatter.FormatReport();
        }
    }
}
