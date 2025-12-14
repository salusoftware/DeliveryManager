using DeliveryManager.Domain.Residents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryManager.Infrastructure.Mappings;

public class ResidentMap : IEntityTypeConfiguration<Resident>
{
    public void Configure(EntityTypeBuilder<Resident> builder)
    {
        builder.ToTable("residents");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnName("id");
        
        builder.Property(r => r.Name)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("name");
        
        builder.Property(r => r.Surname)
            .HasColumnName("surname")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.OwnsOne(x => x.Address, address =>
        {
            address.Property(a => a.Street)
                .HasMaxLength(255)
                .IsRequired()
                .HasColumnName("address_street");
            
            address.Property(a => a.City)
                .HasMaxLength(255)
                .IsRequired()
                .HasColumnName("address_city");
            
            address.Property(a => a.ZipCode)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("address_zipcode");
            
            address.Property(a => a.State)
                .HasMaxLength(2)
                .IsRequired()
                .HasColumnName("address_state");

            address.Property(a => a.Number)
                .IsRequired()
                .HasColumnName("address_number");
        });
        
    }
}