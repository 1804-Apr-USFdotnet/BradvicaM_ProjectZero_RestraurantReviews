using System;
using System.Data.Entity;
using RR.Models;

namespace RR.Repositories
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<RestaurantReviewsContext>
    {
        protected override void Seed(RestaurantReviewsContext context)
        {
            var restaurant = new Restaurant
            {
                City = "Kansas City",
                State = "MO",
                Street = "123 Barbeque St.",
                ZipCode = 81721,
                Id = Guid.NewGuid(),
                Name = "Billy Bobs Texas BBQ",
                PhoneNumber = "8761234121",
                AverageRating = 0.0,
                Website = "www.billybobs.com"
            };

            context.Restaurants.Add(restaurant);
            base.Seed(context);
            context.SaveChanges();
        }
    }
}
