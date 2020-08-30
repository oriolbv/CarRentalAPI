using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CarRentalAPI.Models;
using CarRentalAPI.Services;
using CarRentalAPI.Repositories;
using CarRentalAPI.Repositories.Firestore;
using CarRentalAPI.Repositories.InternalStorage;

namespace CarRentalAPI
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
            services.AddControllers().AddNewtonsoftJson();
            
            // Dependency injection
            services.AddTransient<ICarsService, CarsService>();
            services.AddTransient<ICustomersService, CustomersService>();
            
            // Firebase 
            services.AddTransient<ICarsRepository, CarsFirestoreRepository>();
            services.AddTransient<ICustomersRepository, CustomersFirestoreRepository>();

            // Internal Storage
            // services.AddTransient<ICarsRepository, CarsInternalRepository>();
            // services.AddTransient<ICustomersRepository, CustomersInternalRepository>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
