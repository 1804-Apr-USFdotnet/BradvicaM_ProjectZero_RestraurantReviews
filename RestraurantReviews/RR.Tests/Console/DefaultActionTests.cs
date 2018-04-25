using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RR.Console.Actions;
using RR.Console.Controllers;
using RR.Console.Views.Home;

namespace RR.Tests.Console
{
    [TestClass]
    public class DefaultActionTests
    {
        private readonly Mock<IHomeController> _mock;

        public DefaultActionTests()
        {
            _mock = new Mock<IHomeController>();
            _mock.Setup(x => x.Index()).Returns(new IndexView());
            _mock.Setup(x => x.Index().Render());
        }

        [TestMethod]
        public void Execute_OnCall_CallsIndex()
        {
            var action = new DefaultAction(_mock.Object);

            action.Execute();
            
            _mock.Verify(x => x.Index(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_RendersView()
        {
            var action = new DefaultAction(_mock.Object);

            action.Execute();

            _mock.Verify(x => x.Index().Render(), Times.AtLeastOnce);
        }
    }
}
