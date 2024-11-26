

using ExamManagement.Domain.Core.Event;

namespace ExamManagement.Domain.ExamSessions
{
    public class ExamSessionStartedEvent : DomainEvent<ExamSessionData>
    {
        public ExamSessionStartedEvent(ExamSession entity) : base(entity.Id, new ExamSessionData
        {
            CandidateId = entity.CandidateId,
            ExamId = entity.ExamId
        })
        {
        }
    }

}