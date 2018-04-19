using System;
using System.Collections.Generic;
using RR.DomainContracts;
using RR.Models;
using RR.RepositoryContracts;

namespace RR.DomainServices
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
            throw new NotImplementedException();
        }

        public List<Restaurant> AllRestaurants()
        {
            throw new NotImplementedException();
        }

        public List<Restaurant> SearchByString(string searchParameter)
        {
            throw new NotImplementedException();
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
