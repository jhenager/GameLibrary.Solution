using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Models
{
  public class GameLibraryContext : Context
  {
    public virtual DbSet<Genre> Genres { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<GameGenre> GameGenre { get; set; }
    public DbSet<GamePlatform> GamePlatform { get; set; }
    public GameLibraryContext(DbContextOptions options) : base(options);
  }
}