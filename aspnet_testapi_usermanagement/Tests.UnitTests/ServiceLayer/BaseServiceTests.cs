using AutoMapper;
using AutoMapper.Configuration;
using DataLayer;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer;
using ServiceLayer.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace Tests.UnitTests.ServiceLayer
{
    [TestClass]
    public class BaseServiceTests
    {
        [TestMethod]
        public async Task CreateAsync_ValidCreationView_View()
        {
            var factory = new BaseServiceFactory();

            factory.MappingConfig.CreateMap<TestCreateView, TestEntity>();
            factory.MappingConfig.CreateMap<TestEntity, TestView>();

            var service = factory.CreateBaseService();

            var createView = new TestCreateView
            {

            };

            var result = await service.CreateAsync<TestView>(createView);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(TestView));
        }

        [TestMethod]
        public async Task CreateAsync_CreationViewNull_ThrowsArgumentNullException()
        {
            var factory = new BaseServiceFactory();

            factory.MappingConfig.CreateMap<TestCreateView, TestEntity>();
            factory.MappingConfig.CreateMap<TestEntity, TestView>();

            var service = factory.CreateBaseService();

            var createView = (TestCreateView)null!;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
                await service.CreateAsync<TestView>(createView));
        }

        [TestMethod]
        public async Task CreateAsync_TargetMappingMissing_ThrowsAutoMapperMappingException()
        {
            var factory = new BaseServiceFactory();

            factory.MappingConfig.CreateMap<TestCreateView, TestEntity>();

            var service = factory.CreateBaseService();

            var createView = new TestCreateView
            {

            };

            await Assert.ThrowsExceptionAsync<AutoMapperMappingException>(async () =>
                await service.CreateAsync<TestView>(createView));
        }
    }

    internal class TestView : IViewOf<TestEntity>
    {
    }

    internal class TestCreateView : ICreateView<TestEntity>
    {
    }

    internal class BaseServiceFactory
    {
        public BaseServiceFactory()
        {
            DbContextOptions<TestDataContext> options = new DbContextOptionsBuilder<TestDataContext>()
              .UseInMemoryDatabase(Guid.NewGuid().ToString())
              .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
              .Options;

            Context = new TestDataContext(options);
            MappingConfig = new MapperConfigurationExpression();
        }

        public TestDataContext Context { get; }
        public MapperConfigurationExpression MappingConfig { get; }

        internal IGenericService<Guid, TestEntity> CreateBaseService()
        {
            var mapper = new MapperConfiguration(MappingConfig).CreateMapper();

            return new TestService(Context, mapper);
        }
    }

    internal class TestEntity : BaseEntity<Guid>
    {

    }

    internal class TestService : BaseService<Guid, TestEntity>
    {
        public TestService(IDataContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
    }

    internal interface ITestDataContext : IDataContext
    {
        DbSet<TestEntity> TestEntities { get; set; }
    }

    internal class TestDataContext : DbContext, ITestDataContext
    {
        public TestDataContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<TestEntity> TestEntities { get; set; } = null!;
    }
}
