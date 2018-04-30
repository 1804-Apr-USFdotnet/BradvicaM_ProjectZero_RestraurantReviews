using System.Collections.Generic;
using RR.Models;

namespace RR.DomainContracts
{
    public interface IReviewService
    {
        List<Review> AllReviews(Restaurant restaurant);
        void AddReview(Review review);
        Review GetByIdentification(int id);
        void UpdateReview(Review review);
        void DeleteReview(Review review);
    }
}
