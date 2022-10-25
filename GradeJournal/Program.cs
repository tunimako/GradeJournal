using GradeJournal.Report;
using GradeJournal.Services;
using System.IO;

namespace GradeJournal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReportGenerator reportGenerator = new ReportGenerator();
            ReportHTML reportHTML = new ReportHTML(); 

            File.WriteAllText("YearReport.html", reportHTML.YearReport(reportGenerator.Retrive()));
        }
    }
}