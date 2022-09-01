using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTenantLink.Models;

namespace MyTenantLink.Data.Configuration
{
    public class BuildingConfig : IEntityTypeConfiguration<Building>
    {
    
    
        public void Configure(EntityTypeBuilder<Building> entity)
        {
            entity.Property(e => e.BuildingCode)
               .HasMaxLength(50)
               .HasDefaultValue("Test");

            entity.Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(100)
                .HasDefaultValue("Test");

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(100)
                .HasDefaultValue("Test");

            entity.Property(e => e.State)
                .IsRequired();

            entity.Property(e => e.Zip)
                .IsRequired()
                .HasMaxLength(5)
                .HasDefaultValue(00000);
        }
    }
}

