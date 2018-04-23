using System;
using System.Linq.Expressions;
using Library.Models;

namespace Library.QueryObjects
{
    public class RestaurantReviewsQuery
    {
        private readonly Restaurant _restaurant;

        public RestaurantReviewsQuery(Restaurant restaurant)
        {
            _restaurant = restaurant;
        }

        public Expression<Func<Review, bool>> AsExpression()
        {
            return review => review.RestaurantId == _restaurant.Id;
        }
    }
}
