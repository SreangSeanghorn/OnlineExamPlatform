using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamManagement.Domain.Core.Repositories;
using ExamManagement.Domain.Exam;
using ExamManagement.Infrastructure.Persistence.DBContext;

namespace ExamManagement.Infrastructure.Exams
{
    public class ExamRepository : IGenericRepository<Exam>, IExamRepository
    {
        private readonly ApplicationDbContext _context;
        public ExamRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Exam entity)
        {
            await _context.Exams.AddAsync(entity);
        }

        public async Task DeleteAsync(Exam entity)
        {
            await Task.Run(() => _context.Exams.Remove(entity));
        }

        public async Task<IEnumerable<Exam>> GetAllAsync()
        {
            return await Task.Run(() => _context.Exams.AsEnumerable());
        }

        public async Task<Exam> GetByIdAsync(Guid id)
        {
            return await _context.Exams.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Exam entity)
        {
            await Task.Run(() => _context.Exams.Update(entity));
        }
    }
}