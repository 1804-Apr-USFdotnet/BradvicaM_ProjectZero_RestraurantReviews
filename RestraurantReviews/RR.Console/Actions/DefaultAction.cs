using RR.Console.Controllers;

namespace RR.Console.Actions
{
    public class DefaultAction : IApplicationAction
    {
        private readonly HomeController _homeController;

        public DefaultAction(HomeController homeController)
        {
            _homeController = homeController;
        }

        public void Execute()
        {
            _homeController.Index().Render();
        }
    }
}
