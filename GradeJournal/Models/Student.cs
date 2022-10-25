namespace GradeJournal.Models
{
    public class Student
    {
        public string StudentFullName { get; set; }
        public string Discipline { get; set; } 
        public Student(string studentFullName, string discipline)
        {
            StudentFullName = studentFullName;
            Discipline = discipline;
        }
    }
}