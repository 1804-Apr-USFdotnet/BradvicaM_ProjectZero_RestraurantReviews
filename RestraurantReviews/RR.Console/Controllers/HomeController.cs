using RR.Console.Views;

namespace RR.Console.Controllers
{
    public class HomeController : IHomeController
    {
        public ActionResult Index()
        {
            return ViewEngine.Index();
        }

        public ActionResult Quit()
        {
            return ViewEngine.Quit();
        }
    }
}
