using DDMS.Domian.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Persistence.Configurations
{
    public class ProductGroupConfiguration : IEntityTypeConfiguration<ProductGroup>
    {
        public void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
           builder.ToTable("ProductGroups");
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Description)
                .HasMaxLength(500);
            builder.Property(x=>x.IsActive)
                .HasDefaultValue(true);

            builder.HasMany(x => x.Products)
                .WithOne(x=> x.ProductGroup)
                .HasForeignKey(x => x.ProductGroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
