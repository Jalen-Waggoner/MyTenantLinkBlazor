using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTenantLink.Models;

namespace MyTenantLink.Data.Configuration
{
    public class TenantConfig : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> entity)
        {
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .HasDefaultValue("John");

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .HasDefaultValue("Smith");
        }
    }
}
