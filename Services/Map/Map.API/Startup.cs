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
using IO.Swagger.Api;
using MtbVis.Common;

namespace Map.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            migrateDatabase(app);
        }

        private static void migrateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<MapCoordinatesContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
