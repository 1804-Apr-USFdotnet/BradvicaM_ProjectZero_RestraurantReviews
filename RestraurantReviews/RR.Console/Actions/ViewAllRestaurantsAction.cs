using RR.Console.Controllers;

namespace RR.Console.Actions
{
    public class ViewAllRestaurantsAction : IApplicationAction
    {
        private readonly IRestaurantController _restaurantController;
        private readonly IInputOutput _inputOutput;

        public ViewAllRestaurantsAction(IRestaurantController restaurantController, IInputOutput inputOutput)
        {
            _restaurantController = restaurantController;
            _inputOutput = inputOutput;
        }

        public void Execute()
        {
            _restaurantController.InputViewRestaurantsFilter().Render();

            var filterInput = _inputOutput.ReadString();

            _restaurantController.AllRestaurants(filterInput).Render();
        }
    }
}
