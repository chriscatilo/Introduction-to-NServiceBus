using BusStop.API.Models;
using System.Web.Mvc;

namespace BusStop.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISayHello _say;

        public HomeController(ISayHello say)
        {
            _say = say;
        }

        public ActionResult Index()
        {
            ViewBag.Title = _say.Hello;

            return View();
        }
    }
}
