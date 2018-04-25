using System;
using System.Collections.Generic;
using System.Linq;
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

        public Restaurant GetById(Guid id)
        {
            return _context.Restaurants.First(x => x.Id == id);
        }

        public Restaurant GetByName(string name)
        {
            return _context.Restaurants.First(x => x.Name == name);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants;
        }

        public void Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
        }

        public void UpdateRestaurants()
        {
            _context.SaveChanges();
        }
    }
}
