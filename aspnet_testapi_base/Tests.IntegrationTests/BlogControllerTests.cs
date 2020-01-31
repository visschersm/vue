using api;
using DataLayer.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Blogs = ServiceLayer.Blogs;

namespace Tests.IntegrationTests
{
    [TestClass]
    public class BlogControllerTests
    {
        private TestServer _server;
        private HttpClient _client;

        [TestInitialize]
        public void Initialize()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()
                .ConfigureTestServices(services =>
                {
                    services.AddDbContext<BlogContext>(options =>
                    options.UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));
                }));
            _client = _server.CreateClient();
        }

        [TestMethod]
        public async Task GetByIdAsync_NotExistingGUID_BadRequest()
        {
            var guid = Guid.NewGuid();
            var response = await _client.GetAsync($"/Blog/{guid}");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task GetAsync()
        {
            var response = await _client.GetAsync("/Blog");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            var blog = JsonConvert.DeserializeObject<Blogs.Views.List[]>(result);

            Assert.IsNotNull(blog);
        }
    }
}
