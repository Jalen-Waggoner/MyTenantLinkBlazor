using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyTenantLink.Data.Configuration;
using MyTenantLink.Models;

namespace MyTenantLink.Data;

public class AppDbContext : IdentityDbContext<User> 
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=radquest.database.windows.net;Initial Catalog=MyTenantLink;Integrated Security=False;User ID=radSA;Password=R@dh0st1;Connect Timeout=15;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }


    public DbSet<Building>? Building { get; set; }
    public DbSet<Customer>? Customer { get; set; }
    public DbSet<Lease>? Lease { get; set; }
    public DbSet<Tenant>? Tenant { get; set; }
    public DbSet<Unit>? Unit { get; set; }
    public DbSet<User>? User { get; set; }
    public DbSet<Transaction>? Transaction { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new BuildingConfig());
        builder.ApplyConfiguration(new CustomerConfig());
        builder.ApplyConfiguration(new LeaseConfig());
        builder.ApplyConfiguration(new RoleClaimConfig());
        builder.ApplyConfiguration(new RoleConfig());
        builder.ApplyConfiguration(new TenantConfig());
        builder.ApplyConfiguration(new UnitConfig());
        builder.ApplyConfiguration(new UserConfig());
        builder.ApplyConfiguration(new UserClaimConfig());
        builder.ApplyConfiguration(new UserLoginConfig());
        builder.ApplyConfiguration(new UserClaimConfig());
        builder.ApplyConfiguration(new UserRoleConfig());
        builder.ApplyConfiguration(new UserTokenConfig());
        builder.ApplyConfiguration(new TransactionConfig());
    }



}



