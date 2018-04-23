using System;
using System.Collections.Generic;
using Library.Models;
using Library.RepositoryInterfaces;

namespace Library.Repositories
{
    public class DataContext : IContext
    {
        public IList<Restaurant> Restaurants { get; }
        public IList<Review> Reviews { get; }

        public DataContext()
        {
            Restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    AverageRating = 0.0,
                    City = "Tampa",
                    Id = Guid.Parse("07ea7c51-070b-4ee9-9883-12443a96752b"),
                    Name = "Dirty Devin's Mud Hut",
                    PhoneNumber = "1234569131",
                    State = "FL",
                    Street = "123 Dirty St.",
                    Website = "www.dirtydevins.com",
                    ZipCode = 12341
                },
                new Restaurant
                {
                    AverageRating = 0.0,
                    City = "Kansas City",
                    Id = Guid.Parse("10073061-d73d-4af0-8c5a-3b5a87632d11"),
                    Name = "Miguel's Little Mexico",
                    PhoneNumber = "1238764591",
                    State = "MO",
                    Street = "45 23nd St.",
                    Website = "www.miguels.com",
                    ZipCode = 18712
                }
            };

            Reviews = new List<Review>();
        }
    }
}
