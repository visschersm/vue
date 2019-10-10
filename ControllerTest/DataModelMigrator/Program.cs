using DataLayer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DataModelMigrator
{
    class MigrationTool
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => builder.AddConsole());
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();

            var logger = loggerFactory.CreateLogger<MigrationTool>();

            var optionsBuilder = new DbContextOptionsBuilder<DataModel>();
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var connectionString =
                $"Host={configuration["DbHostname"]};Port={configuration["DbPort"]};Database={configuration["Db"]};Username={configuration["DbUser"]};Password={configuration["DbPass"]};";
            optionsBuilder.UseNpgsql(connectionString);
            using (var context = new DataModel(optionsBuilder.Options))
            {
                logger.LogInformation("Migrating database to current version: {ConnectionString}", configuration.GetConnectionString("Default"));
                context.Database.Migrate();
            }
        }
    }
}
