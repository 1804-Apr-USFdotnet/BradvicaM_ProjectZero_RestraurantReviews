using System.Collections.Generic;
using Library.Models;

namespace Library.BusinessInterfaces
{
    public interface IRestaurantService
    {
        List<Restaurant> TopThreeRestaurantByAverageReview();
        List<Restaurant> AllRestaurants();
        List<Restaurant> SearchByString(string searchParameter);
    }
}
