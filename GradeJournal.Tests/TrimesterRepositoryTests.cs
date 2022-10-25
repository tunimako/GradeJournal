using System.Collections.Generic;
using Xunit;
using GradeJournal.Repositories;
using System.Linq;
using GradeJournal.Models;

namespace TrimesterRepositoryTests
{
    public class GradeJournalTests
    {
        TrimesterRepository trimester = new();

        [Fact]
        public void RetriveModulesFromTrimester_CheckIfAllTrimesterModulesAreValid()
        {
            // Arrange
            List<string> expectedModules = new List<string> {"History", "Music", "Arts", "English", 
                                                             "Theater", "Biology", "Chemestry", 
                                                             "Physics","Mathematics", "Computer Sience"};

            // Act 
            List<string> actualModules = ListOfActualModules(trimester.Retrive());

            // Assert
            foreach (var actualModule in actualModules)
            {
                Assert.Contains(actualModule, expectedModules);
            }
        }
        private List<string> ListOfActualModules(List<Trimester> trimesterData)
        {
            List<string> actualModules = new List<string>();
            foreach (var modules in trimesterData)
            {
               actualModules = actualModules.Concat(modules.ListOfModules).ToList();
            }
            return actualModules;
        }
    }
}
