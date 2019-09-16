using Microsoft.EntityFrameworkCore;
using stravaVisualizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stravaVisualizer.Data
{   
    public class StravaUserActivitiesDbContext : DbContext
    {
        public DbSet<StravaUserActivities> Activities { get; set; }

        public StravaUserActivitiesDbContext()
        {
        }

        public StravaUserActivitiesDbContext(DbContextOptions<StravaUserActivitiesDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
