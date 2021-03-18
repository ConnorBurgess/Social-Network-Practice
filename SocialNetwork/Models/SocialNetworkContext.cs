using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Models
{
  public class SocialNetworkContext : DbContext
  {
    public DbSet<User> Users {get; set;}
    public SocialNetworkContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}