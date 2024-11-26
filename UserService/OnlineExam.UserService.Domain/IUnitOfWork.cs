using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.UserService.Domain
{
    public interface IUnitOfWork
    {
         Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}