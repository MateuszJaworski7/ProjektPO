using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjektPO
{
    public class FinalGrade
    {
        public int StudentId { get; set; }
        public double Value { get; set; }

        public double CalculateAverageGrade(Database database)
        {
            List<Grade> studentGrades = database.GetGrades().Where(g => g.StudentId == this.StudentId).ToList();

            if (studentGrades.Count == 0)
                return 0;

            double sum = studentGrades.Sum(g => g.Value);

            double averageGrade = sum / studentGrades.Count;

            return averageGrade;
        }
    }
}
