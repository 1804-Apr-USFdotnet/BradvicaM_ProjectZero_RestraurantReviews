using RR.Console.Controllers;

namespace RR.Console.Actions
{
    public class AddRestaurantAction : IApplicationAction
    {
        private readonly RestaurantController _controller;

        public AddRestaurantAction(RestaurantController controller)
        {
            _controller = controller;
        }

        public void Execute()
        {
            
        }
    }
}
