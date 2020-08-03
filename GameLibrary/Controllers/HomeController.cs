using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}