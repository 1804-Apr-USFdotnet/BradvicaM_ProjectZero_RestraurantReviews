using System;
using System.Collections.Generic;
using System.Linq;
using Library.Models;
using Library.RepositoryInterfaces;

namespace Library.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly IContext _context;

        public RestaurantRepository(IContext context)
        {
            _context = context;
        }

        public Restaurant GetById(Guid id)
        {
            return _context.Restaurants.First(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants;
        }
    }
}

