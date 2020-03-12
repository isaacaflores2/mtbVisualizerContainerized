using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Map.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Map.API.Models;
using IO.Swagger.Api;

namespace Map.API
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
            services.AddControllers();

            var connectionString = Configuration["MapAPIConnectionString"];
            services.AddDbContext<MapCoordinatesContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<IActivitiesApi, ActivitiesApi>();
            services.AddTransient<IAthletesApi, AthletesApi>();
            services.AddTransient<ICoordinatesRepository, CoordinatesRepository>();
            services.AddTransient<IStravaClient, StravaClient>();
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
