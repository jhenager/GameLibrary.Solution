using System.Collections.Generic;

namespace GameLibrary.Models
{
  public class Game
  {
    public Game()
    {
      this.Genres = new HashSet<GameGenre>();
      this.Platforms = new HashSet<GamePlatform>();
    }
    public int GameId { get; set; }
    public string GameName { get; set; }
    public string Rating { get; set; }
    public virtual ICollection<GameGenre> Genres { get; }
    public virtual ICollection<GamePlatform> Platforms { get; }
  }
}