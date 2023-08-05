using Domain.Entities;
using Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
  public class ApiContext : DbContext
  {
    private readonly string connection = "Server=localhost;Database=master;User Id=root;Password=123456;Trusted_Connection=True;";

    public ApiContext()
    {

    }

    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Builder> Builders { get; set; }
    public virtual DbSet<Contribution> Contributions { get; set; }
    public virtual DbSet<Enterprise> Enterprises { get; set; }
    public virtual DbSet<Investor> Investors { get; set; }
    public virtual DbSet<Revenue> Revenues { get; set; }
    public virtual DbSet<Wallet> Wallets { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfiguration(new UserMap());
      builder.ApplyConfiguration(new BuilderMap());
      builder.ApplyConfiguration(new ContributionMap());
      builder.ApplyConfiguration(new EnterpriseMap());
      builder.ApplyConfiguration(new InvestorMap());
      builder.ApplyConfiguration(new RevenueMap());
      builder.ApplyConfiguration(new WalletMap());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
        => builder.UseSqlServer(connection);
  }
}
