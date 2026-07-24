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
    public class ProductPriceHistoryConfiguration : IEntityTypeConfiguration<ProductPriceHistory>
    {
        public void Configure(EntityTypeBuilder<ProductPriceHistory> builder)
        {
            builder.ToTable("ProductPricesHistories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.OldPrice)
                .HasPrecision(18, 2);

            builder.Property(x => x.NewPrice)
                .HasPrecision(18, 2);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.productPriceHistories)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
