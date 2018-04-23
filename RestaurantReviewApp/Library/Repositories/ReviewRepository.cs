using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Library.Models;
using Library.RepositoryInterfaces;

namespace Library.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IContext _context;

        public ReviewRepository(IContext context)
        {
            _context = context;
        }

        public IEnumerable<Review> GetAll(Expression<Func<Review, bool>> predicate)
        {
            return _context.Reviews.AsQueryable().Where(predicate);
        }

        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews;
        }

        public void Add(Review review)
        {
            _context.Reviews.Add(review);
        }
    }
}
