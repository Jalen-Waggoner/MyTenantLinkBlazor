using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyTenantLink.Data.Configuration {
  public class UserLoginConfig : IEntityTypeConfiguration<IdentityUserLogin<string>> {
    public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder) {
      builder.ToTable("UserLogin", "dbo");
      builder.Property(e => e.UserId).HasColumnName("UserId");
    }
  }
}
