using System.Collections.Generic;
using AutoMapper;
using RR.Console.Views;
using RR.DomainContracts;
using RR.Models;
using RR.ViewModels;

namespace RR.Console.Controllers
{
    public class ReviewController : IReviewController
    {
        private readonly IReviewService _reviewService;
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public ReviewController(IReviewService reviewService, IMapper mapper, IRestaurantService restaurantService)
        {
            _reviewService = reviewService;
            _mapper = mapper;
            _restaurantService = restaurantService;
        }

        public ActionResult AddReview(AddReviewViewModel viewModel)
        {
            var review = _mapper.Map<Review>(viewModel);

            _reviewService.AddReview(review);

            return ViewEngine.AddReview();
        }

        public ActionResult InputAddReview()
        {
            var allRestaurants = _restaurantService.AllRestaurants();

            var viewModel = _mapper.Map<IEnumerable<RestaurantNameViewModel>>(allRestaurants);

            return ViewEngine.InputAddReview(viewModel);
        }

        public ActionResult RestaurantReviews(string restaurantName)
        {
            var restaurant = _restaurantService.SearchByName(restaurantName);

            var reviews = _reviewService.AllReviews(restaurant);

            var viewModel = _mapper.Map<IEnumerable<ReviewViewModel>>(reviews);

            return ViewEngine.RestaurantReviews(viewModel);
        }

        public ActionResult InputUpdateReview()
        {
            return ViewEngine.InputUpdateReview();
        }

        public ActionResult UpdateReview(UpdateReviewViewModel viewModel)
        {
            var reviewToUpdate = _reviewService.GetByIdentification(viewModel.ReviewIdentification);

            viewModel.Review = reviewToUpdate;

            var updatedReview = _mapper.Map<Review>(viewModel);

            _reviewService.UpdateReview(updatedReview);

            reviewToUpdate.Restaurant.CalculateAverageRating(reviewToUpdate.Restaurant.Reviews);
            _restaurantService.UpdateRestaurant(reviewToUpdate.Restaurant);

            return ViewEngine.UpdateReview();
        }

        public ActionResult InputDeleteReview()
        {
            return ViewEngine.InputDeleteReview();
        }

        public ActionResult DeleteReview(int reviewId)
        {
            var reviewToDelete = _reviewService.GetByIdentification(reviewId);
            var restaurantToUpdate = reviewToDelete.Restaurant;

            _reviewService.DeleteReview(reviewToDelete);

            restaurantToUpdate.CalculateAverageRating(restaurantToUpdate.Reviews);
            _restaurantService.UpdateRestaurant(restaurantToUpdate);

            return ViewEngine.DeleteReview();
        }
    }
}
