using System;
using System.Linq.Expressions;
using RR.Models;

namespace RR.QueryObjects
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
