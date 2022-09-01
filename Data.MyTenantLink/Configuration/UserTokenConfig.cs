using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyTenantLink.Data.Configuration {
  public class UserTokenConfig : IEntityTypeConfiguration<IdentityUserToken<string>> {
    public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder) {
      builder.ToTable("UserToken", "dbo");
      builder.Property(e => e.UserId).HasColumnName("UserId");
    }
  }
}
