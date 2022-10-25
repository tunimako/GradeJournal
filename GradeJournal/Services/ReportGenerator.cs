using GradeJournal.Models;
using GradeJournal.Repositories;
using System;
using System.Collections.Generic;

namespace GradeJournal.Services
{
    public class ReportGenerator
    {
        StudentRepository StudentData;
        TrimesterRepository TrimesterData;
        public List<ReportItem> Report { get; }
        public ReportGenerator ()
        {
            StudentRepository studentRepository = new();
            TrimesterRepository trimesterRepository = new();

            StudentData = studentRepository;
            TrimesterData = trimesterRepository;
            Report = new();

            foreach (var trimester in TrimesterData.Retrive())
            {
                Report.Add(new ReportItem(trimester.TrimesterNumber,
                                          trimester.ListOfModules, 
                                          StudentNames(StudentData.Retrive()),
                                          ListOfModulesWithGrades(trimester.ListOfModules)));
            }
        }
        private List<int> StudentGradesDependingOnModule(string studentName, string module)
        {
            GradeRepository gradeRepository = new();
            Random randomValue = new Random();
            int gradeLevelDeterminanation = randomValue.Next(1, 4);

            if (StudentData.ListOfModulesStudentIsGoodAt(studentName).Contains(module) || gradeLevelDeterminanation == 3)
            {
                return gradeRepository.HighGrades;
            }
            else if (gradeLevelDeterminanation == 2)
            {
                return gradeRepository.MediumGrades;
            }
            else if (gradeLevelDeterminanation == 1)
            {
               return gradeRepository.LowGrades;
            }

            return null;
        }
        private List<ModuleGrades> ListOfModulesWithGrades(List<string> listOfModules)
        {
            List<ModuleGrades> moduleGrades = new();

            foreach (var module in listOfModules)
            {
                foreach (var student in StudentData.Retrive())
                {
                    moduleGrades.Add(new ModuleGrades(student.StudentFullName,
                                                      module,
                                                      StudentGradesDependingOnModule(student.StudentFullName, module)));
                }
            }

            return moduleGrades;
        }
        private List<string> StudentNames(List<Student> students)
        {
            List<string> studentNames = new();

            foreach (var student in students)
            {
                studentNames.Add(student.StudentFullName);
            }

            return studentNames;
        }
        public List<ReportItem> Retrive()
        {     
            return Report;
        }
    }
}