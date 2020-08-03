using System.Collections.Generic;

namespace GameLibrary.Models
{
  public class Platform
  {
    public Platform()
    {
      this.Games = new HashSet<GamePlatform>();
    }
    public int PlatformId { get; set; }
    public string PlatformName { get; set; }
    public virtual ICollection<GamePlatform> Games { get; }
  }
}