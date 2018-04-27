using System.Collections.Generic;
using System.Linq;
using RR.DomainContracts;
using RR.Models;
using RR.QueryObjects;
using RR.RepositoryContracts;

namespace RR.DomainServices
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
            var restaurant = _restaurantRepository.GetByName(review.Restaurant.Name);

            review.Restaurant = restaurant;
            _reviewRepository.Add(review);

            restaurant.CalculateAverageRating(restaurant.Reviews);
            _restaurantRepository.UpdateRestaurants();
        }
    }
}
