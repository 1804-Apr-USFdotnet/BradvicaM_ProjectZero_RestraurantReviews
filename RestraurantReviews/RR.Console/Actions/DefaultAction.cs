using RR.Console.Controllers;

namespace RR.Console.Actions
{
    public class DefaultAction : IApplicationAction
    {
        private readonly IHomeController _homeController;

        public DefaultAction(IHomeController homeController)
        {
            _homeController = homeController;
        }

        public void Execute()
        {
            _homeController.Index().Render();
        }
    }
}
