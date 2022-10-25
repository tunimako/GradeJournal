using System;
using System.Collections.Generic;
using System.IO;

namespace GradeJournal.Repositories
{
    public class GradeRepository
    {
        public List<int> LowGrades { get; }
        public List<int> MediumGrades { get; }
        public List<int> HighGrades { get; }
        public GradeRepository()
        {
            string lowGradeData = @"D:\CodeAcademy_(.NET)\Pakaitų užduotys\GradeJournal\GradeJournal\InputData\LowGrades.txt";
            string mediumGradeData = @"D:\CodeAcademy_(.NET)\Pakaitų užduotys\GradeJournal\GradeJournal\InputData\MediumGrades.txt";
            string highGradeData = @"D:\CodeAcademy_(.NET)\Pakaitų užduotys\GradeJournal\GradeJournal\InputData\HighGrades.txt";

            //Probabilities to recive the grade: 1 - 1%; 2 - 1%; 3 - 1%; 4 - 1%; 5 - 3%; 6 - 5%; 7 - 7%; 8 - 15%; 9 - 40%; 10 - 26%;
            LowGrades = LowGradeListGenerator(lowGradeData);
            
            //Probabilities to recive the grade: 1 - 1%; 2 - 1%; 3 - 3%; 4 - 4%; 5 - 6%; 6 - 15%; 7 - 30%; 8 - 25%; 9 - 10%; 10 - 5%; 
            MediumGrades = MediumGradeListGenerator(mediumGradeData);
            
            //Probabilities to recive the grade: 1 - 1%; 2 - 3%; 3 - 8%; 4 - 15%; 5 - 30%; 6 - 25%; 7 - 10%; 8 - 5%; 9 - 2%; 10 - 1%; 
            HighGrades = HighGradeListGenerator(highGradeData);           
        }
        private List<int> LowGradeListGenerator(string pathOfLowGradeData)
        {
            Random rnd = new Random();
            List<int> listOfGrades = new();
            int[] grades = Array.ConvertAll(File.ReadAllLines(pathOfLowGradeData), int.Parse);
            int numberOfGrades = rnd.Next(3, 7);

            for (int i = 0; i < numberOfGrades; i++)
            {
                listOfGrades.Add(grades[rnd.Next(100)]);
            }

            return listOfGrades;
        }
        private List<int> MediumGradeListGenerator(string pathOfMediumGradeData)
        {
            Random rnd = new Random();
            List<int> listOfGrades = new();
            int[] grades = Array.ConvertAll(File.ReadAllLines(pathOfMediumGradeData), int.Parse);
            int numberOfGrades = rnd.Next(3, 7);
            
            for (int i = 0; i < numberOfGrades; i++)
            {
                listOfGrades.Add(grades[rnd.Next(100)]);
            }

            return listOfGrades;
        }
        private List<int> HighGradeListGenerator(string pathOfHighGradeData)
        {
            Random rnd = new Random();
            List<int> listOfGrades = new();
            int[] grades = Array.ConvertAll(File.ReadAllLines(pathOfHighGradeData), int.Parse);
            int numberOfGrades = rnd.Next(3, 7);

            for (int i = 0; i < numberOfGrades; i++)
            {
                listOfGrades.Add(grades[rnd.Next(100)]);
            }

            return listOfGrades;
        }
    }
}