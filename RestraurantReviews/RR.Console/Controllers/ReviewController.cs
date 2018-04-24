using System.Collections.Generic;
using AutoMapper;
using RR.Console.Views;
using RR.DomainContracts;
using RR.Models;
using RR.ViewModels;

namespace RR.Console.Controllers
{
    public class ReviewController
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

            return ViewEngine.Null();
        }

        public ActionResult RestaurantReviews(string restaurantName)
        {
            var restaurant = _restaurantService.SearchByName(restaurantName);

            var reviews = _reviewService.AllReviews(restaurant);

            var viewModel = _mapper.Map<IEnumerable<ReviewViewModel>>(reviews);

            return ViewEngine.Null();
        }
    }
}
