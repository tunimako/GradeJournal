using System.Collections.Generic;

namespace GradeJournal.Models
{
    public class ModuleGrades
    {
        public string StudentName { get; set; }
        public string Module { get; set; }
        public List<int> ListOfGrades { get; set; }
        public ModuleGrades (string studentName, string module, List<int> listOfGrades)
        {
            StudentName = studentName;
            Module = module;
            ListOfGrades = listOfGrades;
        }
    }
}