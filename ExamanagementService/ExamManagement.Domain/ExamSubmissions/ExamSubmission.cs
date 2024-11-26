using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamManagement.Domain.Core.Primitive;
using ExamManagement.Domain.ExamSessions;

namespace ExamManagement.Domain.ExamSubmissions
{
    public class ExamSubmission : Entity<Guid>
    {
        public Guid ExamId { get; private set; }
        public Guid ParticipantId { get; private set; }
        public DateTime SubmissionTime { get; private set; }
        public List<SubmittedAnswer> Answers { get; private set; }
    }
}