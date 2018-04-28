using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RR.Models;

namespace RR.RepositoryContracts
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAll(Expression<Func<Review, bool>> predicate);
        IEnumerable<Review> GetAll();
        void Add(Review review);
        void Update(Review review);
    }
}
