using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(String name, bool isWeighted) : base(name, isWeighted)
        {
            this.Type = GradeBookType.Standard;
        }
    }
}
