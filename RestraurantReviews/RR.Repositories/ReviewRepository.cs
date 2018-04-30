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

        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews;
        }

        public void Add(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public void Update(Review review)
        {
            var entity = _context.Reviews.Find(review.ReviewId);
            _context.Entry(entity).CurrentValues.SetValues(review);
            _context.SaveChanges();
        }

        public void Delete(Review review)
        {
            _context.Reviews.Remove(review);
            _context.SaveChanges();
        }
    }
}
