using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamManagement.Domain.Core.Primitive;

namespace ExamManagement.Domain.AnswerOptions
{
    public class AnswerOption : ValueObject
    {
        public string Text { get; private set; }
        public bool IsCorrect { get; private set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Text;
            yield return IsCorrect;
        }
    }
}