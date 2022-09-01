using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTenantLink.Models;

namespace MyTenantLink.Data.Configuration
{
    public class UnitConfig : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> entity)
        {
            entity.Property(e => e.Rate)
                .HasColumnType("decimal(18,2)")
                .IsRequired()
                .HasDefaultValue(0);

            entity.Property(e => e.UnitCode)
                .HasMaxLength(50)
                .HasDefaultValue("Test");
        }
    }
}
