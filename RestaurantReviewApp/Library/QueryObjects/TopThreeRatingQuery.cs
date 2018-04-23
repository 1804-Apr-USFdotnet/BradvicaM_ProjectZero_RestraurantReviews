using System.Collections.Generic;
using System.Linq;
using Library.Models;

namespace Library.QueryObjects
{
    public class TopThreeRatingQuery
    {
        private const int NumberOfRestaurants = 3;

        public List<Restaurant> AsExpression(IEnumerable<Restaurant> restaurants)
        {
            return restaurants.OrderByDescending(x => x.AverageRating).Take(NumberOfRestaurants).ToList();
        }
    }
}
