using System;
using System.Data.Entity;
using RR.Models;

namespace RR.Repositories
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<RestaurantReviewsContext>
    {
        protected override void Seed(RestaurantReviewsContext context)
        {
            var id = Guid.NewGuid();

            var restaurant = new Restaurant
            {
                City = "Kansas City",
                State = "MO",
                Street = "123 Barbeque St.",
                ZipCode = 81721,
                RestaurantId = id,
                Name = "Billy Bobs Texas BBQ",
                PhoneNumber = "8761234121",
                AverageRating = 0.0,
                Website = "www.billybobs.com"
            };

            var review = new Review
            {
                ReviewId = Guid.NewGuid(),
                RestaurantId = id,
                Comment = "It was ok.",
                Rating = 5.00,
                ReviewerName = "Mike"
            };


            context.Restaurants.Add(restaurant);
            context.Reviews.Add(review);
            base.Seed(context);
            context.SaveChanges();
        }
    }
}
