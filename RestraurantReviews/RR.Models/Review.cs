using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RR.Models
{
    public class Review
    {
        public Guid ReviewId { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }
        public string ReviewerName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewIdentification { get; set; }

        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public override string ToString()
        {
            return $"\nReviewId: {ReviewId}\nRating: {Rating}\nComment: {Comment}\nName: {ReviewerName}\nId: {ReviewIdentification}\n";
        }
    }
}
