using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            char result = 'F';

            if (Students.Count <= 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            var valueOfStep = (int)Math.Ceiling(Students.Count * 0.2);

            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[valueOfStep - 1] <= averageGrade)
                result = 'A';
            else if (grades[(valueOfStep * 2) - 1] <= averageGrade)
                result = 'B';
            else if (grades[(valueOfStep * 3) - 1] <= averageGrade)
                result = 'C';
            else if (grades[(valueOfStep * 4) - 1] <= averageGrade)
                result = 'D';

            return result;
        }
    }
}
