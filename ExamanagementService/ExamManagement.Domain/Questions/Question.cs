using ExamManagement.Domain.Core.Primitive;
using ExamManagement.Domain.QuestionTypes;

namespace ExamManagement.Domain.Exam
{
    public class Question : Entity<Guid>
    {
        public Guid Id { get; private set; }
        public Guid ExamId { get; private set; }
        public string Content { get; private set; }
        public QuestionType Type { get; private set; }
        public int Score { get; private set; }
        
    }

}