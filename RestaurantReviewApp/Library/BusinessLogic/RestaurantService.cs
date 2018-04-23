using System.Collections.Generic;
using System.Linq;
using Library.BusinessInterfaces;
using Library.Models;
using Library.QueryObjects;
using Library.RepositoryInterfaces;

namespace Library.BusinessLogic
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public List<Restaurant> TopThreeRestaurantByAverageReview()
        {
            var resaurants = _restaurantRepository.GetAll();

            var query = new TopThreeRatingQuery();

            return query.AsExpression(resaurants);
        }

        public List<Restaurant> AllRestaurants()
        {
            return _restaurantRepository.GetAll().ToList();
        }

        public List<Restaurant> SearchByString(string searchParameter)
        {
            var query = new SearchRestaurantQuery(searchParameter);

            var restaurants = _restaurantRepository.GetAll();

            return query.AsExpression(restaurants);
        }
    }
}
