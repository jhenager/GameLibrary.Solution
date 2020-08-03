namespace GameLibrary.Models
{
  public class GamePlatform
  {
    public int GamePlatformId { get; set; }
    public int PlatformId { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }
    public Platform Platform { get; set; }
  }
}