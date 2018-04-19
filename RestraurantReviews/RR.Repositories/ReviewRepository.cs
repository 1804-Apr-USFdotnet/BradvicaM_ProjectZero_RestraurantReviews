using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RR.Models;
using RR.RepositoryContracts;

namespace RR.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly RestaurantReviewsContext _context;

        public ReviewRepository(RestaurantReviewsContext context)
        {
            _context = context;
        }

        public IEnumerable<Review> GetAll(Expression<Func<Review, bool>> predicate)
        {
            return _context.Reviews.Where(predicate);
        }
    }
}
