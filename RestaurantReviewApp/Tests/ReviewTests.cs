using System;
using ApprovalTests;
using ApprovalTests.Reporters;
using Library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ReviewTests
    {
        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void ToString_OnCall_DisplayProperly()
        {
            var review = new Review
            {
                Comment = "It was kinda meh.",
                Rating = 4.45,
                Id = Guid.Empty
            };

            Approvals.Verify(review);
        }
    }
}
