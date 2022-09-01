using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyTenantLink.Data.Configuration {
  public class RoleClaimConfig : IEntityTypeConfiguration<IdentityRoleClaim<string>> {
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder) {
      builder.ToTable("RoleClaim", "dbo");
      builder.Property(e => e.Id).HasColumnName("RoleClaimId");
      builder.Property(e => e.RoleId).HasColumnName("RoleId");
    }
  }
}
