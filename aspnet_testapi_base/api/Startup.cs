using AutoMapper;
using DataLayer.API;
using DataLayer.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer.Blogs;
using ServiceLayer.Interfaces;
using System;

namespace api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataContext, BlogContext>();
            //services.AddDbContext<BlogContext>(options => options.UseNpgsql("DefaultConnection"));
            services.AddDbContext<BlogContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

            //services.AddScoped(typeof(IGenericService<>), typeof(BaseService<>));
            services.AddScoped<IBlogService, BlogService>();

            services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(x =>
            {
                x.AddProfile<BlogMapping>();
            })));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
