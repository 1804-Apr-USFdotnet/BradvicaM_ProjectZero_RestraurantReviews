using System.Collections.Generic;
using Library.Models;

namespace Library.RepositoryInterfaces
{
    public interface IContext
    {
        IList<Restaurant> Restaurants { get; }
        IList<Review> Reviews { get; }
    }
}
