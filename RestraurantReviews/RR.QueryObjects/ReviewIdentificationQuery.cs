using System;
using System.Linq.Expressions;
using RR.Models;

namespace RR.QueryObjects
{
    public class ReviewIdentificationQuery
    {
        private readonly int _reviewId;

        public ReviewIdentificationQuery(int reviewId)
        {
            _reviewId = reviewId;
        }

        public Expression<Func<Review, bool>> AsExpression()
        {
            return review => review.ReviewIdentification == _reviewId;
        }
    }
}

