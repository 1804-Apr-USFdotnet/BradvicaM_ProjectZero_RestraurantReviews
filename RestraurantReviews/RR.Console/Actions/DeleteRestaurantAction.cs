using RR.Console.Controllers;

namespace RR.Console.Actions
{
    public class DeleteRestaurantAction : IApplicationAction
    {
        private readonly IRestaurantController _restaurantController;
        private readonly IInputOutput _inputOutput;

        public DeleteRestaurantAction(IRestaurantController restaurantController, IInputOutput inputOutput)
        {
            _restaurantController = restaurantController;
            _inputOutput = inputOutput;
        }

        public void Execute()
        {
            _restaurantController.AllRestaurants().Render();

            var restaurantToDelete = _inputOutput.ReadString();

            _restaurantController.DeleteRestaurant(restaurantToDelete).Render();
        }
    }
}
