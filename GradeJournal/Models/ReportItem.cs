using System.Collections.Generic;

namespace GradeJournal.Models
{
    public class ReportItem
    {
        public int TrimesterNumber { get; set; }
        public List<string> TrimesterModules { get; set; }
        public List<string> StudentFullNames { get; set; }
        public List<ModuleGrades> ListOfModulesWithGrades { get; set; }
        public ReportItem (int trimesterNumber, List<string> trimesterModules, List<string> studentFullNames, List<ModuleGrades> listOfModulesWithGrades)
        {
            TrimesterNumber = trimesterNumber;
            TrimesterModules = trimesterModules;
            StudentFullNames = studentFullNames;
            ListOfModulesWithGrades = listOfModulesWithGrades;
        }
    }
}