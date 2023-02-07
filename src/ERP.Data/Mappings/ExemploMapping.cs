
using ERP.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Data.Mappings
{
    public class ExemploMapping : IEntityTypeConfiguration<Exemplo>
    {
        public void Configure(EntityTypeBuilder<Exemplo> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(256)");

            builder.Property(d => d.CreateAt)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.Property(d => d.IsActive).HasDefaultValue(true)
                .IsRequired()
                .HasColumnType("bit");

            builder.ToTable("Exemplos");
        }
    }
}
