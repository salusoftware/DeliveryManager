using DeliveryManager.Domain.Deliveries;
using DeliveryManager.Domain.Residents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryManager.Infrastructure.Mappings;

public class DeliveryMap: IEntityTypeConfiguration<Delivery>
{
    public void Configure(EntityTypeBuilder<Delivery> builder)
    {
        builder.ToTable("deliveries");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");
        
        builder.Property(x => x.Name)
            .HasMaxLength(255)
            .IsRequired()
            .HasColumnName("name");
        
        builder.Property(x => x.Carrier)
            .HasColumnName("carrier")
            .HasMaxLength(255);
        
        builder.Property(x => x.TrackingCode)
            .HasMaxLength(255)
            .HasColumnName("tracking_code");
        
        builder.Property(x => x.KeyWord)
            .HasMaxLength(255)
            .HasColumnName("keyword");
        
        builder.Property(x => x.ResidentId)
            .HasColumnName("resident_id")
            .IsRequired();
        
        builder.HasOne<Resident>()
            .WithMany()
            .HasForeignKey(x => x.ResidentId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_resident");
    }
}