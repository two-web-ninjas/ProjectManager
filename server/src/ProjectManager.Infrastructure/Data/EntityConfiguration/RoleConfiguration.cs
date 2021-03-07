using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Infrastructure.Data.EntityConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.Property(r => r.Id)
                .ValueGeneratedNever();
            builder.Property(r => r.Name)
                .IsRequired();
        }
    }
}
