using System.Collections.Generic;
using RR.Models;

namespace RR.DomainContracts
{
    public interface IReviewService
    {
        List<Review> AllReviews(Restaurant restaurant);
        void AddReview(Review review);
    }
}
