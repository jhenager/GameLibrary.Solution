using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GameLibrary.Models
{
  public class GameLibraryContextFactory : IDesignTimeDbContextFactory<GameLibraryContext>
  {

    GameLibraryContext IDesignTimeDbContextFactory<GameLibraryContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<GameLibraryContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new GameLibraryContext(builder.Options);
    }
  }
}