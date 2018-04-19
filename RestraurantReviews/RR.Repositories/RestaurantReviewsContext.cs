using System.Data.Entity;
using RR.Models;

namespace RR.Repositories
{
    public class RestaurantReviewsContext : DbContext
    {
        public RestaurantReviewsContext() : base("name=RestaurantReviewsConnectionString")
        {
            Database.SetInitializer<RestaurantReviewsContext>(new DatabaseInitializer());
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
