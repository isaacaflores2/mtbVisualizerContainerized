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

        public DbSet<SummaryActivity> Summaries { get; set; }

        DbSet<UserActivity> IUserActivityDbContext.UserActivities {
            get => UserActivities;
        }

        DbSet<SummaryActivity> IUserActivityDbContext.Summaries {
            get => Summaries;
        }

        public UserActivityDbContext(DbContextOptions<UserActivityDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
      
        void IUserActivityDbContext.SaveChanges()
        {
            this.SaveChanges();
        }
    }
}
