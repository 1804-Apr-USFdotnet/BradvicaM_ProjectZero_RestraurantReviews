using System;

namespace Library.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }
        public string ReviewerName { get; set; }

        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public override string ToString()
        {
            return $"\nId: {Id}\nRating: {Rating}\nComment: {Comment}\nName: {ReviewerName}\n";
        }
    }
}
