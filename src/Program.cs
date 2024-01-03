using ReportGeneratorDemo.Entities;
using ReportGeneratorDemo.Interfaces;
using ReportGeneratorDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register all services
builder.Services.AddScoped<IReportFormatter, JsonReportFormatter>();
builder.Services.AddScoped<IReportFormatter, ExcelReportFormatter>();
builder.Services.AddScoped<IReportFormatter, CsvReportFormatter>();
builder.Services.AddScoped<IReportGenerator, ReportGenerator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//use  minimal api endpoints for the demo and inject in the report generator
app.MapGet("/report/json", (IReportGenerator reportGenerator) =>
{
    return reportGenerator?.GenerateReportByFormatType(FormatType.Json);
})
.WithName("Get Json Report")
.WithOpenApi();

app.MapGet("/report/excel", (IReportGenerator reportGenerator) =>
{
    return reportGenerator?.GenerateReportByFormatType(FormatType.Excel);
})
.WithName("Get Excel Report")
.WithOpenApi();

app.MapGet("/report/csv", (IReportGenerator reportGenerator) =>
{
    return reportGenerator?.GenerateReportByFormatType(FormatType.Csv);
})
.WithName("Get Csv Report")
.WithOpenApi();

app.Run();