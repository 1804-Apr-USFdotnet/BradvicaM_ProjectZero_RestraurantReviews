using RR.Console.Controllers;

namespace RR.Console.Actions
{
    public class QuitAction : IApplicationAction
    {
        private readonly IHomeController _controller;

        public QuitAction(IHomeController controller)
        {
            _controller = controller;
        }

        public void Execute()
        {
            _controller.Quit().Render();
        }
    }
}
