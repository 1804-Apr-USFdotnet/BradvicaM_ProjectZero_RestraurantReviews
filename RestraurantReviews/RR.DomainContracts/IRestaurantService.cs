using System.Collections.Generic;
using RR.Models;

namespace RR.DomainContracts
{
    public interface IRestaurantService
    {
        List<Restaurant> TopThreeRestaurantByAverageReview();
        List<Restaurant> AllRestaurants();
        List<Restaurant> SearchAll(string searchParameter);
        Restaurant SearchByName(string searchParameter);
        void AddRestaurant(Restaurant restaurant);
    }
}
