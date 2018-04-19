using System;
using System.Collections.Generic;
using RR.Models;

namespace RR.RepositoryContracts
{
    public interface IRestaurantRepository
    {
        Restaurant GetById(Guid id);
        IEnumerable<Restaurant> GetAll();
        void Add(Restaurant restaurant);
        void UpdateRestaurants();
    }
}
