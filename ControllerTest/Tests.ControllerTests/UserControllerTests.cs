using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Controllers;

namespace Tests.ControllerTests
{
    [TestClass]
    public class UserControllerTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {

        }

        [TestInitialize]
        public void TestInit()
        {

        }

        [TestMethod]
        public async Task GetAsync_ReturnsAOkObjectResult_WithAListOfUsers()
        {
            var mockService = new Mock<IUserService>();
            mockService.Setup(service => service.GetAsync<ViewModel.User.List>())
                .ReturnsAsync(GetTestSessions());

            var userService = mockService.Object;

            var controller = new UserController(userService);

            var result = await controller.GetAsync();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(2, ((List<ViewModel.User.List>)((OkObjectResult)result).Value).Count());
        }

        private List<ViewModel.User.List> GetTestSessions()
        {
            var sessions = new List<ViewModel.User.List>
            {
                new ViewModel.User.List
                {
                    Username = "John Doe",
                    Password = "WelcomeJohn",
                    Email = "john.doe@test.com"
                },
                new ViewModel.User.List
                {
                    Username = "Jane Doe",
                    Password = "WelcomeJane",
                    Email = "jane.doe@test.com"
                }
            };
            return sessions;
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
