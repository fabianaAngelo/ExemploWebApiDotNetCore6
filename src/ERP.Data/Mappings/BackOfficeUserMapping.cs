using ERP.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Data.Mappings
{
    public class BackOfficeUserMapping : IEntityTypeConfiguration<BackOfficeUser>
    {
        public void Configure(EntityTypeBuilder<BackOfficeUser> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasOne(f => f.User)
                .WithOne();

            builder.Property(d => d.CreateAt)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.Property(c => c.IsDeleted)
                .HasDefaultValue(false)
                .IsRequired()
                .HasColumnType("bit");

            builder.ToTable("BackOfficeUsers");

        }
    }
}
