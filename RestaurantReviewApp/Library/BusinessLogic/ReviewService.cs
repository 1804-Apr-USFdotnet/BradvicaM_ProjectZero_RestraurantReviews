using System.Collections.Generic;
using System.Linq;
using Library.BusinessInterfaces;
using Library.Models;
using Library.QueryObjects;
using Library.RepositoryInterfaces;

namespace Library.BusinessLogic
{
    public class ReviewService : IReviewService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository, IRestaurantRepository restaurantRepository)
        {
            _reviewRepository = reviewRepository;
            _restaurantRepository = restaurantRepository;
        }

        public List<Review> AllReviews(Restaurant restaurant)
        {
            var query = new RestaurantReviewsQuery(restaurant);

            return _reviewRepository.GetAll(query.AsExpression()).ToList();
        }

        public void AddReview(Review review)
        {
            _reviewRepository.Add(review);
            var restaurant = _restaurantRepository.GetById(review.Restaurant.Id);

            var query = new RestaurantReviewsQuery(restaurant);
            var reviews = _reviewRepository.GetAll(query.AsExpression());

            restaurant.CalculateAverageRating(reviews);
        }
    }
}
