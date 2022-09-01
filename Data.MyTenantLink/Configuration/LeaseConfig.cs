using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTenantLink.Models;

namespace MyTenantLink.Data.Configuration
{
    public class LeaseConfig : IEntityTypeConfiguration<Lease>
    {
        public void Configure(EntityTypeBuilder<Lease> entity)
        {
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired()
                .HasDefaultValue(0);


            entity.Property(e => e.Balance)
                .HasColumnType("decimal(18,2)")
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}
