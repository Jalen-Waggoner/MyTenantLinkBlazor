using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyTenantLink.Data.Configuration {
  public class UserClaimConfig : IEntityTypeConfiguration<IdentityUserClaim<string>> {
    public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder) {
      builder.ToTable("UserClaim", "dbo");
      builder.Property(e => e.UserId).HasColumnName("UserId");
      builder.Property(e => e.Id).HasColumnName("UserClaimId");

    }
  }
}
