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
    public ActionResult Create(Game game, int GenreId, int PlatformId)
    {
      _db.Games.Add(game);
      // foreach(int Id in GenreIds)
      // {
        if (GenreId != 0)
        {
          _db.GameGenre.Add(new GameGenre() { GenreId = GenreId, GameId = game.GameId});
        }
      // }
      if (PlatformId != 0)
      {
        _db.GamePlatform.Add(new GamePlatform() { PlatformId = PlatformId, GameId = game.GameId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details (int id)
    {
      var thisGame = _db.Games
        .Include(game => game.Genres)
        .ThenInclude(join => join.Genre)
        .Include(game => game.Platforms)
        .ThenInclude(join => join.Platform)
        .FirstOrDefault(games => games.GameId == id);
      return View(thisGame);
    }

    public ActionResult Edit(int id)
    {
      var thisGame = _db.Games.FirstOrDefault(games => games.GameId == id);
      ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "GenreName");
      return View(thisGame);
    }

    [HttpPost]
    public ActionResult Edit(Game game, int GenreId)
    {
      if (GenreId != 0)
      {
        _db.GameGenre.Add(new GameGenre() {GenreId = GenreId, GameId = game.GameId});
      }
      _db.Entry(game).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisGame = _db.Games.FirstOrDefault(games => games.GameId == id);
      return View();
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisGame = _db.Games.FirstOrDefault(games => games.GameId == id);
      _db.Games.Remove(thisGame);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}