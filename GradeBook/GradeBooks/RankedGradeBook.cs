using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            this.Type = GradeBookType.Ranked;
        }

        /// <summary>
        /// implement of average grade in ranked grade book
        /// </summary>
        /// <param name="averageGrade"></param>
        /// <returns></returns>
        public override char GetLetterGrade(double averageGrade)
        {
            if(this.Students.Count < 5)
            {
                throw new InvalidOperationException(
                    "Ranked-grading requires a minimum of 5 students to work");
            }
            int aboveInputCount = this.Students.FindAll(s => s.AverageGrade > averageGrade).Count;
            double percent = (double)aboveInputCount / this.Students.Count;
            switch (percent)
            {
                case double per when per < 0.2:
                    return 'A';
                case double per when per < 0.4:
                    return 'B';
                case double per when per < 0.6:
                    return 'C';
                case double per when per < 0.8:
                    return 'D';
                default:
                    return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if(this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
