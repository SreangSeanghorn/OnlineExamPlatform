using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamManagement.Domain.Exam;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamManagement.Infrastructure.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Content).IsRequired().HasColumnName("content");
            builder.Property(x => x.Score).IsRequired().HasDefaultValue(0).HasColumnName("score");
            builder.Property(x => x.Type).IsRequired().HasColumnName("type");
            builder.Property(x => x.ExamId).IsRequired().HasColumnName("exam_id");
        }
    }
}