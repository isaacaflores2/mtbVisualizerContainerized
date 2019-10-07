using IO.Swagger.Model;
using Microsoft.EntityFrameworkCore;
using StravaVisualizer.Data;
using StravaVisualizer.Models;
using StravaVisualizer.Models.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stravaVisualizer.Data
{   
    public class UserActivityDbContext : DbContext, IUserActivityDbContext
    {        
        public DbSet<UserActivity> UserActivities { get; set; }      

        public UserActivityDbContext(DbContextOptions<UserActivityDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SummaryActivity>()
                .Property(s => s.StartLatlng)
                .HasColumnName("start_lat_lng")
                .HasConversion(
                    myProperty => myProperty.ToArray(),
                    myColumnName => new LatLng(myColumnName)
                   );
                
        }

        public void SaveChanges()
        {
            this.SaveChanges();
        }
    }
}
