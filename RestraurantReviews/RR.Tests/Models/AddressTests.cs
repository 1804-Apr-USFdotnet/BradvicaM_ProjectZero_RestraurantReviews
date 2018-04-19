using ApprovalTests;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.Models;

namespace RR.Tests.Models
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void ToString_OnCall_DisplaysProperly()
        {
            var address = new Address
            {
                City = "Kansas City",
                State = "MO",
                Street = "123 Barbeque St.",
                ZipCode = 81721
            };

            Approvals.Verify(address);
        }
    }
}
