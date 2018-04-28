using RR.Console.Views;
using RR.ViewModels;

namespace RR.Console.Controllers
{
    public interface IRestaurantController
    {
        ActionResult InputAddUpdateRestaurant();
        ActionResult AddRestaurant(AddRestaurantViewModel viewModel);
        ActionResult InputViewRestaurantsFilter();
        ActionResult AllRestaurants(string orderby);
        ActionResult AllRestaurants();
        ActionResult TopRatedRestaurants();
        ActionResult RestaurantDetails(string name);
        ActionResult SearchForEntity(string searchValue);
        ActionResult InputRestaurantName();
        ActionResult InputSearchTerm();
        ActionResult UpdateRestaurant(string restaurantName, UpdateRestaurantViewModel viewModel);
        ActionResult DeleteRestaurant(string restaurantName);
    }
}
