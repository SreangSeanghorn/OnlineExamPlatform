using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamManagement.Domain.Core.Primitive;
using ExamManagement.Domain.Exam;
using ExamManagement.Domain.ExamSubmissions;

namespace ExamManagement.Domain.Participants
{
    public class Participant : AggregateRoot<Guid>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public ExamSubmission ExamSubmission { get; private set; }
        
    }


}