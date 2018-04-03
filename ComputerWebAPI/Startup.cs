using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ComputerLibrary;
using ComputerDAL;
using ComputerLibrary.Models;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

namespace ComputerWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ComputerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("ComputerWebAPI")));
            services.AddSingleton(typeof(IDataRepository<Computer, long>), typeof(ComputerManager));
            services.AddTransient(typeof(IDataRepository<Computer, long>), typeof(ComputerManager));
            //services.AddDbContext<ComputerContext>(opt => opt.UseInMemoryDatabase("ComputerDB"));

            services.AddCors(options =>
            {
                options.AddPolicy("LocalDev",
                    policy => policy.AllowAnyOrigin());
                //options.AddPolicy("LocalDev",
                //    policy => policy.WithOrigins("http://localhost:4200"));
                //options.AddPolicy("Prod",
                //    policy => policy.WithOrigins("http://computerui20180331103025.azurewebsites.net"));

            });

            //services.AddMvc();
            services.AddMvc(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("LocalDev"));
               // options.Filters.Add(new CorsAuthorizationFilterFactory("Prod"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseCors("UILocal");
            //app.UseMvc();
            app.UseMvcWithDefaultRoute();
        }
    }
}
