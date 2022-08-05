using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ProjectName.Models
{
  public class
  ProjectNameContextFactory
  : IDesignTimeDbContextFactory<ProjectNameContext>
  {
    ProjectNameContext
    IDesignTimeDbContextFactory<ProjectNameContext>.CreateDbContext(
        string[] args
    )
    {
      IConfigurationRoot configuration =
          new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

      var builder = new DbContextOptionsBuilder<ProjectNameContext>();

      builder
          .UseMySql(configuration["ConnectionStrings:DefaultConnection"],
          ServerVersion
              .AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new ProjectNameContext(builder.Options);
    }
  }
}
