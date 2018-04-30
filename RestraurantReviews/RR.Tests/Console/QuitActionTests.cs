using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RR.Console.Actions;
using RR.Console.Controllers;

namespace RR.Tests.Console
{
    [TestClass]
    public class QuitActionTests
    {
        private readonly Mock<IHomeController> _controller;

        public QuitActionTests()
        {
            _controller = new Mock<IHomeController>();
            _controller.Setup(x => x.Quit().Render());
        }

        [TestMethod]
        public void Execute_OnCall_RendersQuit()
        {
            var action = new QuitAction(_controller.Object);

            action.Execute();

            _controller.Verify(x => x.Quit().Render(), Times.AtLeastOnce);
        }
    }
}

