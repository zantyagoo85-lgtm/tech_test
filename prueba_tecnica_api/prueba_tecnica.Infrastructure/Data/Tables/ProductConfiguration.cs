using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prueba_tecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_tecnica.Infrastructure.Data.Tables
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(e => e.Price)
                  .HasColumnType("decimal(18,2)");

            builder.Property(e => e.Description)
                  .HasMaxLength(500);

            builder.Property(e => e.IsActive)
                  .HasDefaultValue(true);

            builder.Property(e => e.CreatedAt)
                .IsRequired();
        }
    }
}
