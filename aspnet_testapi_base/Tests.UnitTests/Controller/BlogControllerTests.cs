﻿using api.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLayer.Interfaces;
using System.Threading.Tasks;
using Blogs = ServiceLayer.Blogs;

namespace Tests.UnitTests.Controller
{
    [TestClass]
    public class BlogControllerTests
    {
        [TestMethod]
        public async Task CreateAsync_ValidCreation_OkObjectResult()
        {
            var factory = new BlogControllerFactory();

            factory.BlogService.Setup(x => x.CreateAsync<Blogs.Views.Create, Blogs.Views.Simple>(It.IsAny<Blogs.Views.Create>()))
                .ReturnsAsync(new Blogs.Views.Simple { });

            var controller = factory.CreateBlogController();

            var toCreate = new Blogs.Views.Create { };

            var result = await controller.CreateAsync(toCreate);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(((OkObjectResult)result).Value, typeof(Blogs.Views.Simple));
        }

        [TestMethod]
        public async Task CreateAsync_MissingMapping_BadRequestObjectResult()
        {
            var factory = new BlogControllerFactory();

            factory.BlogService.Setup(x => x.CreateAsync<Blogs.Views.Create, Blogs.Views.Simple>(It.IsAny<Blogs.Views.Create>()))
                .ThrowsAsync(new AutoMapperMappingException { });

            var controller = factory.CreateBlogController();

            var toCreate = new Blogs.Views.Create { };

            var result = await controller.CreateAsync(toCreate);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var data = ((BadRequestObjectResult)result).Value;
        }
    }

    internal class BlogControllerFactory
    {
        public BlogControllerFactory()
        {
            BlogService = new Mock<IBlogService>();
        }

        public Mock<IBlogService> BlogService { get; }

        internal BlogController CreateBlogController()
        {
            return new BlogController(BlogService.Object);
        }
    }
}
