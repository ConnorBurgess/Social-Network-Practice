using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SocialNetwork.Models
{
  public class SocialNetworkContextFactory : IDesignTimeDbContextFactory<SocialNetworkContext>
  {

    SocialNetworkContext IDesignTimeDbContextFactory<SocialNetworkContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<SocialNetworkContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new SocialNetworkContext(builder.Options);
    }
  }
}