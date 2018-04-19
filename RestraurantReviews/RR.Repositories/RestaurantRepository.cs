using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RR.Models;
using RR.RepositoryContracts;

namespace RR.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantReviewsContext _context;

        public RestaurantRepository(RestaurantReviewsContext context)
        {
            _context = context;
        }

        public Restaurant Get(Expression<Func<Restaurant, bool>> predicate)
        {
            return _context.Restaurants.Where(predicate).First();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants;
        }

        public IEnumerable<Restaurant> GetAll(Expression<Func<Restaurant, bool>> predicate)
        {
            return _context.Restaurants.Where(predicate);
        }

        public void Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
        }
    }
}
