using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamManagement.Domain.Core.Primitive;

namespace ExamManagement.Domain.QuestionTypes
{
    public enum QuestionType {
        MultipleChoice = 1,
        TrueFalse = 2,
        FillInTheBlank = 3,
        ShortAnswer = 4,
        Essay = 5
       
    }
}