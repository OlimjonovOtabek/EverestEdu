using EverestEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EverestEdu.Infrastructure.EntityTypeConfigurations
{
    public class LessonEntityTypeConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(x => x.Group)
                .WithMany(x => x.Lessons)
                .HasForeignKey(x => x.GroupId);
        }
    }
}
