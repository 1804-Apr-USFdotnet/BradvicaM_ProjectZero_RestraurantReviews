using System;
using System.Collections.Generic;
using System.Linq;

namespace RR.Models
{
    public class Restaurant
    {
        public Guid RestaurantId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public double AverageRating { get; set; }
        public string Website { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public override string ToString()
        {
            return $"\nId: {RestaurantId}\nName: {Name} \nStreet: {Street}\nCity: {City}\nState: {State}\nZipCode: {ZipCode}" +
                   $"\nPhoneNumber: {PhoneNumber}\nWebsite: {Website}\nRating: {AverageRating}\n";
        }

        public void CalculateAverageRating(IEnumerable<Review> reviews)
        {
            AverageRating = reviews.Select(x => x.Rating).Average();
        }
    }
}
