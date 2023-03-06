using EverestEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EverestEdu.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class GroupEntityTypeConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(50);

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.Groups)
                .HasForeignKey(x => x.TeacherId);
        }
    }
}

