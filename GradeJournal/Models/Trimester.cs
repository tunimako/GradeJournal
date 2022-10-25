using System.Collections.Generic;

namespace GradeJournal.Models
{
    public class Trimester
    {
        public int TrimesterNumber { get; set; }
        public List<string> ListOfModules { get; set; }
        public Trimester(int trimesterNumber, List<string> listOfModules)
        {
            TrimesterNumber = trimesterNumber;
            ListOfModules = listOfModules;
        }
    }
}