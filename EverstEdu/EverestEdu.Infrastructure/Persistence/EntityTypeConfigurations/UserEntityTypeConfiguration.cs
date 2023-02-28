﻿using EverestEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EverestEdu.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.UserName)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(i => i.UserName)
                .IsUnique();

            //builder.HasData(new User
            //{
            //    Id = 1,
            //    UserName = "Adminn",
            //    PasswordHash = HashProvider.GetHash("12345"),


            //    Role = UserRole.Admin,
            //    FullName = "Adminbek Adminov"
            //}); ;
        }
    }
}
