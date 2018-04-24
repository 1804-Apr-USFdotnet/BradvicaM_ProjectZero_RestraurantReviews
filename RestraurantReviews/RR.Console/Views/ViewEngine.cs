using System.Collections.Generic;
using RR.Console.Views.Home;
using RR.Console.Views.Restaurant;
using RR.Console.Views.Review;
using RR.ViewModels;

namespace RR.Console.Views
{
    public class ViewEngine
    {
        public static ActionResult AddRestaurantSuccess()
        {
            return new AddRestuarantSuccessView();
        }

        public static ActionResult Index()
        {
            return new IndexView();
        }

        public static ActionResult InputRestaurantName()
        {
            return new InputRestaurantNameView();
        }

        public static ActionResult AllRestaurants(IEnumerable<RestaurantNameViewModel> viewModel)
        {
            return new AllRestaurantsView(viewModel);
        }

        public static ActionResult TopRatedRestaurants(IEnumerable<TopRatedRestaurantViewModel> viewModel)
        {
            return new TopRatedRestaurantsView(viewModel);
        }

        public static ActionResult InputSearchTerm()
        {
            return new InputSearchTermView();
        }

        public static ActionResult SearchForEntity(IEnumerable<RestaurantViewModel> viewModel)
        {
            return new SearchForEntityView(viewModel);
        }

        public static ActionResult Null()
        {
            return null;
        }

        public static ActionResult RestaurantDetails(RestaurantViewModel viewModel)
        {
            return new RestaurantDetailsView(viewModel);
        }
    }
}
