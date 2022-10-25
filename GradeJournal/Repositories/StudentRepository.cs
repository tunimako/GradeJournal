using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GradeJournal.Models;

namespace GradeJournal.Repositories
{
    public class StudentRepository
    { 
        public List<Student> ListOfStudentsWithDisciplines { get; }
        public StudentRepository()
        {
            string studentData = @"D:\CodeAcademy_(.NET)\Pakaitų užduotys\GradeJournal\GradeJournal\InputData\StudentData.txt";

            string[] studentList = ArrayOfSutudentData(studentData);
            List<string> studentNames = RetriveStudentNamesFromStudentData(studentList);
            List<string> studentDisciplines = RetriveStudentDisciplinesFromStudentData(studentList);
            ListOfStudentsWithDisciplines = new();

            for (int i = 0; i < studentList.Count(); i++)
            {
                ListOfStudentsWithDisciplines.Add(new Student(studentNames[i], studentDisciplines[i]));
            }
        }
        private string[] ArrayOfSutudentData(string pathOfStudentData)
        {
            string[] studentList = File.ReadAllLines(pathOfStudentData);
            string textIndicatingValidInformation = "--------(All information from this line will be used in the code)--------";

            foreach (string line in studentList)
            {
                studentList = studentList.Where((source, value) => value != 0).ToArray();

                if (line == textIndicatingValidInformation)
                {
                    break;
                }
            }

            return studentList;
        } 
        private List<string> RetriveStudentNamesFromStudentData(string[] studentList)
        {
            List<string> studentNames = new();
            string[] posibleSeparators = { ":", "-", ",", "_"};     //List of posible separators

            foreach (var student in studentList)
            {
                string[] studentInfo = student.Split(posibleSeparators, StringSplitOptions.None);
                studentNames.Add(studentInfo[0].Trim());
            }

            return studentNames;
        }
        private List<string> RetriveStudentDisciplinesFromStudentData(string[] studentList)
        {
            List<string> studentDisciplines = new();
            string[] posibleSeparators = { ":", "-", ",", "_"};     //List of posible separators

            foreach (var student in studentList)
            {
                string[] studentInfo = student.Split(posibleSeparators, StringSplitOptions.None);
                studentDisciplines.Add(studentInfo[1].Trim());
            }

            return studentDisciplines;
        }
        public List<string> ListOfModulesStudentIsGoodAt(string studentName)
        {
            string discipline = "";
            
            foreach(var student in ListOfStudentsWithDisciplines)
            {
                if (student.StudentFullName == studentName)
                {
                    discipline = student.Discipline;
                }
            }
            List<string> noDiscipline = new();
            List<string> humanities = new() { "History", "Music", "Art", "English", "Theater" };
            List<string> natural = new() { "Biology", "Chemestry", "Physics" };
            List<string> formal = new() { "Mathematics", "Computer Sience" };
            List<string> genius = new();

            genius = genius.Concat(humanities)
                           .Concat(natural)
                           .Concat(formal).ToList();

            switch (discipline)
            {
                case "Humanities":
                    return humanities;

                case "Natural":
                    return natural;

                case "Formal":
                    return formal;

                case "Genius":
                    return genius;

                default:
                    return noDiscipline;
            }
        }
        public List<Student> Retrive()
        {
            return ListOfStudentsWithDisciplines;
        }
    }
}