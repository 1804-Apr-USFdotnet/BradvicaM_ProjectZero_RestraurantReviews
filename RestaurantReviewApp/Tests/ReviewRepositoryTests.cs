using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Library.Models;
using Library.Repositories;
using Library.RepositoryInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests
{
    [TestClass]
    public class ReviewRepositoryTests
    {
        private readonly Mock<IContext> _context;
        private readonly List<Review> _reviews;
        

        public ReviewRepositoryTests()
        {
            _reviews = new List<Review>
            {
                new Review
                {
                    Comment = "meh",
                    Id = Guid.Empty,
                    Rating = 5.0,
                    Restaurant = new Restaurant(),
                    RestaurantId = Guid.Empty,
                    ReviewerName = "mike"
                }
            };
            _context = new Mock<IContext>();
            _context.Setup(x => x.Reviews).Returns(_reviews);
        }

        [TestMethod]
        public void GetAll_NoParameter_ReturnsAllReviews()
        {
            var repo = new ReviewRepository(_context.Object);

            var results = repo.GetAll().ToList();

            var expected = _reviews.Count;

            Assert.AreEqual(expected, results.Count);
        }

        [TestMethod]
        public void Add_OnCall_AddsReview()
        {
            var review = new Review();
            var repo = new ReviewRepository(_context.Object);
            repo.Add(review);

            var count = repo.GetAll().ToList().Count;

            const int expected = 2;

            Assert.AreEqual(expected, count);
        }

        [TestMethod]
        public void GetAll_GivenAnExpression_ReturnsReviews()
        {
            var repo = new ReviewRepository(_context.Object);

            var results = repo.GetAll(x => x.Rating > 0.0).ToList();

            var expected = _reviews.Count;

            Assert.AreEqual(expected, results.Count);
        }
    }
}
