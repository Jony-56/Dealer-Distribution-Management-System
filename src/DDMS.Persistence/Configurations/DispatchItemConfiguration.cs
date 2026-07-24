using DDMS.Domian.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDMS.Persistence.Configurations;

public class DispatchItemConfiguration : IEntityTypeConfiguration<DispatchItem>
{
    public void Configure(EntityTypeBuilder<DispatchItem> builder)
    {
        builder.ToTable("DispatchItems");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CartonQty)
               .IsRequired();

        builder.Property(x => x.PieceQty)
               .IsRequired();

        builder.HasOne(x => x.Product)
               .WithMany()
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}