using System.Collections.Generic;
using Library.Models;

namespace Library.BusinessInterfaces
{
    public interface IReviewService
    {
        List<Review> AllReviews(Restaurant restaurant);
        void AddReview(Review review);
    }
}
