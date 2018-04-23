using System;
using System.Collections.Generic;
using Library.Models;

namespace Library.RepositoryInterfaces
{
    public interface IRestaurantRepository
    {
        Restaurant GetById(Guid id);
        IEnumerable<Restaurant> GetAll();
    }
}
