using EverestEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EverestEdu.Infrastructure.IEntityTypeConfigurations
{

    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.FullName)
                .HasMaxLength(30)
                .IsRequired();


        }
    }
}
