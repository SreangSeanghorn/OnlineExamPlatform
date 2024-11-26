using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamManagement.Domain.Exam;
using Microsoft.EntityFrameworkCore;

namespace ExamManagement.Infrastructure.Persistence.Configurations
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(500).HasColumnName("description");
            builder.Property(e => e.CreatedDate).HasDefaultValueSql("getdate()").HasColumnName("created_date");
            builder.Property(e => e.StartDate).HasColumnName("start_date");
            builder.Property(e => e.EndDate).HasColumnName("end_date");
            builder.Property(e => e.Duration).HasColumnName("duration");
            builder.Property(e => e.ExamStatus).HasColumnName("exam_status");
            builder.Property(e => e.TotalScore).HasColumnName("total_score");
            builder.HasMany(e => e.Questions).WithOne().HasForeignKey(q => q.ExamId);

        }
    }
}