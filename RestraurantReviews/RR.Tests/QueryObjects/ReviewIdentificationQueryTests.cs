using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.Models;
using RR.QueryObjects;

namespace RR.Tests.QueryObjects
{
    [TestClass]
    public class ReviewIdentificationQueryTests
    {
        private List<Review> _reviews;
        private readonly ReviewIdentificationQuery _query;

        public ReviewIdentificationQueryTests()
        {
            const int idToSearch = 1;
            _query = new ReviewIdentificationQuery(idToSearch);
        }

        [TestMethod]
        public void AsExpression_OnCall_ReturnsCorrectReview()
        {
            _reviews = new List<Review>
            {
                new Review{ReviewIdentification = 1},
                new Review{ReviewIdentification = 2}
            };

            var result = _reviews.AsQueryable().Where(_query.AsExpression()).ToList();

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void AsExpression_OnCall_DoesntReturnIncorrectReview()
        {
            _reviews = new List<Review>
            {
                new Review{ReviewIdentification = 1},
                new Review{ReviewIdentification = 2}
            };

            var result = _reviews.AsQueryable().Where(_query.AsExpression()).First();

            const int expected = 1;

            Assert.AreEqual(expected, result.ReviewIdentification);
        }
    }
}
