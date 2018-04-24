using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RR.Console;
using RR.Console.Actions;
using RR.Console.Controllers;

namespace RR.Tests.Console
{
    [TestClass]
    public class SearchActionTests
    {
        private readonly Mock<IRestaurantController> _controller;
        private readonly Mock<IInputOutput> _inputOutput;

        public SearchActionTests()
        {
            _controller = new Mock<IRestaurantController>();
            _inputOutput = new Mock<IInputOutput>();

            _controller.Setup(x => x.InputSearchTerm().Render());
            _controller.Setup(x => x.SearchForEntity(It.IsAny<string>()).Render());
        }

        [TestMethod]
        public void Execute_OnCall_RendersFirstView()
        {
            var action = new SearchAction(_controller.Object, _inputOutput.Object);

            action.Execute();

            _controller.Verify(x => x.InputSearchTerm().Render(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_CallCorrectMethod()
        {
            var action = new SearchAction(_controller.Object, _inputOutput.Object);

            action.Execute();

            _controller.Verify(x => x.SearchForEntity(It.IsAny<string>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_RendersSecondView()
        {
            var action = new SearchAction(_controller.Object, _inputOutput.Object);

            action.Execute();

            _controller.Verify(x => x.SearchForEntity(It.IsAny<string>()).Render(), Times.AtLeastOnce);
        }
    }
}
