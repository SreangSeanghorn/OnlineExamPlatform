using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamManagement.Domain.Core.Primitive;

namespace ExamManagement.Domain.Exam
{
    public class Exam : AggregateRoot<Guid>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int Duration { get; private set; }
        public List<Question> Questions { get; private set; }
        public Enum ExamStatus { get; private set; }
        public int TotalScore { get; private set; }

    }
}