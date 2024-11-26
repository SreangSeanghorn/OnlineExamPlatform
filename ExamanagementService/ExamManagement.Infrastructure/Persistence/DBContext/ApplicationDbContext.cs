using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamManagement.Domain.AnswerOptions;
using ExamManagement.Domain.Exam;
using ExamManagement.Domain.ExamSessions;
using ExamManagement.Domain.ExamSubmissions;
using ExamManagement.Domain.Participants;
using Microsoft.EntityFrameworkCore;

namespace ExamManagement.Infrastructure.Persistence.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamSession> ExamSessions { get; set; }
        public DbSet<ExamSubmission> ExamSubmissions { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<SubmittedAnswer> SubmittedAnswers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
   
}