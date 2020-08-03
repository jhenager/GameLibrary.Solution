using System.Collections.Generic;

namespace GameLibrary.Models
{
  public class Game
  {
    public Game()
    {
      this.Genres = new HashSet<GameGenre>();
    }
    public int GameId { get; set; }
    public string GameName { get; set; }
    public string Platform { get; set; }
    public string Rating { get; set; }
    public virtual ICollection<GameGenre> Genres { get; }
  }
}