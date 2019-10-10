using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Test.InMemoryControllerTests.TestServices;
using TestApi.Controllers;

namespace Test.InMemoryControllerTests
{
    [TestClass]
    public class UserControllerTests
    {
        private static UserController _controller;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var userService = new UserService();

            _controller = new UserController(userService);
        }

        [TestInitialize]
        public void TestInit()
        {

        }

        [TestMethod]
        public async Task CreateAsync_ReturnsOkObjectResult_WithDetailedUser()
        {
            var result = await _controller.CreateAsync(new ViewModel.User.Create { });

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(((OkObjectResult)result).Value, typeof(ViewModel.User.Detailed));
        }

        [TestMethod]
        public async Task GetAsync_ReturnsAOkObjectResult_WithAListOfUsersAsync()
        {
            var result = await _controller.GetAsync();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(((OkObjectResult)result).Value, typeof(ViewModel.User.List[]));
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnOkObjectResult_WithDetailedUser()
        {
            var result = await _controller.GetByIdAsync(1);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(((OkObjectResult)result).Value, typeof(ViewModel.User.Detailed));
        }

        [TestMethod]
        public async Task UpdateAsync_ReturnOkObjectResult_WithDetailedUser()
        {
            var result = await _controller.UpdateAsync(1, new ViewModel.User.Update { });

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(((OkObjectResult)result).Value, typeof(ViewModel.User.Detailed));
        }

        [TestMethod]
        public async Task DeleteAsync_ReturnNoContentResult()
        {
            var result = await _controller.DeleteAsync(1);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }
    }
}
