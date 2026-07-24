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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Description)
                .HasMaxLength(1000);
            builder.Property(x=> x.SKU)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(x => x.SKU)
                .IsUnique();

            builder.Property(x => x.SellingPrice)
                .HasPrecision(18, 2);

            builder.Property(x=> x.Barcode)
                .HasMaxLength (100);

            builder.Property(x=> x.ImageUrl)
                .HasMaxLength(500);

            builder.HasOne(x => x.Brand)
                .WithMany(x => x.products)
                .HasForeignKey(x => x.BrandId);
                

            builder.HasOne(x => x.ProductGroup)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductGroupId);


        }
    }
}
