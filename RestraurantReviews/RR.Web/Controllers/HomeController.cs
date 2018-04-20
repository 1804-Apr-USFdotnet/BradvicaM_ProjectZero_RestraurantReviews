using System.Web.Mvc;

namespace RR.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home/Index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}