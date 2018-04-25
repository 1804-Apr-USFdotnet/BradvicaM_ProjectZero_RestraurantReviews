using RR.Console.Controllers;

namespace RR.Console.Actions
{
    public class TopThreeRatedRestaurantsAction : IApplicationAction
    {
        private readonly IRestaurantController _restaurantController;

        public TopThreeRatedRestaurantsAction(IRestaurantController restaurantController)
        {
            _restaurantController = restaurantController;
        }

        public void Execute()
        {
            _restaurantController.TopRatedRestaurants().Render();
        }
    }
}
