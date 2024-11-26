using ExamManagement.Domain.Core.Primitive;

namespace ExamManagement.Domain.Exam
{
    public class Answer : ValueObject
    {
        public string Content { get; private set; }
        public bool IsCorrect { get; private set; }
        public Guid QuestionId { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Content;
            yield return IsCorrect;
            yield return QuestionId;
        }
    }
}