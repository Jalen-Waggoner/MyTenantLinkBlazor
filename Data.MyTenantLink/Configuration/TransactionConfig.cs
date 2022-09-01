using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTenantLink.Models;

namespace MyTenantLink.Data.Configuration
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> entity)
        {
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired()
                .HasDefaultValue(0);

            entity.Property(e => e.Balance)
                .HasColumnType("decimal(18,2)")
                .IsRequired()
                .HasDefaultValue(0);

            entity.Property(e => e.Description)
                .HasMaxLength(50);
        }
    }
}
