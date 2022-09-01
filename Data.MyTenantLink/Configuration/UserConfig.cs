using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTenantLink.Data;

namespace MyTenantLink.Data.Configuration {
  public class UserConfig : IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder) {
      builder.ToTable(name: "User", schema: "dbo");
      builder.Property(e => e.Id).HasColumnName("UserId");
      builder.Property(e => e.FirstName).HasColumnType("varchar(25)");
      builder.Property(e => e.LastName).HasColumnType("varchar(25)");
    }
  }
}
