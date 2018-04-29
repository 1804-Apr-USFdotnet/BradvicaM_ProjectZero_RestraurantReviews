using System.Collections.Generic;
using RR.Console.Views.Home;
using RR.Console.Views.Restaurant;
using RR.Console.Views.Review;
using RR.ViewModels;

namespace RR.Console.Views
{
    public class ViewEngine
    {
        public static ActionResult AddRestaurant()
        {
            return new AddRestuarantView();
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

        public static ActionResult AddReview()
        {
            return new AddReviewView();
        }

        public static ActionResult RestaurantDetails(RestaurantViewModel viewModel)
        {
            return new RestaurantDetailsView(viewModel);
        }

        public static ActionResult InputAddReview(IEnumerable<RestaurantNameViewModel> viewModel)
        {
            return new InputAddReviewView(viewModel);
        }

        public static ActionResult RestaurantReviews(IEnumerable<ReviewViewModel> viewModel)
        {
            return new RestaurantReviewsView(viewModel);
        }

        public static ActionResult InputAddUpdateRestaurant()
        {
            return new InputAddUpdateRestaurantView();
        }

        public static ActionResult InputViewRestaurantsFilter()
        {
            return new InputViewRestaurantsFilterView();
        }

        public static ActionResult UpdateRestaurant()
        {
            return new UpdateRestaurantView();
        }

        public static ActionResult DeleteRestaurant()
        {
            return new DeleteRestaurantView();
        }

        public static ActionResult InputUpdateReview()
        {
            return new InputUpdateReviewView();
        }

        public static ActionResult UpdateReview()
        {
            return new UpdateReviewView();
        }

        public static ActionResult InputDeleteReview()
        {
            return new InputDeleteReviewView();
        }

        public static ActionResult DeleteReview()
        {
            return new DeleteReviewView();
        }
    }
}
