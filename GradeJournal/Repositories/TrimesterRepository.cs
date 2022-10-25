using GradeJournal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GradeJournal.Repositories
{
    public class TrimesterRepository
    {
        public List<Trimester> Trimesters { get; }
        public TrimesterRepository()
        {
            string trimestersData = @"D:\CodeAcademy_(.NET)\Pakaitų užduotys\GradeJournal\GradeJournal\InputData\TrimesterData.txt";

            string[] trimesterList = ArrayOfTrimestersData(trimestersData);
            Trimesters = new();

            for (int i = 0; i < 3; i++)
            {
                Trimesters.Add(new Trimester(i + 1, RetriveModulesFromTrimester(trimesterList[i])));
            }
        }
        private string[] ArrayOfTrimestersData(string pathOfTrimestersData)
        {
            string[] arrayOfTrimesters = File.ReadAllLines(pathOfTrimestersData);
            string textIndicatingValidInformation = "--------(All information from this line will be used in the code)--------";

            foreach (string line in arrayOfTrimesters)
            {
                arrayOfTrimesters = arrayOfTrimesters.Where((source, value) => value != 0).ToArray();

                if (line == textIndicatingValidInformation)
                {
                    break;
                }
            }

            return arrayOfTrimesters;
        }
        private List<string> RetriveModulesFromTrimester(string arrayOfTrimesters)
        {
            List<string> listOfModules = new();
            string[] posibleSeparators = { ":", "-", ",", "_"}; //List of posible separators
            string[] ArrayOfModules = arrayOfTrimesters.Split(posibleSeparators, StringSplitOptions.None);

            for (int i = 0; i < ArrayOfModules.Length; i++)
            {
                listOfModules.Add(ArrayOfModules[i].Trim());
            }
            listOfModules.RemoveAt(0);

            return listOfModules;
        }
        public List<Trimester> Retrive()
        {
            return Trimesters;
        }
    }
}