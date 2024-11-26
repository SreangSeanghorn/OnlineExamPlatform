using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamManagement.Domain.Core.Repositories;

namespace ExamManagement.Domain.ExamSessions
{
    public interface IExamSessionRepository : IGenericRepository<ExamSession>
    {
        
    }
}