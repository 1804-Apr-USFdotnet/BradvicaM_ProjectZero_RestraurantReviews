using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RR.Models;

namespace RR.RepositoryContracts
{
    public interface IRestaurantRepository
    {
        Restaurant Get(Expression<Func<Restaurant, bool>> predicate);
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetAll(Expression<Func<Restaurant, bool>> predicate);
        void Add(Restaurant restaurant);
    }
}
