using Microsoft.AspNetCore.Mvc;
using Moq;
using ServiceLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Controllers;
using Xunit;

namespace Tests.xUnitTests
{
    public class UserControllerTests
    {
        [Fact]
        public async Task GetAsync_ReturnsAOkObjectResult_WithAListOfUsers()
        {
            var mockService = new Mock<IUserService>();
            mockService.Setup(service => service.GetAsync<ViewModel.User.List>())
                .ReturnsAsync(GetTestSessions());

            var controller = new UserController(mockService.Object);

            var result = await controller.GetAsync();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ViewModel.User.List>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
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
    }
}
