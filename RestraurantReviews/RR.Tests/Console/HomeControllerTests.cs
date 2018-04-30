using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.Console.Controllers;
using RR.Console.Views.Home;

namespace RR.Tests.Console
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index_Returns_CorrectView()
        {
            var controller = new HomeController();

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(IndexView));
        }

        [TestMethod]
        public void Quit_Returns_CorrectView()
        {
            var controller = new HomeController();

            var result = controller.Quit();

            Assert.IsInstanceOfType(result, typeof(QuitView));
        }
    }
}
