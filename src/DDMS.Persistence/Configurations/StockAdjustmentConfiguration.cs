using DDMS.Domian.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDMS.Persistence.Configurations;

public class StockAdjustmentConfiguration : IEntityTypeConfiguration<StockAdjustment>
{
    public void Configure(EntityTypeBuilder<StockAdjustment> builder)
    {
        builder.ToTable("StockAdjustments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CartonAdjustment)
               .IsRequired();

        builder.Property(x => x.PieceAdjustment)
               .IsRequired();

        builder.Property(x => x.Reason)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(x => x.AdjustmentDate)
               .IsRequired();

        builder.HasOne(x => x.Product)
               .WithMany()
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}