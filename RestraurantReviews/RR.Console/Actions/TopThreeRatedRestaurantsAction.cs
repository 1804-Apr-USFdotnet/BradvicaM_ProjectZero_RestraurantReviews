using RR.Console.Controllers;

namespace RR.Console.Actions
{
    internal class TopThreeRatedRestaurantsAction : IApplicationAction
    {
        private readonly RestaurantController _restaurantController;

        public TopThreeRatedRestaurantsAction(RestaurantController restaurantController)
        {
            _restaurantController = restaurantController;
        }

        public void Execute()
        {
            _restaurantController.TopRatedRestaurants().Render();
        }
    }
}
