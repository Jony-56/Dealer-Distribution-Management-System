using DDMS.Domian.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDMS.Persistence.Configurations;

public class DailyClosingConfiguration : IEntityTypeConfiguration<DailyClosing>
{
    public void Configure(EntityTypeBuilder<DailyClosing> builder)
    {
        builder.ToTable("DailyClosings");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ClosingDate)
               .IsRequired();

        builder.Property(x => x.CollectedAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.DueAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalDamageAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Remarks)
               .HasMaxLength(500);

        builder.HasMany(x => x.Items)
               .WithOne(x => x.DailyClosing)
               .HasForeignKey(x => x.DailyClosingId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}