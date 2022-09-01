using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyTenantLink.Data.Configuration {
  public class UserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<string>> {
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder) {
      builder.ToTable("UserRole", "dbo");
      builder.Property(e => e.UserId).HasColumnName("UserId");
      builder.Property(e => e.RoleId).HasColumnName("RoleId");
    }
  }
}
