using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyTenantLink.Data.Configuration {
  public class RoleConfig : IEntityTypeConfiguration<IdentityRole> {
    public void Configure(EntityTypeBuilder<IdentityRole> builder) {
      builder.ToTable(name: "Role", schema: "dbo");
      builder.Property(e => e.Id).HasColumnName("RoleId");
    }
  }
}
