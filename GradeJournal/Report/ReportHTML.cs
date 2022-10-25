using GradeJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeJournal.Report
{
    public class ReportHTML
    {
        public string YearReport(List <ReportItem> report) =>
$@" <html>
    <style>
    table, th, td {{
    border-style: solid;
    border-collapse: collapse;
    }}
    td:hover {{background-color: #ffcccc;}}
    </style>
        <body>
            <h2>First Trimester Grades</h2>
            {TrimesterReport(1,report)}
            <h2>Second Trimester Grades</h2>
            {TrimesterReport(2,report)}
            <h2>Third Trimester Grades</h2>
            {TrimesterReport(3,report)}
            <h2>Annual Grades</h2>
            {AnnualReport(report)}
        </body>
    </html>";
        private string TrimesterReport(int trimesterNumber, List<ReportItem> report)
        {
            string trimesterReport = "";

            foreach (var trimesterData in report)
            {
                if (trimesterData.TrimesterNumber == trimesterNumber)
                {
                    trimesterReport += $"<table><colgroup>\r\n <col span=\"1\" style=\"background-color: #D6EEEE\">\r\n</colgroup>" +
                                       $"{ListOfStudents(trimesterData.StudentFullNames)}" +
                                       $"{StudentAvgGradesForEachModule(trimesterData.ListOfModulesWithGrades, trimesterData.TrimesterModules)}" +
                                       $"</table>";
                }
            }

            return trimesterReport;
        }
        private string ListOfStudents(List<string> studentFullNames)
        {
            string students = "<tr style=\"background-color:#D6EEEE\"><td rowspan=\"3\"style=\"width:100px\"></td>";

            foreach (var studentFullName in studentFullNames)
            {
                students += $"<style>\r\ntd {{\r\ntext-align: center;}}</style><th colspan=\"2\"text-align: center>{studentFullName}</th>";
            }
            students += "</tr><tr></tr><tr style=\"background-color:#D6EEEE\">";
            
            for (int i = 0; i < studentFullNames.Count; i++)
            {
                students += "<th>Grades</th><th>Avg. Grade</th>";
            }
            students += "</tr>";

            return students;
        }
        private string StudentAvgGradesForEachModule(List<ModuleGrades> listOfGrades, List<string> modules)
        {
            string oneTrimesterData = "";

            for (int i = 0; i < modules.Count; i++)
            {
                oneTrimesterData += $"<tr><th style=\"width:120px\">{modules[i]}</th>";
                foreach (var moduleGrades in listOfGrades)
                {
                    if (modules[i] == moduleGrades.Module)
                    {
                        oneTrimesterData += Grades(moduleGrades.ListOfGrades);
                    }
                }
                oneTrimesterData += "</tr>";
            }

            return oneTrimesterData;
        }
        private string Grades(List<int> grades)
        {
            string listOfGrades = "";
            string gradeInfo = "";

            foreach (var grade in grades)
            {
                listOfGrades += $"{grade} ";                               
            }
            gradeInfo += $"<td style=\"width:120px\">{listOfGrades} </td>" +
                         $"<td style=\"width:80px\">{Math.Round(grades.Average(), 0, MidpointRounding.AwayFromZero)} ({Math.Round(grades.Average(), 2)})</td>";

            return gradeInfo;
        }
        private string AnnualReport(List<ReportItem> report)
        {
            string annualReport = "<table><colgroup>\r\n <col span=\"1\" style=\"background-color: #D6EEEE\">\r\n</colgroup>" + 
                                  "<tr style=\"background-color:#D6EEEE\">" +
                                  "<th>Students</th><th>First Trimester</th>" +
                                  "<th>Second Trimester</th>" +
                                  "<th>Third Trimester</th>" +
                                  "<th>Annual Grades</th></tr>";
            
            foreach (var studentData in report)
            {
                foreach (var student in studentData.StudentFullNames)
                {
                    annualReport += $"<tr><th>{student}</th>";
                    annualReport += AnnualAllTrimesterReport(student, report);
                }
                break;
            }
            annualReport += $"</table>";

            return annualReport;
        }        
        private string AnnualAllTrimesterReport(string studentFullName, List<ReportItem> report)
        {
            string annualReport = "";
            double annualGrade = 0;

            foreach (var trimesterData in report)
            {
                annualReport += AnnualSingleTrimesterReport(studentFullName,
                                                            trimesterData.ListOfModulesWithGrades,
                                                            trimesterData.TrimesterModules);
                annualGrade += AnnaualGrade(studentFullName,
                                            trimesterData.ListOfModulesWithGrades,
                                            trimesterData.TrimesterModules);

            }
            annualReport += $"<td style=\"width:120px\">{Math.Round(annualGrade / 3, 0, MidpointRounding.AwayFromZero)} ({Math.Round(annualGrade / 3, 1)})</td></tr>";

            return annualReport;
        }
        private string AnnualSingleTrimesterReport(string student, List<ModuleGrades> grades, List<string> listOfModules)
        {
            string studentTrimesterReport = "";
            double sumOfTrimesterModuleGrades = 0;

            foreach (var grade in grades)
            {
                if (student == grade.StudentName)
                {
                    sumOfTrimesterModuleGrades += Math.Round(grade.ListOfGrades.Average(), 0, MidpointRounding.AwayFromZero);
                }
            }
            studentTrimesterReport += $"<td style=\"width:120px\">{Math.Round(sumOfTrimesterModuleGrades / listOfModules.Count, 0, MidpointRounding.AwayFromZero)}</td>";

            return studentTrimesterReport;
        }
        private double AnnaualGrade(string student, List<ModuleGrades> grades, List<string> listOfModules)
        {
            double sumOfTrimesterModuleGrades = 0;

            foreach (var grade in grades)
            {
                if (student == grade.StudentName)
                {
                    sumOfTrimesterModuleGrades += Math.Round(grade.ListOfGrades.Average(), 0, MidpointRounding.AwayFromZero);
                }
            }
            double TrimesterGrade = Math.Round(sumOfTrimesterModuleGrades / listOfModules.Count, 0, MidpointRounding.AwayFromZero);

            return TrimesterGrade;
        }
    } 
}