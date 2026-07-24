using DDMS.Domian.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDMS.Persistence.Configurations;

public class DailyClosingItemConfiguration : IEntityTypeConfiguration<DailyClosingItem>
{
    public void Configure(EntityTypeBuilder<DailyClosingItem> builder)
    {
        builder.ToTable("DailyClosingItems");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.SoldCarton)
               .IsRequired();

        builder.Property(x => x.SoldPiece)
               .IsRequired();

        builder.Property(x => x.ReturnCarton)
               .IsRequired();

        builder.Property(x => x.ReturnPiece)
               .IsRequired();

        builder.Property(x => x.DamageCarton)
               .IsRequired();

        builder.Property(x => x.DamagePiece)
               .IsRequired();

        builder.HasOne(x => x.Product)
               .WithMany()
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}