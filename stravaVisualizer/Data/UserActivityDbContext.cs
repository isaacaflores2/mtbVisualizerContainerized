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
       
        public void SaveChanges()
        {
            this.SaveChanges();
        }
    }
}
