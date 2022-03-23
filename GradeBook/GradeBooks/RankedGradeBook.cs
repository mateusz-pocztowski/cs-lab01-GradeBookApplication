using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            int lowerScoreStudents = 0;
            for (int i = 0; i < Students.Count; i++)
            {
                if (averageGrade > Students[i].AverageGrade)
                {
                    lowerScoreStudents++;
                }
            }

            double twentyPercent = Students.Count / 5.0;

            if (lowerScoreStudents >= twentyPercent * 4)
                return 'A';
            else if (lowerScoreStudents >= twentyPercent * 3)
                return 'B';
            else if (lowerScoreStudents >= twentyPercent * 2)
                return 'C';
            else if (lowerScoreStudents >= twentyPercent)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine($"Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }
    }
}
