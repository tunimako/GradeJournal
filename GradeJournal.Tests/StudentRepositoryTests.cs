using GradeJournal.Models;
using GradeJournal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GradeJournalTests
{
    public class StudentRepositoryTests
    {
        StudentRepository studentRepository = new ();
        [Fact]
        public void RetriveStudentNamesFromStudentData_CheckIfListOfstudentsNotEmpty()
        {
            // Arrange
            List<string> listOfStudents = RetriveListOfStudentFullNames(studentRepository.Retrive());

            // Act + // Assert
            Assert.NotEmpty(listOfStudents);

        }
        [Fact]
        public void RetriveStudentNamesFromStudentData_CheckIfListOfstudentFullNamesDoesNotContainSameNames()
        {   
            // Arrange 
            List<string> listOfStudents = RetriveListOfStudentFullNames(studentRepository.Retrive());
            bool expected = true;

            // Act 
            bool actual = CheckIflistOfStudentsContainsSameNames(listOfStudents);

            // Assert
            Assert.Equal(actual, expected);
        }
        private List<string> RetriveListOfStudentFullNames(List<Student> listOfStudentsAndDisciplines)
        {
            List<string> listOfStudentNames = new();

            foreach (var student in listOfStudentsAndDisciplines)
            {
                listOfStudentNames.Add(student.StudentFullName);
            }

            return listOfStudentNames;
        }
        private bool CheckIflistOfStudentsContainsSameNames(List<string> listOfStudentNames)
        {
            bool expected = true;
            List<string> updatedListOfStudents = new();
            updatedListOfStudents = updatedListOfStudents.Concat(listOfStudentNames).ToList();

            foreach (var student in listOfStudentNames)
            {
                updatedListOfStudents.Remove(student);

                if (updatedListOfStudents.Contains(student))
                {
                    expected = false;
                    break;
                }
            }
            return expected;
        }
    }
}
