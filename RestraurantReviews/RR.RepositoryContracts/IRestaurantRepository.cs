using System;
using System.Collections.Generic;
using RR.Models;

namespace RR.RepositoryContracts
{
    public interface IRestaurantRepository
    {
        Restaurant GetById(Guid id);
        Restaurant GetByName(string name);
        IEnumerable<Restaurant> GetAll();
        void Add(Restaurant restaurant);
        void UpdateRestaurant();
        void UpdateRestaurant(Restaurant restaurant);
        void DeleteRestaurant(Restaurant restaurant);
    }
}
