using AutoMapper;
using DataLayer.API;
using DataLayer.Entities;
using DataLayer.Entities.Entities;
using DataLayer.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer.Blogs;
using ServiceLayer.Interfaces;
using ServiceLayer.Users;
using ViewModels.Blogs;
using ViewModels.Users;

namespace api
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddUserManager<ApplicationUserManager>()
            .AddRoleManager<ApplicationRoleManager>()
            .AddDefaultTokenProviders();

            services.AddScoped<IDataContext, BlogContext>();
            services.AddDbContext<BlogContext>();

            services.AddScoped<IBlogService, BlogService>();

            services.AddScoped<IUserService, UserService>();
            //services.AddSingleton<IBlogService>(x => x.GetRequiredService<BlogService>());
            //services.AddSingleton(typeof(IGenericService<>));
            //services.AddSingleton(typeof(BaseService<>));


            //services.AddScoped<IUserService, UserService>();
            //

            services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(x =>
            {
                x.AddProfile<BlogMapping>();
                x.AddProfile<UserMapping>();
            })));

            services.AddControllers();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "BlogApi", Version = "V1" });
                s.CustomSchemaIds(x => x.FullName);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "BlogApi V1");
                x.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
