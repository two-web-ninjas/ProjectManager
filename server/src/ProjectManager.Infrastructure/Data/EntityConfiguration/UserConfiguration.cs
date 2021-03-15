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

            builder.Property(u => u.Email)
                .IsRequired();
            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(u => u.PasswordHash)
                .IsRequired();
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(60);
        }
    }
}
