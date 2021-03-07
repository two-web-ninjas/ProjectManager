using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Infrastructure.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Ignore(u => u.UserName);
            builder.Ignore(u => u.NormalizedUserName);
            builder.Ignore(u => u.NormalizedEmail);

            builder.Property(u => u.Email)
                .IsRequired();
            builder.Property(u => u.PasswordHash)
                .IsRequired();
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(255);
            builder.HasOne(u => u.Role);
        }
    }
}
