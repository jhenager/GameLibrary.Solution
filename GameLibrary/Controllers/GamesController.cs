using Microsoft.AspNetCore.Mvc;
using GameLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameLibrary.Controllers
{
  public class GamesController : Controller
  {
    private readonly GameLibraryContext _db;
    public GamesController(GameLibraryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Games.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "GenreName");
      ViewBag.PlatformId = new SelectList(_db.Platforms, "PlatformId", "PlatformName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Game game, int GenreId, int PlatformId, string Rating)
    {
      _db.Games.Add(game);
      if (GenreId != 0)
      {
        _db.GameGenre.Add(new GameGenre() { GenreId = GenreId, GameId = game.GameId});
      }
      if (PlatformId != 0)
      {
        _db.GamePlatform.Add(new GamePlatform() { PlatformId = PlatformId, GameId = game.GameId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}