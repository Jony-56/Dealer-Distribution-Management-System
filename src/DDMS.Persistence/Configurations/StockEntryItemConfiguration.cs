using DDMS.Domian.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDMS.Persistence.Configurations;

public class StockEntryItemConfiguration : IEntityTypeConfiguration<StockEntryItem>
{
    public void Configure(EntityTypeBuilder<StockEntryItem> builder)
    {
        builder.ToTable("StockEntryItems");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CartonQty)
            .IsRequired();

        builder.Property(x => x.PieceQty)
            .IsRequired();

        builder.Property(x => x.UnitPrice)
            .HasPrecision(18, 2);

        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}