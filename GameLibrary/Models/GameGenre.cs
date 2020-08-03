namespace GameLibrary.Models
{
  public class GameGenre
  {
    public int GameGenreId { get; set; }
    public int GenreId { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }
    public Genre Genre { get; set; }
  }
}