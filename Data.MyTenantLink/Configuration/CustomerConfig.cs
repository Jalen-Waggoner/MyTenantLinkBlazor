using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTenantLink.Data;
using MyTenantLink.Models;

namespace MyTenantLink.Data.Configuration {
  public class CustomerConfig : IEntityTypeConfiguration<Customer> 
  {
    
        public void Configure(EntityTypeBuilder<Customer> entity) 
        {
            entity.Property(e => e.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();
        }
  }
}
