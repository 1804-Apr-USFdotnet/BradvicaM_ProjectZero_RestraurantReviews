using System.Web.Mvc;
using RR.ViewModels;

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

        [Route("Home/About")]
        public ActionResult About()
        {
            return View();
        }

        [Route("Home/Contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [Route("Home/Contact")]
        [HttpPost]
        public ActionResult Contact(ContactViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}