using System.Data.Entity;
using RR.Models;

namespace Repositories
{
    public class RestaurantReviewsContext : DbContext
    {
        public RestaurantReviewsContext() : base("name=RestaurantReviewsConnectionString")
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
