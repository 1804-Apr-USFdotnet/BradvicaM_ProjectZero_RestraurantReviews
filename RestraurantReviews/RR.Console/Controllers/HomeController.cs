using RR.Console.Views;

namespace RR.Console.Controllers
{
    public class HomeController
    {
        public ActionResult Index()
        {
            return ViewEngine.Index();
        }
    }
}
