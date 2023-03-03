using ERP.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Data.Mappings
{
    public class BackOfficeUserMapping : IEntityTypeConfiguration<BackOfficeUser>
    {
        public void Configure(EntityTypeBuilder<BackOfficeUser> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(f => f.User)
                .WithOne();

            builder.Property(c => c.IsDeleted)
                .HasDefaultValue(false)
                .IsRequired()
                .HasColumnType("bit");

            builder.ToTable("BackOfficeUsers");
        }
    }
}
