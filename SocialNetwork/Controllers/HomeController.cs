using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
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