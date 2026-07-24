using DDMS.Domian.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDMS.Persistence.Configurations;

public class DispatchConfiguration : IEntityTypeConfiguration<Dispatch>
{
    public void Configure(EntityTypeBuilder<Dispatch> builder)
    {
        builder.ToTable("Dispatches");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DispatchDate)
               .IsRequired();

        builder.Property(x => x.Remarks)
               .HasMaxLength(500);

        builder.Property(x => x.IsCompleted)
               .HasDefaultValue(false);

        builder.HasOne(x => x.Salesman)
               .WithMany(x => x.Dispatches)
               .HasForeignKey(x => x.SalesmanId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Items)
               .WithOne(x => x.Dispatch)
               .HasForeignKey(x => x.DispatchId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.DailyClosing)
               .WithOne(x => x.Dispatch)
               .HasForeignKey<DailyClosing>(x => x.DispatchId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}