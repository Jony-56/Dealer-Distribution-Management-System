using DDMS.Domian.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDMS.Persistence.Configurations;

public class StockEntryConfiguration : IEntityTypeConfiguration<StockEntry>
{
    public void Configure(EntityTypeBuilder<StockEntry> builder)
    {
        builder.ToTable("StockEntries");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.EntryDate)
            .IsRequired();

        builder.Property(x => x.InvoiceNo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Remarks)
            .HasMaxLength(500);

        builder.HasMany(x => x.Items)
            .WithOne(x => x.StockEntry)
            .HasForeignKey(x => x.StockEntryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}