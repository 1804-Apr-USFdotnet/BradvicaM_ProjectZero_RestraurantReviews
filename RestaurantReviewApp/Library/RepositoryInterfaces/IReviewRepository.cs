using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Library.Models;

namespace Library.RepositoryInterfaces
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAll(Expression<Func<Review, bool>> predicate);
        IEnumerable<Review> GetAll();
        void Add(Review review);
    }
}
